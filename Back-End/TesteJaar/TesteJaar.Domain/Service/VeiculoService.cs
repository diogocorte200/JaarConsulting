using AutoMapper;
using System.Drawing;
using System.Text.RegularExpressions;
using TesteJaar.Domain.Domain;
using TesteJaar.Domain.Service.Generic;
using TesteJaar.Infra.Entity;
using TesteJaar.Infra.Repositories;
using TesteJaar.Infra.Repositories.Interfaces;
using TesteJaar.Infra.UnitofWork;

namespace TesteJaar.Domain.Service
{
    public class VeiculoService<Tv, Te> : GenericServiceAsync<Tv, Te>
                                                where Tv : VeiculoModel
                                                where Te : Veiculo
    {
        IveiculoRepository _veiculoRepository;

        public VeiculoService(IUnitofWork unitOfWork, IMapper mapper,
                             IveiculoRepository veiculoRepository)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;

            if (_veiculoRepository == null)
                _veiculoRepository = veiculoRepository;
        }

        public async Task<Veiculo> ModelarVeiculo(VeiculoCreateModel veiculo)
        {
            Veiculo result = new Veiculo()
            {
                Id = Guid.NewGuid(),
                AnoModelo = veiculo.AnoModelo,
                CodigoFipe = veiculo.CodigoFipe,
                Combustivel = veiculo.Combustivel,
                DataConsulta = veiculo.DataConsulta,
                Marca = veiculo.Marca,
                MesReferencia = veiculo.MesReferencia,
                Modelo = veiculo.Modelo,
                SiglaCombustivel = veiculo.SiglaCombustivel,
                TipoVeiculo = veiculo.TipoVeiculo,
                Valor = veiculo.Valor,
                Placa = veiculo.Placa


            };

            return result;
        }

        public async Task<RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>> AdicionarVeiculo(List<VeiculoCreateModel> veiculo)
        {

            RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid> retornoController = new RetornoControllerViewModel<ExibicaoMensagemViewModel, Guid>();

            foreach (var item in veiculo)
            {
                try
                {
                    var veiculoInserir = await ModelarVeiculo(item);
                    var entityVeiculo = veiculoInserir;

                    _veiculoRepository.Add(entityVeiculo);
                    _veiculoRepository.Save();

                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return retornoController;

        }
        public async Task<string> DeletarVeiculo(string idVeiculo)
        {

            var result = _veiculoRepository.GetSingleOrDefault(x => x.Id.ToString() == idVeiculo);

            if (result == null)
                throw new Exception("Logradouro não encontrado.");

            _veiculoRepository.Remove(result);
            _veiculoRepository.Save();

            return idVeiculo;
        }
        public async Task<List<VeiculoModel>> ListaVeiculos()
        {
            var VeiculosAtivos = _veiculoRepository.GetAll();

            List<VeiculoModel> veiculos = new List<VeiculoModel>();
            foreach (var elem in VeiculosAtivos)
            {
                var lista = new VeiculoModel();
                lista.AnoModelo = elem.AnoModelo;
                lista.CodigoFipe = elem.CodigoFipe;
                veiculos.Add(lista);
            }
            return veiculos.ToList();
        }
        public async Task<Veiculo> BuscarCarroPorPlaca(string placa)
        {
            var veiculo = _veiculoRepository.Find(c => c.Placa == placa).FirstOrDefault();

            return veiculo;
        }

        public async Task<Veiculo> BuscarVeiculoNome(string nome)
        {
            var veiculos = _veiculoRepository.Find(c => c.Modelo == nome).FirstOrDefault();

            return veiculos;
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TesteJaar.Domain.Domain;
using TesteJaar.Domain.Service;
using TesteJaar.Infra.Entity;

namespace TesteJaar.Api.Controllers
{
    [Route("api/Veiculo")]
    [AllowAnonymous]
    public class VeiculoController : Controller
    {
        private readonly VeiculoService<VeiculoModel, Veiculo> _veiculo;

        private readonly HttpClient _httpClient;

        protected readonly IConfiguration _configuration;

        public VeiculoController(VeiculoService<VeiculoModel, Veiculo> veiculoService, HttpClient httpClient, IConfiguration configuration)
        {
            _veiculo = veiculoService;
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClient.BaseAddress = new Uri(_configuration["BaseUrl"]);
        }

        [HttpPost("AdicionarVeiculo")]
        public async Task<IActionResult> AdicionarVeiculo([FromBody] List<VeiculoCreateModel> veiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (veiculo == null)
                return BadRequest();

            var veiculoResposta = await _veiculo.AdicionarVeiculo(veiculo);

            if (veiculoResposta == null)
            {
                return StatusCode(500, "Erro ao adicionar Candidato!");
            }
            if (veiculoResposta.ExibicaoMensagem != null)
            {
                return StatusCode(veiculoResposta.ExibicaoMensagem.StatusCode, veiculoResposta);
            }

            return Ok(veiculoResposta);
        }


        [HttpGet("Carros")]
        public async Task<IActionResult> Carro(string codigoFipe, string anoVeiculo)
        {
            List<Veiculo> veiculoList = new List<Veiculo>();

            var getCandidato = await _httpClient.GetAsync($"api/fipe/preco/v1/{codigoFipe}");

            var jsonResponse = await getCandidato.Content.ReadAsStringAsync();
            veiculoList = JsonConvert.DeserializeObject<List<Veiculo>>(jsonResponse);
            veiculoList = veiculoList.Where(x => x.AnoModelo == Convert.ToInt32(anoVeiculo)).ToList();

            foreach (var item in veiculoList)
            {
                var t = item.AnoModelo;
            }
            return Ok(veiculoList);
        }

        [HttpGet("Listar/{placa}")]
        public async Task<IActionResult> ListarPorPlaca(string placa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var veiculo = await _veiculo.BuscarCarroPorPlaca(placa);

            return Ok(veiculo);
        }
    }
}
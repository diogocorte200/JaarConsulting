﻿using AutoMapper.Execution;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TesteJaar.Domain.Domain
{
    public class VeiculoCreateModel
    {
        public string Valor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoModelo { get; set; }
        public string Combustivel { get; set; }
        public string CodigoFipe { get; set; }
        public string MesReferencia { get; set; }
        public int TipoVeiculo { get; set; }
        public string SiglaCombustivel { get; set; }
        public string DataConsulta { get; set; }
        public string Placa { get; set; }
    }
}

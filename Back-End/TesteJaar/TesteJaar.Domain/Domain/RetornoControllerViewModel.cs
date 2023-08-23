using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteJaar.Domain.Domain
{
    public class RetornoControllerViewModel<ExibicaoMensagemViewModel, TObjeto>
    {
        public ExibicaoMensagemViewModel ExibicaoMensagem { get; set; }
        public TObjeto Objeto { get; set; }
    }
}

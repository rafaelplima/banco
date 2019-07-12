using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using BancoMicrosservico.Aplication.Conta;
using Microsoft.AspNetCore.Mvc;

namespace BancoMicrosservico.API.Controllers
{
    [Route("[banco]")]
    public class ContaController : Controller
    {
        private readonly ICadastrarContaCorrenteServico _contaCorrenteServico;
        public ContaController(ICadastrarContaCorrenteServico contaCorrenteServico)
        {
            _contaCorrenteServico = contaCorrenteServico;
        }

        [Route("cadastrar")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(IEnumerable<Notification>), 422)]
        public ActionResult Post([FromBody]ContaCorrenteSolicitacao contaCorrente)
        {
            var result = _contaCorrenteServico.Salvar(contaCorrente);
            return Created("/", new { result.Agencia, result.Conta, result.Correntista });
        }
    }
}
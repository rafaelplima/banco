using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoMicrosservico.Aplication.Transferencia;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace BancoMicrosservico.API.Controllers
{
    [Route("[banco]")]
    public class TransacaoController : Controller
    {
        private readonly ITransacaoServico _transacaoServico;

        public TransacaoController( ITransacaoServico transacaoServico)
        {
            this._transacaoServico = transacaoServico;
        }

        [Route("transferencia")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(Notification), 422)]
        public ActionResult PostTransferencia([FromBody]TransferenciaSolicitacao transferencia)
        {
            _transacaoServico.Transferir(transferencia);
            return Ok();
        }
    }
}
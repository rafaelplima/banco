using BancoMicrosservico.Domain.Entidade;
using BancoMicrosservico.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoMicrosservico.Aplication.Transferencia
{
    public class TransferenciaSolicitacao
    {
        public const int operacao = Lancamento.TRANSFERENCIA;
        public int ContaOrigem { get; set; }
        public int ContaDestino { get; set; }
        public double valor { get; set; }


    }
}

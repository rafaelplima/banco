using BancoMicrosservico.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoMicrosservico.Domain.Interface
{
    public interface ITransacao
    {
       bool RealizarTransacao(int operacao, ContaCorrente contaOigem, double valor, ContaCorrente contaDestino = null);

       
    }
}

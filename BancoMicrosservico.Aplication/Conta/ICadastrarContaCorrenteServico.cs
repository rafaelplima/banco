using System;
using System.Collections.Generic;
using System.Text;

namespace BancoMicrosservico.Aplication.Conta
{
    public interface ICadastrarContaCorrenteServico
    {
        ContaCorrenteSolicitacao Salvar(ContaCorrenteSolicitacao conta);
    }
}

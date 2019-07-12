using System;
using System.Collections.Generic;
using System.Text;

namespace BancoMicrosservico.Aplication.Transferencia
{
    public interface ITransacaoServico
    {
        bool Transferir(TransferenciaSolicitacao transferencia);
    }
}

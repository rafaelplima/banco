using BancoMicrosservico.Domain.Interface;

namespace BancoMicrosservico.Aplication.Transferencia
{
    public class TransacaoServico:ITransacaoServico
    {
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;
        private readonly INotificacao _notificacao;
        private readonly ITransacao _transacao;

        public TransacaoServico(IContaCorrenteRepositorio contaCorrenteRepositorio, INotificacao notificacao,ITransacao transacao)
        {
            this._contaCorrenteRepositorio = contaCorrenteRepositorio;
            this._notificacao = notificacao;
            this._transacao = transacao;
        }


        public bool Transferir(TransferenciaSolicitacao transferencia)
        {
             var contaOrigem = _contaCorrenteRepositorio.Obter(transferencia.ContaOrigem);

            if (contaOrigem == null)
            {
                _notificacao.AddNotification(nameof(transferencia.ContaOrigem), "A conta origem não existe");
                return false;
            }
            var contaDestino= _contaCorrenteRepositorio.Obter(transferencia.ContaDestino);

            if (contaDestino == null)
            {
                _notificacao.AddNotification(nameof(transferencia.ContaDestino), "A conta destino não existe");
                return false;
            }

            return _transacao.RealizarTransacao(TransferenciaSolicitacao.operacao, contaOrigem, transferencia.valor, contaDestino);


        }
    }
}

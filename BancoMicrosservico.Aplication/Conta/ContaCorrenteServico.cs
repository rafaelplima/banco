using BancoMicrosservico.Domain.Entidade;
using BancoMicrosservico.Domain.Interface;
using System;

namespace BancoMicrosservico.Aplication.Conta
{
    public class ContaCorrenteServico:ICadastrarContaCorrenteServico
    {
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;
        private readonly INotificacao _notificacao;

        public ContaCorrenteServico(IContaCorrenteRepositorio contaCorrenteRepositorio, INotificacao notificacao)
        {
            _contaCorrenteRepositorio = contaCorrenteRepositorio;
            _notificacao = notificacao;
        }

        public ContaCorrenteSolicitacao Salvar(ContaCorrenteSolicitacao conta)
        {

            if (_contaCorrenteRepositorio.Obter(conta.Conta) != null)
            {
                _notificacao.AddNotification(nameof(conta.Conta),"Conta cadastrada");

                return new ContaCorrenteSolicitacao();
            }

            ContaCorrente contaCorrente = new ContaCorrente(Guid.NewGuid(), conta.Conta, conta.Agencia, conta.Correntista, conta.Valor);

            if (contaCorrente.Invalid)
            {
                _notificacao.AddNotifications(contaCorrente.Notifications);

                return new ContaCorrenteSolicitacao();
            }

            _contaCorrenteRepositorio.Salvar(contaCorrente);



            return conta; 


        }
    }
}

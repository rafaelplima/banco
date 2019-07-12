using BancoMicrosservico.Domain.Entidade;
using BancoMicrosservico.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BancoMicrosservico.Aplication.Transferencia
{
    /// <summary>
    /// Infelizmente por questão de espaço de tempo algumas boas práticas não foram usadas
    /// Como a implementação do UnitOfWork
    /// Onde poderia usar o UnitOfWork.BeginTransaction() e UnitOfWork.CommitTransaction();
    /// </summary>
    public class TransacaoContaCorrente: ITransacao
    {
        private List<Lancamento> lancamentos = null;

        public TransacaoContaCorrente()
        {
            lancamentos = new List<Lancamento>();
        }

        public bool RealizarTransacao(int operacao, ContaCorrente contaOigem, double valor, ContaCorrente contaDestino = null)
        {
            bool resultado = false;
            switch (operacao)
            {
                case Lancamento.TRANSFERENCIA:
                    if (contaDestino == null)
                        return false;

                    resultado = Transferir(contaOigem, contaDestino, valor);

                    break;
                default:
                    break;
            }

            return resultado;
        }
        private bool Transferir(ContaCorrente contaOrigem, ContaCorrente contaDestino, double valor)
        {
            bool resultado = false;

            if (lancamentos == null)
                lancamentos = new List<Lancamento>();

            ContaCorrente contaCorrenteOrigem = new ContaCorrente();
            contaCorrenteOrigem = (ContaCorrente)contaOrigem;

            Lancamento lancamentoOrigem = new Lancamento(DateTime.Now, contaOrigem, valor, Lancamento.TRANSFERENCIA);
            Lancamento lancamentoDestino = new Lancamento(DateTime.Now, contaDestino, valor, Lancamento.TRANSFERENCIA);

            if (contaOrigem.Debitar(valor))
            {
                contaDestino.Creditar(valor);
                lancamentos.Add(lancamentoOrigem);
                lancamentos.Add(lancamentoDestino);
                resultado = true;
            }





            return resultado;
        }


        private void EstornarLancamento(Lancamento lancamento)
        {
            if (lancamentos.Any())
                lancamentos.Remove(lancamento);
        }
    }
}

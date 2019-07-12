using System;
using System.Collections.Generic;
using System.Text;

namespace BancoMicrosservico.Domain.Entidade
{
    public class Lancamento
    {

        public const int DEBITO = 1;
        public const int CREDITO = 2;
        public const int TRANSFERENCIA = 4;
       

        public DateTime Data { get; set; }
        public Conta Conta { get; set; }
        public double Valor { get; set; }
        public double SaldoAnterior { get; set; }
        public int Operacao { get; set; }

        public Lancamento(DateTime data, Conta conta, double valor, int operacao)
        {
            this.Conta = conta;
            this.Data = data;
            this.Valor = valor;
            this.SaldoAnterior = conta.Saldo;
            this.Operacao = operacao;
        }


    }
}

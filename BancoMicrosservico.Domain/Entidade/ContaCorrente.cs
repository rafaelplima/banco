using System;
using System.Collections.Generic;
using System.Text;

namespace BancoMicrosservico.Domain.Entidade
{
    public  class ContaCorrente : Conta
    {
        public ContaCorrente()
        {

        }

        public ContaCorrente(Guid id, int numero, int agencia, string correntista, double valor) :
            base(id,numero,agencia, correntista, valor)
        { }


        public sealed override bool Debitar(double valor)
        {
            bool resultado = false;

            if (this.Saldo >= valor)
            {
                this.Saldo -= valor;
                resultado = true;
            }

            return resultado;
        }

      

    }
}

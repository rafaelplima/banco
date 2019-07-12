using BancoMicrosservico.Domain.Entidade;
using BancoMicrosservico.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoMicrosservico.Infrastructure.Data
{
    public class BancoRepositorio : IContaCorrenteRepositorio
    {
        private Dictionary<int, ContaCorrente> banco = new Dictionary<int, ContaCorrente>();
        public ContaCorrente Obter(int numero)
        {
            if (banco.ContainsKey(numero))
            {
                return null;
            }
            return banco[numero];
        }

        public void Salvar(ContaCorrente contaCorrente)
        {
           banco[contaCorrente.Numero] = contaCorrente;
        }
    }
}

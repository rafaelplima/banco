using System;
using System.Collections.Generic;
using System.Text;

namespace BancoMicrosservico.Aplication.Conta
{
    public class ContaCorrenteSolicitacao
    {
        public int Agencia { get; set; }
        public int Conta { get; set; }
        public string Correntista { get; set; }
        public double Valor { get; set; }
    }
}

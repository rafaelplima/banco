using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace BancoMicrosservico.Domain.Entidade
{
    public abstract class Conta : Notifiable
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }

        public int Agencia { get; set; }
        public string Correntista { get; set; }
        public double Saldo { get; set; }

        public Conta() { }

        public Conta(Guid id, int numero, int Agencia, string correntista, double valor)
        {
            this.Id=id;
            this.Numero = numero;
            this.Agencia = Agencia;
            this.Correntista = correntista;
            this.Saldo = valor;
        }

        public void Creditar(double valor)
        {
            this.Saldo += valor;
        }

        public abstract bool Debitar(double valor);

        public void Validacao()
        {
            AddNotifications(new Contract()
               .AreEquals(Agencia, 1, nameof(Agencia), "Agência inválida")
               .IsGreaterOrEqualsThan(Numero, 1, nameof(Numero), "Conta inválida")
               .IsNotNullOrEmpty(Correntista,nameof(Correntista),"Correntista inválido"));
        }

    }
}

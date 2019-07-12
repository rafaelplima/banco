using BancoMicrosservico.Domain.Entidade;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BancoMicrosservico.Domain.Test
{
    /// <summary>
    /// Por questão de tempo realizei apenas o teste debitar
    /// </summary>
    public class ContaCorrenteTeste
    {
        [Theory]
        [InlineData(1, true)]
        [InlineData(200.00, false)]
        [InlineData(40, true)]
        [InlineData(122, false)]
        public void TesteDebitoConta(double valor, bool esperado)
        {
            ContaCorrente conta = new ContaCorrente(Guid.NewGuid(),1234,5678,"Rafael ",120.00);
            var result = conta.Debitar(valor);

            result.Should().Be(esperado, $"Valor esperado deveria ser: {esperado}");

        }

    }
}

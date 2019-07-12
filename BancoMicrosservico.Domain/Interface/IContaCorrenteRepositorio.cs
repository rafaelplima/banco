using BancoMicrosservico.Domain.Entidade;

namespace BancoMicrosservico.Domain.Interface
{
    public interface IContaCorrenteRepositorio
    {

        ContaCorrente Obter(int numeroConta);
        void Salvar(ContaCorrente conta);
    }
}

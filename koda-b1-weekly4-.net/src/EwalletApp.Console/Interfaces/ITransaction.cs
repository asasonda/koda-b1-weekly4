using EwalletApp.Console.Models;

namespace EwalletApp.Console.Interfaces;

public interface ITransaction
{
    string TypeTransactionName();
    bool TransactionProcess(List<User> walletUsers, string find, List<Riwayat> riwayats);
    decimal Nominal();
}
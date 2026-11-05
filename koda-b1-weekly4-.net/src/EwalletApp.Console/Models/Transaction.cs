using System.Security.Cryptography.X509Certificates;
using EwalletApp.Console.Interfaces;

namespace EwalletApp.Console.Models;

public abstract class Transaction : ITransaction
{
    public abstract bool TransactionProcess(List<User> walletUsers, string find, List<Riwayat> riwayats);
    public abstract string TypeTransactionName();
    public abstract decimal Nominal();
}
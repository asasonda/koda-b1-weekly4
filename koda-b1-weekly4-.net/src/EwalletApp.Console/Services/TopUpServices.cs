using EwalletApp.Console.Models;

namespace EwalletApp.Console.Services;

public class TopUpServices : Transaction
{
    public decimal NominalTransactions{get; private set;}
    public override decimal Nominal()
    {
        return NominalTransactions;
    }

    public override bool TransactionProcess(List<User> walletUsers, string find, List<Riwayat> riwayats)
    {
        System.Console.WriteLine("========== TOPUP ==========");
        System.Console.WriteLine();

        System.Console.Write("Masukan nominal: ");
        NominalTransactions = Convert.ToDecimal(System.Console.ReadLine());

        if(NominalTransactions <= 0)
        {
            System.Console.WriteLine("Nominal not valid");
            return false;
        }
        
        decimal cek = walletUsers.Where(p => p.UserId.ToUpper() == find.ToUpper()).Select(p => p.GetBalance()).FirstOrDefault();
        
        decimal topUpHasil = cek + NominalTransactions;
        System.Console.WriteLine($"Balance saat ini menjadi: {topUpHasil:N0}");
        return true;
    }

    public override string TypeTransactionName()
    {
        return "TopUp";
    }
}
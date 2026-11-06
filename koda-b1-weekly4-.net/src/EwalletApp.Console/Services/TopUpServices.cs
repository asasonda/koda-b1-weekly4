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

        var cek = walletUsers.OfType<Wallet>().FirstOrDefault(p => p.UserId.Equals(find, StringComparison.OrdinalIgnoreCase));

        if(cek is null)
        {
            System.Console.WriteLine("Data tidak ditemukan");
        }

        while (true)
        {
            System.Console.Write("Masukan nominal: ");
            NominalTransactions = Convert.ToDecimal(System.Console.ReadLine());

            if(NominalTransactions <= 0)
            {
                System.Console.WriteLine("Nominal not valid");
                continue;
            }
            break;
        }
        
        try
        {
            cek.TopUp(NominalTransactions);

            riwayats.Add(new Riwayat(
                cek.UserId,
                "TopUp",
                NominalTransactions,
                "Top Up saldo"
            ));
            System.Console.WriteLine();
            System.Console.WriteLine("TopUp Berhasil");
            System.Console.WriteLine($"Saldo ditambahkan: {NominalTransactions:N0}");

            return true;
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            return false;
        }

    }
    public override string TypeTransactionName()
    {
        return "Top Up";
    }
}
using EwalletApp.Console.Models;

namespace EwalletApp.Console.Services;

public class TransferServices : Transaction
{
    public decimal NominalTransactions{get; private set;}
    public override decimal Nominal()
    {
        return NominalTransactions;
    }

    public override bool TransactionProcess(List<User> walletUsers, string find, List<Riwayat> riwayats)
    {
        System.Console.WriteLine("============= TRANSFER ==============");
        System.Console.WriteLine();

        var pengirim = walletUsers.OfType<Wallet>().FirstOrDefault(p => p.UserId.Equals(find, StringComparison.OrdinalIgnoreCase));
        
        if(pengirim is null)
        {
            System.Console.WriteLine("Sender Not Valid");
            return false;
        }

        System.Console.Write("Masukan penerima: ");
        string? tujuan = System.Console.ReadLine();

        if (string.IsNullOrWhiteSpace(tujuan))
        {
            System.Console.WriteLine("Nomor wallet tidak boleh kosong.");
            return false;
        }

        var penerima = walletUsers.OfType<Wallet>().FirstOrDefault(p => p.UserId.Equals(tujuan.Trim(),StringComparison.OrdinalIgnoreCase));

        if(penerima is null)
        {
            System.Console.WriteLine("Penerima tidak ditemukan");
            return false;
        }

        if(pengirim.UserId.Equals(penerima.UserId, StringComparison.OrdinalIgnoreCase))
        {
            System.Console.WriteLine("Tidak dapat transfer ke diri sendiri");
            return false;
        }

        while (true)
        {
            System.Console.Write("Masukan nominal: ");
            NominalTransactions = Convert.ToDecimal(System.Console.ReadLine());
            System.Console.WriteLine();

            if(NominalTransactions <= 0)
            {
                System.Console.WriteLine("Nominal not valid");
                continue;
            }
            break;
        }


        if (pengirim.GetBalance() < NominalTransactions)
        {
            System.Console.WriteLine("Saldo tidak mencukupi.");
            return false;
        }

        System.Console.WriteLine();
        System.Console.WriteLine($"Nomor Wallet Tujuan: {penerima.UserId}");
        System.Console.WriteLine($"Penerima: {penerima.Name}");
        System.Console.WriteLine($"Nominal Transfer: Rp{NominalTransactions:N0}");
        System.Console.WriteLine();

        System.Console.Write("Konfirmasi Transfer (Y/n): ");
        string? confirm = System.Console.ReadLine();
        if (!string.Equals(confirm,"Y",StringComparison.OrdinalIgnoreCase))
        {
            System.Console.WriteLine("Transfer dibatalkan.");
            return false;
        }

        try
        {
            pengirim.TransferOut(NominalTransactions);
            penerima.TransferIn(NominalTransactions);

            riwayats.Add(new Riwayat(
                pengirim.UserId,
                "Transfer Keluar",
                NominalTransactions,
                $"Transfer ke {penerima.Name}"
            ));

            riwayats.Add(new Riwayat(
                penerima.UserId,
                "Transfer Masuk",
                NominalTransactions,
                $"Transfer dari {pengirim.Name}"
            ));

            System.Console.WriteLine();
            System.Console.WriteLine("Transfer berhasil!");

            System.Console.WriteLine($"Pengirim: {pengirim.Name}");
            System.Console.WriteLine($"Penerima: {penerima.Name}");
            System.Console.WriteLine($"Nominal: Rp{NominalTransactions:N0}");
            System.Console.WriteLine($"Sisa Saldo    : Rp{pengirim.GetBalance():N0}");
            return true;
        }
        catch (ArgumentException e)
        {
            System.Console.WriteLine($"Transfer gagal: {e.Message}");
            return false;
        }
        catch (InvalidOperationException ex)
        {
            System.Console.WriteLine($"Transfer gagal: {ex.Message}");
            return false;
        }
    }

    public override string TypeTransactionName()
    {
        return "Transfer";
    }
}
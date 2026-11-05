using EwalletApp.Console.Models;

namespace EwalletApp.Console.Services;

public class MenuServices
{

    public static void GetUser(List<User> walletsUsers, int account, List<Riwayat> riwayats)
    {
        System.Console.WriteLine($"========== WALLET {walletsUsers[account-1].Name.ToUpper()} ==========");
        System.Console.WriteLine("1. Lihat Saldo");
        System.Console.WriteLine("2. Top Up");
        System.Console.WriteLine("3. Transfer");
        System.Console.WriteLine("4. Riwayat Transaksi");
        System.Console.WriteLine("5. Logout");

        System.Console.Write("Silahkan pilih: ");
        int menu = Convert.ToInt32(System.Console.ReadLine());
        System.Console.WriteLine();

        TopUpServices topUp = new();
        TransferServices transfer = new();

        string find = walletsUsers[account - 1].UserId;
        switch (menu)
        {
            case 1:
                walletsUsers[account-1].ShowAccount();
                break;
            case 2:
                topUp.TransactionProcess(walletsUsers, find, riwayats);
                break;
            case 3:
                bool success = transfer.TransactionProcess(walletsUsers, find, riwayats);

                if (!success)
                {
                    System.Console.WriteLine("Transfer gagal!");
                    return;
                }
                System.Console.WriteLine("Transfer Berhasil");

                break;
            case 4:
                System.Console.WriteLine("4");
                break;
            case 5:
                System.Console.WriteLine("exit");
                break;
            
            default:
                System.Console.WriteLine("Salah");
                return;
        }

    }
}
using EwalletApp.Console.Models;
using EwalletApp.Console.Services;

List<User> walletsUsers = [];
walletsUsers.Add(new Wallet("WAL001","Andi", 500000));
walletsUsers.Add(new Wallet("WAL002","Budi", 10500800));
walletsUsers.Add(new Wallet("WAL003","Citra", 5000000));

List<Riwayat> riwayats = [];


while (true)
{
    Console.WriteLine("========== KODA E-WALLET ==========");
    Console.WriteLine("Pilih Pengguna:");
    
    UserServices.ShowUser(walletsUsers);
    try
    {
        System.Console.Write("Pilihan: ");
        int account = Convert.ToInt32(Console.ReadLine());
        switch (account)
        {
            case 1:
                MenuServices.GetUser(walletsUsers,account,riwayats);
                break;
            case 2:
                MenuServices.GetUser(walletsUsers,account, riwayats);
                break;
            case 3:
                MenuServices.GetUser(walletsUsers,account, riwayats);
                break;
            case 4:
                System.Console.WriteLine("Exit");
                return;
            default:
            System.Console.WriteLine("Menu tidak tersedia");
                break;
        }
    }
    catch(Exception)
    {
        System.Console.WriteLine($"Error: Account tidak tersedia");
    }
}

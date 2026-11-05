using System.Collections;
using System.Security.Cryptography;
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
        
        System.Console.Write("Masukan penerima: ");
        string? penerima = System.Console.ReadLine();

        var cek = walletUsers.FirstOrDefault(cari => cari.UserId.Equals(find, StringComparison.OrdinalIgnoreCase));

        if(penerima?.ToLower() == cek?.Name.ToLower())
        {
            System.Console.WriteLine("Tidak dapat lakukan transfer ke diri sendiri");
            return false;
        }

        System.Console.Write("Masukan nominal: ");
        NominalTransactions = Convert.ToDecimal(System.Console.ReadLine());
        System.Console.WriteLine();

        if(NominalTransactions <= 0)
        {
            System.Console.WriteLine("Nominal not valid");
            return false;
        }
        
        var objekPenerima = walletUsers.Where(ambil => ambil.Name.ToLower() == penerima?.ToLower()).Select(ambil => new{
            Id = ambil.UserId,
            Nama = ambil.Name
        }).ToList();
        
        System.Console.WriteLine();
        foreach (var penerimaTf in objekPenerima)
        {
            System.Console.WriteLine($"Nomor Wallet Tujuan: {penerimaTf.Id}");
            System.Console.WriteLine($"Penerima: {penerimaTf.Nama}");
        }
        System.Console.WriteLine($"Nominal Transfer: {NominalTransactions:N0}");

        System.Console.Write("Konfirmasi Transfer (Y/n): ");
        string? confirm = System.Console.ReadLine();

        var saldo = cek?.GetBalance();
        var prosesTf = saldo - NominalTransactions;

        if(prosesTf < 0)
        {
            System.Console.WriteLine("Saldo tidak mencukupi");
            return false;
        }

        System.Console.WriteLine();
        System.Console.WriteLine($"Pengirim: {cek?.Name}");
        foreach (var item in objekPenerima)
        {
            System.Console.WriteLine($"Penerima: {item.Nama}");
        }
        System.Console.WriteLine($"Nominal: {NominalTransactions:N0}");
        System.Console.WriteLine($"Sisa Saldo: {prosesTf:N0}");
        System.Console.WriteLine();

        var ambilNamaReceiverSaja = walletUsers.Where(p => p.Name.ToLower() == penerima?.ToLower()).Select(p => p.Name).FirstOrDefault();
        riwayats.Add(new Riwayat(cek?.Name, ambilNamaReceiverSaja, NominalTransactions));

        return confirm?.ToLower() == "y";
    }

    public override string TypeTransactionName()
    {
        return "Transfer";
    }
}
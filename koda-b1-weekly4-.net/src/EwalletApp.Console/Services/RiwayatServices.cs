
using EwalletApp.Console.Models;

namespace EwalletApp.Console.Services;

public class HistoryServices
{
    public static void ShowHistory(List<Riwayat> riwayats, string userId)
    {
        var history = riwayats.Where(p => p.UserId.Equals(userId, StringComparison.OrdinalIgnoreCase)).OrderByDescending(p => p.Tanggal).ToList();

        if (history.Count == 0)
        {
            System.Console.WriteLine("Belum ada riwayat transaksi.");
            return;
        }

        System.Console.WriteLine("========== RIWAYAT TRANSAKSI ==========");
        System.Console.WriteLine("1. Semua");
        System.Console.WriteLine("2. Pemasukan");
        System.Console.WriteLine("3. Pengeluaran");

        int filter;

        while (true)
        {
            System.Console.Write("Pilih filter: ");
            if (int.TryParse(System.Console.ReadLine(), out filter) && filter >= 1 && filter <= 3)
            {
                break;
            }

            System.Console.WriteLine("Pilihan filter tidak valid.");
        }

        IEnumerable<Riwayat> filtered = history;

        if (filter == 2)
        {
            filtered = history.Where(p =>
                p.Type == "Top Up" ||
                p.Type == "Transfer Masuk"
            );
        }
        else if (filter == 3)
        {
            filtered = history.Where(p =>
                p.Type == "Transfer Keluar"
            );
        }

        System.Console.WriteLine();

        foreach (Riwayat item in filtered)
        {
            string tanda = item.Type == "Transfer Keluar" ? "-" : "+";

            System.Console.WriteLine($"{item.Type} {tanda} Rp{item.Nominal:N0}");
            System.Console.WriteLine($"Tanggal    : {item.Tanggal:dd-MM-yyyy HH:mm:ss}");
            System.Console.WriteLine($"Keterangan : {item.Keterangan}");
            System.Console.WriteLine();
        }

        decimal totalPemasukan = history.Where(p =>
                p.Type == "Top Up" ||
                p.Type == "Transfer Masuk"
            )
            .Sum(p => p.Nominal);

        decimal totalPengeluaran = history.Where(p => p.Type == "Transfer Keluar").Sum(p => p.Nominal);

        System.Console.WriteLine($"Total Pemasukan   : Rp{totalPemasukan:N0}");
        System.Console.WriteLine($"Total Pengeluaran : Rp{totalPengeluaran:N0}");
    }
}

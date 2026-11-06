
namespace EwalletApp.Console.Models;

public class Riwayat(
    string userId,
    string type,
    decimal nominal,
    string keterangan
    )
{
    public string UserId { get; private set; } = userId;
    public string Type { get; private set; } = type;
    public decimal Nominal { get; private set; } = nominal;
    public DateTime Tanggal { get; private set; } = DateTime.Now;
    public string Keterangan { get; private set; } = keterangan;
}

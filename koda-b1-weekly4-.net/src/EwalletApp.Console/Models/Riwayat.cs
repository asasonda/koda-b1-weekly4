namespace EwalletApp.Console.Models;

public class Riwayat(string nameAccountSender, string nameAccountReceiver, decimal nominal)
{
    public string NameAccountSender { get; set; } = nameAccountSender;
    public string NameAccountReceiver { get; set; } = nameAccountReceiver;
    public decimal Nominal { get; private set; } = nominal;
}
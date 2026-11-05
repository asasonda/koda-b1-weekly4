using System.ComponentModel.DataAnnotations;

namespace EwalletApp.Console.Models;

public class Wallet(
    [Required, StringLength(20)]
    string userId,
    [Required, StringLength(120)] 
    string name, 
    [Required]
    decimal balance
    ) : User(userId, name)
{
    public decimal Balance { get; private set; } = balance;

    public override decimal GetBalance()
    {
        return Balance;
    }

    public override void ShowAccount()
    {
        System.Console.WriteLine($"Nomor Wallet: {UserId}");
        System.Console.WriteLine($"Nama Pemilik: {Name}");
        System.Console.WriteLine($"Saldo: {Balance:N0}");
    }
}
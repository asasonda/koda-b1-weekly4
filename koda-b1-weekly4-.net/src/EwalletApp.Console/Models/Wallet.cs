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

    public void TopUp(decimal nominal)
    {
        if (nominal <= 0)
        {
            throw new ArgumentException("Nominal Top Up harus lebih dari 0.");
        }
        Balance += nominal;
    }

    public void TransferOut(decimal nominal)
    {
        if (nominal <= 0)
        {
            throw new ArgumentException("Nominal transfer harus lebih dari 0.");
        }

        if (Balance < nominal)
        {
            throw new InvalidOperationException("Saldo tidak mencukupi.");
        }
        Balance -= nominal;
    }

    public void TransferIn(decimal nominal)
    {
        if (nominal <= 0)
        {
            throw new ArgumentException("Nominal transfer harus lebih dari 0.");
        }
        Balance += nominal;
    }

    public override void ShowAccount()
    {
        System.Console.WriteLine($"Nomor Wallet: {UserId}");
        System.Console.WriteLine($"Nama Pemilik: {Name}");
        System.Console.WriteLine($"Saldo: {Balance:N0}");
    }
}
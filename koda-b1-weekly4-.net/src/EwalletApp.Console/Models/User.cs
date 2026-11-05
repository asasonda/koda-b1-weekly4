namespace EwalletApp.Console.Models;

public abstract class User
{
    public string UserId {get; private set;}
    public string Name {get; set;}

    public User(string userId, string name)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            throw new ArgumentException("UserId is required", nameof(userId));
        }
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name is required", nameof(name));
        }

        UserId = userId;
        Name = name;
    }
    public abstract decimal GetBalance();
    public abstract void ShowAccount();

}
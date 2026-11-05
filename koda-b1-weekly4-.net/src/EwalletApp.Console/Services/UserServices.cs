using EwalletApp.Console.Models;

namespace EwalletApp.Console.Services;

public class UserServices
{
    public static void ShowUser(List<User> walletsUsers)
    {
        var i = 0;
        foreach (User item in walletsUsers)
        {
            System.Console.WriteLine($"{i+1}. {item.Name}");
            i++;
        }
        System.Console.WriteLine("4. Exit");
    }

}
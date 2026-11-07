package com.ewallet;

import java.io.Console;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

import com.ewallet.Models.User;
import com.ewallet.Models.Wallet;
import com.ewallet.Models.Riwayat;
import com.ewallet.Services.MenuServices;
import com.ewallet.Services.UserServices;

public class App 
{
    public static void main( String[] args )
    {
        Scanner input = new Scanner(System.in);

        List<User> walletsUsers = new ArrayList<>();
        walletsUsers.add(new Wallet("WAL001","Andi", 500000));
        walletsUsers.add(new Wallet("WAL002","Budi", 10500800));
        walletsUsers.add(new Wallet("WAL003","Citra", 5000000));

        List<Riwayat> riwayats = new ArrayList<>();

        System.out.println("========== KODA E-WALLET ==========");
        System.out.println("Pilih Pengguna:");
        
        UserServices.ShowUser(walletsUsers);
        try
        {
            System.out.print("Pilihan: ");
            int account = input.nextInt();
            switch (account)
            {
                case 1:
                    MenuServices.GetUser(walletsUsers,account, riwayats, input);
                    break;
                case 2:
                    MenuServices.GetUser(walletsUsers,account, riwayats, input);
                    break;
                case 3:
                    MenuServices.GetUser(walletsUsers,account, riwayats, input);
                    break;
                case 4:
                    System.out.println("Exit");
                    return;
                default:
                    System.out.println("Menu tidak tersedia");
                    break;
            }
        }
        catch(Exception e)
        {
            System.out.println("Error: Account tidak tersedia " + e.getMessage());
        }
    }
}

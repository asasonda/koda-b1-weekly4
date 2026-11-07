package com.ewallet.Services;
import com.ewallet.Models.*;

import java.util.List;
import java.util.Scanner;

public class MenuServices
{

    public static void GetUser(List<User> walletsUsers, int account, List<Riwayat> riwayats, Scanner input)
    {
        User userSaatIni = walletsUsers.get(account - 1);
        while (true)
        {
            System.out.println("========== WALLET " + userSaatIni.getName().toUpperCase() +"==========");
            System.out.println("1. Lihat Saldo");
            System.out.println("2. Top Up");
            System.out.println("3. Transfer");
            System.out.println("4. Riwayat Transaksi");
            System.out.println("5. Logout");

            System.out.print("Silahkan pilih: ");
            int menu = input.nextInt();
            System.out.println();

            TopUpServices topUp = new TopUpServices();
            TransferServices transfer = new TransferServices();
            RiwayatServices riwayat = new RiwayatServices();

            String find = userSaatIni.getUserId();
            switch (menu)
            {
                case 1:
                    userSaatIni.ShowAccount();
                    break;
                case 2:
                    try {
                        topUp.TransactionProcess(walletsUsers, find, riwayats, input);
                    } catch (Exception e) {
                        System.out.println("TopUp gagal!");
                        return;
                    }
                    break;
                case 3:
                    try {
                        transfer.TransactionProcess(walletsUsers, find, riwayats, input);
                    } catch (Exception e) {
                        System.out.println("Transfer gagal!");
                        return;
                    }
                    break;
                case 4:
                    riwayat.TampilkanRiwayat(riwayats, find);
                    break;
                case 5:
                    System.out.println("Logout");
                    return;
                
                default:
                    System.out.println("salah");
                    break;
            }
        }

    }
}
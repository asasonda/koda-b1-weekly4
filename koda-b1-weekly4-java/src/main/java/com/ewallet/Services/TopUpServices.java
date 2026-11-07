package com.ewallet.Services;

import java.text.NumberFormat;
import java.time.LocalDateTime;
import java.util.List;
import java.util.Locale;
import java.util.Scanner;

import com.ewallet.Models.Riwayat;
import com.ewallet.Models.Transaction;
import com.ewallet.Models.User;
import com.ewallet.Models.Wallet;

public class TopUpServices extends Transaction
{
    public double nominalTransactions;

    @Override
    public double Nominal()
    {
        return nominalTransactions;
    }

    @Override 
    public boolean TransactionProcess(List<User> walletUsers, String find, List<Riwayat> riwayats, Scanner input)
    {
        NumberFormat rupiah = NumberFormat.getCurrencyInstance(new Locale("id", "ID"));

        System.out.println("========== TOPUP ==========");
        System.out.println();

        Wallet cek = walletUsers.stream().filter(p -> p instanceof Wallet).map(p -> (Wallet) p).filter(p -> p.getUserId().equalsIgnoreCase(find)).findFirst().orElse(null);

        if(cek == null)
        {
            System.out.println("Data tidak ditemukan");
        }

        while (true)
        {
            System.out.print("Masukan nominal: ");
            nominalTransactions = input.nextDouble();

            if(nominalTransactions <= 0)
            {
                System.out.println("Nominal not valid");
                continue;
            }
            break;
        }
        
        try
        {
            cek.TopUp(nominalTransactions);

            riwayats.add(new Riwayat(
                cek.getUserId(),
                "TopUp",
                nominalTransactions,
                LocalDateTime.now(),
                "Top Up saldo"
            ));
            System.out.println();
            System.out.println("TopUp Berhasil");
            System.out.println("Saldo ditambahkan: "+ rupiah.format(nominalTransactions));

            return true;
        }
        catch (Exception e)
        {
            System.out.println(e.getMessage());
            return false;
        }
    }

    @Override 
    public String TypeTransactionName()
    {
        return "Top Up";
    }
}
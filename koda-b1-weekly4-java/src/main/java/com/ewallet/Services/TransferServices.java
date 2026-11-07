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

public class TransferServices extends Transaction
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

        System.out.println("============= TRANSFER ==============");
        System.out.println();

        Wallet pengirim = walletUsers.stream().filter(p -> p instanceof Wallet).map(p -> (Wallet) p).filter(p -> p.getUserId().equalsIgnoreCase(find)).findFirst().orElse(null);
        
        if(pengirim == null)
        {
            System.out.println("Sender Not Valid");
            return false;
        }

        System.out.print("Masukan penerima ID: ");
        String tujuan = input.next();

        if (tujuan == null || tujuan.isBlank())
        {
            System.out.println("Nomor wallet tidak boleh kosong.");
            return false;
        }

        Wallet penerima = walletUsers.stream().filter(p -> p instanceof Wallet).map(p -> (Wallet) p).filter(p -> p.getUserId().equalsIgnoreCase(tujuan.trim())).findFirst().orElse(null);

        if(penerima == null)
        {
            System.out.println("Penerima tidak ditemukan");
            return false;
        }

        if(pengirim.getUserId().equalsIgnoreCase(penerima.getUserId()))
        {
            System.out.println("Tidak dapat transfer ke diri sendiri");
            return false;
        }

        while (true)
        {
            System.out.print("Masukan nominal: ");
            nominalTransactions = input.nextDouble();
            System.out.println();

            if(nominalTransactions <= 0)
            {
                System.out.println("Nominal not valid");
                continue;
            }
            break;
        }


        if (pengirim.GetBalance() < nominalTransactions)
        {
            System.out.println("Saldo tidak mencukupi");
            return false;
        }

        System.out.println();
        System.out.println("Nomor Wallet Tujuan: "+ penerima.getUserId());
        System.out.println("Penerima: " + penerima.getName());
        System.out.println("Nominal Transfer: Rp" + rupiah.format(nominalTransactions));
        System.out.println();

        System.out.print("Konfirmasi Transfer (Y/n): ");
        String confirm = input.next();

        if (!confirm.equalsIgnoreCase("Y"))
        {
            System.out.println("Transfer dibatalkan.");
            return false;
        }

        try
        {
            pengirim.TransferOut(nominalTransactions);
            penerima.TransferIn(nominalTransactions);

            riwayats.add(new Riwayat(
                pengirim.getUserId(),
                "Transfer Keluar",
                nominalTransactions,
                LocalDateTime.now(),
                "Transfer ke "+ penerima.getName()
            ));

            riwayats.add(new Riwayat(
                penerima.getUserId(),
                "Transfer Masuk",
                nominalTransactions,
                LocalDateTime.now(),
                "Transfer dari " +pengirim.getName()
            ));

            System.out.println();
            System.out.println("Transfer berhasil!");

            System.out.println("Pengirim: "+ pengirim.getName());
            System.out.println("Penerima: "+ penerima.getName());
            System.out.println("Nominal: Rp" + rupiah.format(nominalTransactions));
            System.out.println("Sisa Saldo: Rp"+ rupiah.format(pengirim.GetBalance()));
            return true;
        }
        catch (IllegalStateException  e)
        {
            System.out.println("Transfer gagal: " + e.getMessage());
            return false;
        }
        catch (Exception ex)
        {
            System.out.println("Transfer gagal: "+ ex.getMessage());
            return false;
        }
    }

    @Override 
    public String TypeTransactionName()
    {
        return "Transfer";
    }
}
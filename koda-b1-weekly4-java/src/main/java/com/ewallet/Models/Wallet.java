package com.ewallet.Models;

import java.math.BigDecimal;
import java.text.NumberFormat;
import java.util.Locale;

public class Wallet extends User
{
    private String userId;
    private String name;
    private double balance;

    public Wallet(String userId, String name, double balance)
    {
        super(userId, name);
        if (balance < 0) {
            throw new IllegalArgumentException("Balance tidak valid");
        }
        this.balance = balance;
    }

    @Override 
    public double GetBalance()
    {
        return balance;
    }


    public void TopUp(double nominal)
    {
        if (nominal <= 0)
        {
            throw new IllegalArgumentException("Nominal Top Up harus lebih dari 0");
        }
        balance += nominal;
    }

    public void TransferOut(double nominal)
    {
        if (nominal <= 0)
        {
            throw new IllegalArgumentException("Nominal transfer harus lebih dari 0");
        }

        if (balance < nominal)
        {
            throw new IllegalStateException("Saldo tidak mencukupi");
        }
        balance -= nominal;
    }

    public void TransferIn(double nominal)
    {
        if (nominal <= 0)
        {
            throw new IllegalArgumentException("Nominal transfer harus lebih dari 0");
        }
        balance += nominal;
    }

    @Override 
    public void ShowAccount()
    {
        NumberFormat rupiah = NumberFormat.getCurrencyInstance(new Locale("id", "ID"));
        System.out.println("Nomor Wallet: "+ getUserId());
        System.out.println("Nama Pemilik: "+ getName());
        System.out.println("Saldo: Rp."+ rupiah.format(balance));
        System.out.println();
    }
}
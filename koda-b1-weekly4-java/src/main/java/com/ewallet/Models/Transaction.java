package com.ewallet.Models;

import java.util.List;
import java.util.Scanner;

import com.ewallet.Interfaces.ITransactionable;

public abstract class Transaction implements ITransactionable
{
    @Override 
    public abstract boolean TransactionProcess(List<User> walletUsers, String find, List<Riwayat> riwayats, Scanner input);

    @Override 
    public abstract String TypeTransactionName();

    @Override 
    public abstract double Nominal();
}
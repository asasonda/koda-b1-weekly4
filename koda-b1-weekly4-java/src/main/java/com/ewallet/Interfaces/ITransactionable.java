package com.ewallet.Interfaces;

import java.util.List;
import java.util.Scanner;

import com.ewallet.Models.Riwayat;
import com.ewallet.Models.User;

public interface ITransactionable {
    String TypeTransactionName();
    boolean TransactionProcess(List<User> walletUsers, String find, List<Riwayat> riwayats, Scanner input);
    double Nominal();
}
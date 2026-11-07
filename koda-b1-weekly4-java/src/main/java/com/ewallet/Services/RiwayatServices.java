package com.ewallet.Services;

import java.text.NumberFormat;
import java.time.format.DateTimeFormatter;
import java.util.List;
import java.util.Locale;

import com.ewallet.Models.Riwayat;

public class RiwayatServices {

    public void TampilkanRiwayat(List<Riwayat> riwayats, String userId) {

        NumberFormat rupiah = NumberFormat.getCurrencyInstance(new Locale("id", "ID"));
        DateTimeFormatter tanggalFormat = DateTimeFormatter.ofPattern("dd-MM-yyyy HH:mm:ss");

        System.out.println("============= RIWAYAT TRANSAKSI ==============");
        System.out.println();

        List<Riwayat> history = riwayats.stream().filter(r -> r.getUserId().equalsIgnoreCase(userId)).toList();

        if (history.isEmpty()) {
            System.out.println("Belum ada riwayat transaksi.");
            return;
        }

        for (Riwayat item : history) {
            System.out.println("Jenis Transaksi : " + item.getType());
            System.out.println("Nominal         : " + rupiah.format(item.getNominal()));
            System.out.println("Tanggal         : " + item.getTanggal());
            System.out.println("Keterangan      : " + item.getKeterangan());
            System.out.println("----------------------------------------------");
        }

        double pemasukan = history.stream().filter(p -> p.getType().equalsIgnoreCase("Transfer Masuk") || p.getType().equalsIgnoreCase("TopUp")).mapToDouble(Riwayat::getNominal).sum();
        double pengeluaran = history.stream().filter(p -> p.getType().equalsIgnoreCase("Transfer Keluar")).mapToDouble(Riwayat::getNominal).sum();

        System.out.println();
        System.out.println("============= TOTAL TRANSAKSI ==============");
        System.out.println("Total Pemasukan: " + rupiah.format(pemasukan));
        System.out.println("Total Pengeluaran: " + rupiah.format(pengeluaran));
        System.out.println("============================================");
    }
}
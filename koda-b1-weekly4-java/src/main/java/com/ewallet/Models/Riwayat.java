package com.ewallet.Models;
import java.time.LocalDateTime;

public class Riwayat{
    private String userId;
    private String type;
    private double nominal;
    private LocalDateTime tanggal;
    private String keterangan;

    public Riwayat (String userId, String type, double nominal, LocalDateTime tanggal, String keterangan){
        this.userId = userId;
        this.type = type;
        this.nominal = nominal;
        this.tanggal = tanggal;
        this.keterangan = keterangan;
    }

    public String getUserId() {
        return userId;
    }

    public String getType() {
        return type;
    }

    public double getNominal() {
        return nominal;
    }

    public LocalDateTime getTanggal() {
        return tanggal;
    }

    public String getKeterangan() {
        return keterangan;
    }
}

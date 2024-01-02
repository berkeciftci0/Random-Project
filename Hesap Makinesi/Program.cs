using System;
using System.Collections.Generic;

class Kitap
{
    public required string Adi { get; set; }
    public bool OduncAlindiMi { get; set; }
}

class KütüphaneYönetimSistemi
{
    private List<Kitap> kütüphane;

    public KütüphaneYönetimSistemi()
    {
        kütüphane = new List<Kitap>();
    }

    public void KitapEkle(string kitapAdi)
    {
        Kitap yeniKitap = new Kitap { Adi = kitapAdi, OduncAlindiMi = false };
        kütüphane.Add(yeniKitap);
        Console.WriteLine($"{kitapAdi} kütüphaneye eklendi.\n");
    }

    public void KitaplariListele()
    {
        Console.WriteLine("Kütüphanedeki Kitaplar:");
        foreach (var kitap in kütüphane)
        {
            Console.WriteLine($"{kitap.Adi} - {(kitap.OduncAlindiMi ? "Ödünç Alındı" : "Müsait")}");
        }
        Console.WriteLine();
    }

    public void KitapOduncAl(string kitapAdi)
    {
        Kitap kitap = kütüphane.Find(k => k.Adi.Equals(kitapAdi, StringComparison.OrdinalIgnoreCase));

        if (kitap != null && !kitap.OduncAlindiMi)
        {
            kitap.OduncAlindiMi = true;
            Console.WriteLine($"{kitapAdi} ödünç alındı.\n");
        }
        else
        {
            Console.WriteLine($"{kitapAdi} kütüphanede bulunamadı veya ödünç alınmış.\n");
        }
    }

    public void KitapIadeEt(string kitapAdi)
    {
        Kitap kitap = kütüphane.Find(k => k.Adi.Equals(kitapAdi, StringComparison.OrdinalIgnoreCase));

        if (kitap != null && kitap.OduncAlindiMi)
        {
            kitap.OduncAlindiMi = false;
            Console.WriteLine($"{kitapAdi} iade edildi.\n");
        }
        else
        {
            Console.WriteLine($"{kitapAdi} kütüphanede bulunamadı veya zaten iade edilmiş.\n");
        }
    }
}

class Program
{
    static void Main()
    {
        KütüphaneYönetimSistemi kütüphaneSistemi = new KütüphaneYönetimSistemi();

        while (true)
        {
            Console.WriteLine("Kütüphane Yönetim Sistemi");
            Console.WriteLine("1. Kitap Ekle");
            Console.WriteLine("2. Kitapları Listele");
            Console.WriteLine("3. Kitap Ödünç Al");
            Console.WriteLine("4. Kitap İade Et");
            Console.WriteLine("5. Çıkış");
            Console.Write("Seçiminiz: ");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    Console.Write("Eklemek istediğiniz kitabın adını girin: ");
                    string kitapAdi = Console.ReadLine();
                    kütüphaneSistemi.KitapEkle(kitapAdi);
                    break;
                case "2":
                    kütüphaneSistemi.KitaplariListele();
                    break;
                case "3":
                    Console.Write("Ödünç almak istediğiniz kitabın adını girin: ");
                    string oduncAlinanKitap = Console.ReadLine();
                    kütüphaneSistemi.KitapOduncAl(oduncAlinanKitap);
                    break;
                case "4":
                    Console.Write("İade etmek istediğiniz kitabın adını girin: ");
                    string iadeEdilenKitap = Console.ReadLine();
                    kütüphaneSistemi.KitapIadeEt(iadeEdilenKitap);
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
                    break;
            }
        }
    }
}

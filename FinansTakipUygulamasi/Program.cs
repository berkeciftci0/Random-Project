using System;
using System.Collections.Generic;

class FinansTakipUygulamasi
{
    static List<GelirGiderKaydi> finansKayitlari = new List<GelirGiderKaydi>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Finans Takip Uygulaması");
            Console.WriteLine("1. Gelir Ekle");
            Console.WriteLine("2. Gider Ekle");
            Console.WriteLine("3. Bütçe Durumu");
            Console.WriteLine("4. Çıkış");
            Console.Write("Seçiminiz: ");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    GelirEkle();
                    break;
                case "2":
                    GiderEkle();
                    break;
                case "3":
                    ButceDurumuGoster();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
                    break;
            }
        }
    }

    static void GelirEkle()
    {
        Console.Write("Gelir miktarını girin: ");
        double miktar = Convert.ToDouble(Console.ReadLine());

        Console.Write("Gelir açıklamasını girin: ");
        string aciklama = Console.ReadLine();

        GelirGiderKaydi gelirKaydi = new GelirGiderKaydi(miktar, aciklama, true);
        finansKayitlari.Add(gelirKaydi);

        Console.WriteLine("Gelir kaydı eklendi.\n");
    }

    static void GiderEkle()
    {
        Console.Write("Gider miktarını girin: ");
        double miktar = Convert.ToDouble(Console.ReadLine());

        Console.Write("Gider açıklamasını girin: ");
        string aciklama = Console.ReadLine();

        GelirGiderKaydi giderKaydi = new GelirGiderKaydi(miktar, aciklama, false);
        finansKayitlari.Add(giderKaydi);

        Console.WriteLine("Gider kaydı eklendi.\n");
    }

    static void ButceDurumuGoster()
    {
        double toplamGelir = 0;
        double toplamGider = 0;

        Console.WriteLine("Finans Durumu");
        Console.WriteLine("------------------------------");

        foreach (var kayit in finansKayitlari)
        {
            Console.WriteLine($"{kayit.Aciklama}: {kayit.Miktar} {(kayit.IsGelir ? "Gelir" : "Gider")}");

            if (kayit.IsGelir)
                toplamGelir += kayit.Miktar;
            else
                toplamGider += kayit.Miktar;
        }

        Console.WriteLine("------------------------------");
        Console.WriteLine($"Toplam Gelir: {toplamGelir}");
        Console.WriteLine($"Toplam Gider: {toplamGider}");
        Console.WriteLine($"Bakiye: {toplamGelir - toplamGider}\n");
    }
}

class GelirGiderKaydi
{
    public double Miktar { get; }
    public string Aciklama { get; }
    public bool IsGelir { get; }

    public GelirGiderKaydi(double miktar, string aciklama, bool isGelir)
    {
        Miktar = miktar;
        Aciklama = aciklama;
        IsGelir = isGelir;
    }
}

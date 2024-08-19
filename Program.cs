Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("Günlük Uygulamasına Hoşgeldiniz!");

while (true)
{
    Console.WriteLine("[1]-Bugünün yazılarını yaz");
    Console.WriteLine("[2]-Geçmiş yazıları oku");
    Console.WriteLine("[3]-Geçmiş yazı sil");
    Console.Write("Seçiminiz > ");
    int girdi = Convert.ToInt32(Console.ReadLine());
    if (girdi == 1)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        DateTime bugun = DateTime.Today;
        string tarihFormati = bugun.ToString("dd-MM-yyyy");
        if (!Directory.Exists("Veriler"))
        {
            Directory.CreateDirectory("Veriler");
        }
        string dosyaAdi = "Veriler\\" + tarihFormati + ".txt";
        Console.Write("Yazınız:");
        string metin = Console.ReadLine();
        File.AppendAllText(dosyaAdi, metin);
        Console.WriteLine("Başarıyla yazıldı.");
    }


    if (girdi == 2)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        string klasorYolu = "Veriler";
        string[] dosyaListesi = Directory.GetFiles(klasorYolu);

        Console.WriteLine("Mevcut tarihler:");
        for (int i = 0; i < dosyaListesi.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileNameWithoutExtension(dosyaListesi[i])}");
        }

        Console.Write("Hangisini açmak istersiniz (dosya numarasını girin): ");
        int dosyaGirdisi = Convert.ToInt32(Console.ReadLine());

        if (dosyaGirdisi >= 1 && dosyaGirdisi <= dosyaListesi.Length)
        {
            string secilenDosyaYolu = dosyaListesi[dosyaGirdisi - 1];
            string gunlukMetin = File.ReadAllText(secilenDosyaYolu);
            Console.WriteLine("Dosya İçeriği:\n" + gunlukMetin);
        }
        else
        {
            Console.WriteLine("Geçersiz dosya numarası.");
        }

    }


    if (girdi == 3)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        string klasorYolu = "Veriler";
        string[] dosyaListesi = Directory.GetFiles(klasorYolu);

        Console.WriteLine("Mevcut tarihler:");
        for (int i = 0; i < dosyaListesi.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileNameWithoutExtension(dosyaListesi[i])}");
        }

        Console.Write("Hangisini silmek istersiniz (dosya numarasını girin): ");
        int dosyaGirdisi = Convert.ToInt32(Console.ReadLine());

        if (dosyaGirdisi >= 1 && dosyaGirdisi <= dosyaListesi.Length)
        {
            string secilenDosyaYolu = dosyaListesi[dosyaGirdisi - 1];
            File.Delete(secilenDosyaYolu);
            Console.WriteLine("Tarih başarıyla silindi.");
        }
        else
        {
            Console.WriteLine("Geçersiz dosya numarası.");
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace GoruntuIsleme1._0
{
    public partial class Form1 : Form
    {
        Bitmap girisResmi;




        private Bitmap ConvertToGrayscale(Bitmap source)
        {
            Bitmap grayBitmap = new Bitmap(source.Width, source.Height);

            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color originalColor = source.GetPixel(x, y);
                    int grayValue = (int)(originalColor.R * 0.3 + originalColor.G * 0.59 + originalColor.B * 0.11);
                    Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);
                    grayBitmap.SetPixel(x, y, grayColor);
                }
            }

            return grayBitmap;
        }
        private Bitmap BinaryDonusum(Bitmap kaynak, int esikDegeri)
        {
            Bitmap binaryResim = new Bitmap(kaynak.Width, kaynak.Height);

            for (int y = 0; y < kaynak.Height; y++)
            {
                for (int x = 0; x < kaynak.Width; x++)
                {
                    // Pikselin rengini al
                    Color pixelRenk = kaynak.GetPixel(x, y);

                    // Pikselin gri değerini hesapla
                    int griDeger = (pixelRenk.R + pixelRenk.G + pixelRenk.B) / 3;

                    // Gri değeri eşik ile karşılaştır
                    if (griDeger >= esikDegeri)
                    {
                        // Gri değer eşikten büyükse beyaz yap
                        binaryResim.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        // Gri değer eşikten küçükse siyah yap
                        binaryResim.SetPixel(x, y, Color.Black);
                    }
                }
            }

            return binaryResim;
        }
        private Bitmap GoruntuDonusum(Bitmap kaynak, float aciDerece)
        {
            // Görüntü boyutlarını al
            int width = kaynak.Width;
            int height = kaynak.Height;

            // Yeni bitmap (dönüştürülmüş resim için)
            Bitmap donmusResim = new Bitmap(width, height);

            // Açıyı dereceden radyana çevir
            double aciRadyan = aciDerece * Math.PI / 180.0;

            // Piksel döndürme işlemi
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Dönüşüm hesaplamaları
                    int xYeni = (int)((x - width / 2) * Math.Cos(aciRadyan) - (y - height / 2) * Math.Sin(aciRadyan) + width / 2);
                    int yYeni = (int)((x - width / 2) * Math.Sin(aciRadyan) + (y - height / 2) * Math.Cos(aciRadyan) + height / 2);

                    // Yeni koordinatların geçerli olup olmadığını kontrol et
                    if (xYeni >= 0 && xYeni < width && yYeni >= 0 && yYeni < height)
                    {
                        // Eski pikselin rengini al ve yeni pikseli ayarla
                        Color eskiRenk = kaynak.GetPixel(x, y);
                        donmusResim.SetPixel(xYeni, yYeni, eskiRenk);
                    }
                }
            }

            return donmusResim;
        }
        private Bitmap GoruntuKirp(Bitmap kaynak, int x, int y, int genislik, int yukseklik)
        {
            // Kırpılacak alanın boyutlarına uygun yeni bir bitmap oluştur
            Bitmap kirpilmisResim = new Bitmap(genislik, yukseklik);

            // Yeni resme piksel piksel kopyalama işlemi
            for (int i = 0; i < yukseklik; i++)
            {
                for (int j = 0; j < genislik; j++)
                {
                    // Kaynak resmin belirtilen koordinatındaki pikseli al
                    Color pixelRenk = kaynak.GetPixel(x + j, y + i);

                    // Yeni resme bu pikseli yerleştir
                    kirpilmisResim.SetPixel(j, i, pixelRenk);
                }
            }

            return kirpilmisResim;
        }
        private Bitmap GoruntuYakalastirVeyaUzaklastir(Bitmap kaynak, float oran)
        {
            if (kaynak == null || oran <= 0)
                return null;

            int yeniGenislik = (int)(kaynak.Width * oran);
            int yeniYukseklik = (int)(kaynak.Height * oran);

            Bitmap yeniResim = new Bitmap(yeniGenislik, yeniYukseklik);

            for (int y = 0; y < yeniYukseklik; y++)
            {
                for (int x = 0; x < yeniGenislik; x++)
                {
                    int eskiX = (int)(x / oran);
                    int eskiY = (int)(y / oran);

                    // sınır kontrolü
                    if (eskiX < kaynak.Width && eskiY < kaynak.Height)
                    {
                        Color renk = kaynak.GetPixel(eskiX, eskiY);
                        yeniResim.SetPixel(x, y, renk);
                    }
                }
            }

            return yeniResim;
        }
        private Bitmap RenkUzayiDonusumuHueGorsel(Bitmap kaynak)
        {
            Bitmap yeniResim = new Bitmap(kaynak.Width, kaynak.Height);

            for (int y = 0; y < kaynak.Height; y++)
            {
                for (int x = 0; x < kaynak.Width; x++)
                {
                    Color renk = kaynak.GetPixel(x, y);
                    int r = renk.R;
                    int g = renk.G;
                    int b = renk.B;

                    // RGB -> HSV dönüşümü
                    float rf = r / 255f;
                    float gf = g / 255f;
                    float bf = b / 255f;

                    float max = Math.Max(rf, Math.Max(gf, bf));
                    float min = Math.Min(rf, Math.Min(gf, bf));
                    float delta = max - min;

                    float h = 0;

                    if (delta == 0)
                        h = 0;
                    else if (max == rf)
                        h = 60 * (((gf - bf) / delta) % 6);
                    else if (max == gf)
                        h = 60 * (((bf - rf) / delta) + 2);
                    else if (max == bf)
                        h = 60 * (((rf - gf) / delta) + 4);

                    if (h < 0)
                        h += 360;

                    // HSV -> RGB dönüşümü (sadece Hue ile)
                    float s = 1;    // tam doygunluk
                    float v = 1;    // tam parlaklık

                    float c = v * s;
                    float x2 = c * (1 - Math.Abs((h / 60) % 2 - 1));
                    float m = v - c;

                    float r1 = 0, g1 = 0, b1 = 0;

                    if (h < 60)
                    {
                        r1 = c; g1 = x2; b1 = 0;
                    }
                    else if (h < 120)
                    {
                        r1 = x2; g1 = c; b1 = 0;
                    }
                    else if (h < 180)
                    {
                        r1 = 0; g1 = c; b1 = x2;
                    }
                    else if (h < 240)
                    {
                        r1 = 0; g1 = x2; b1 = c;
                    }
                    else if (h < 300)
                    {
                        r1 = x2; g1 = 0; b1 = c;
                    }
                    else
                    {
                        r1 = c; g1 = 0; b1 = x2;
                    }

                    int rFinal = (int)((r1 + m) * 255);
                    int gFinal = (int)((g1 + m) * 255);
                    int bFinal = (int)((b1 + m) * 255);

                    Color yeniRenk = Color.FromArgb(rFinal, gFinal, bFinal);
                    yeniResim.SetPixel(x, y, yeniRenk);
                }
            }

            return yeniResim;
        }
        private Bitmap GoruntuCikarma(Bitmap img1, Bitmap img2)
        {
            // Giriş görüntüleri aynı boyutta mı kontrol et
            int genislik = Math.Min(img1.Width, img2.Width);
            int yukseklik = Math.Min(img1.Height, img2.Height);

            Bitmap sonuc = new Bitmap(genislik, yukseklik);

            for (int y = 0; y < yukseklik; y++)
            {
                for (int x = 0; x < genislik; x++)
                {
                    Color renk1 = img1.GetPixel(x, y);
                    Color renk2 = img2.GetPixel(x, y);

                    int r = Math.Max(0, renk1.R - renk2.R);
                    int g = Math.Max(0, renk1.G - renk2.G);
                    int b = Math.Max(0, renk1.B - renk2.B);

                    sonuc.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return sonuc;
        }
        private Bitmap GoruntuCarpma(Bitmap resim1, Bitmap resim2)
        {
            int genislik = resim1.Width;
            int yukseklik = resim1.Height;

            Bitmap sonuc = new Bitmap(genislik, yukseklik);

            for (int y = 0; y < yukseklik; y++)
            {
                for (int x = 0; x < genislik; x++)
                {
                    Color renk1 = resim1.GetPixel(x, y);
                    Color renk2 = resim2.GetPixel(x, y);

                    int r = Math.Min(255, (renk1.R * renk2.R) / 255);
                    int g = Math.Min(255, (renk1.G * renk2.G) / 255);
                    int b = Math.Min(255, (renk1.B * renk2.B) / 255);

                    sonuc.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return sonuc;
        }
        private Bitmap KontrastAzalt(Bitmap kaynak, float kontrastFaktor)
        {
            Bitmap sonuc = new Bitmap(kaynak.Width, kaynak.Height);

            for (int y = 0; y < kaynak.Height; y++)
            {
                for (int x = 0; x < kaynak.Width; x++)
                {
                    Color piksel = kaynak.GetPixel(x, y);

                    // Ortalama gri değeri referans alınır
                    int ortalama = 128;

                    int r = (int)((piksel.R - ortalama) * kontrastFaktor + ortalama);
                    int g = (int)((piksel.G - ortalama) * kontrastFaktor + ortalama);
                    int b = (int)((piksel.B - ortalama) * kontrastFaktor + ortalama);

                    // Renk değerlerini 0-255 arasında sınırla
                    r = Math.Min(255, Math.Max(0, r));
                    g = Math.Min(255, Math.Max(0, g));
                    b = Math.Min(255, Math.Max(0, b));

                    sonuc.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return sonuc;
        }
        private Bitmap MedianFiltre(Bitmap kaynak, int maskeBoyutu = 3)
        {
            Bitmap sonuc = new Bitmap(kaynak.Width, kaynak.Height);
            int offset = maskeBoyutu / 2;

            for (int y = offset; y < kaynak.Height - offset; y++)
            {
                for (int x = offset; x < kaynak.Width - offset; x++)
                {
                    List<byte> RList = new List<byte>();
                    List<byte> GList = new List<byte>();
                    List<byte> BList = new List<byte>();

                    // Komşu pikselleri al
                    for (int j = -offset; j <= offset; j++)
                    {
                        for (int i = -offset; i <= offset; i++)
                        {
                            Color renk = kaynak.GetPixel(x + i, y + j);
                            RList.Add(renk.R);
                            GList.Add(renk.G);
                            BList.Add(renk.B);
                        }
                    }

                    // Ortanca değeri bul
                    RList.Sort();
                    GList.Sort();
                    BList.Sort();
                    byte r = RList[RList.Count / 2];
                    byte g = GList[GList.Count / 2];
                    byte b = BList[BList.Count / 2];

                    sonuc.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return sonuc;
        }
        private Bitmap CiftEşiklemeUygula(Bitmap kaynak, int altEsik, int ustEsik)
        {
            Bitmap sonuc = new Bitmap(kaynak.Width, kaynak.Height);

            for (int y = 0; y < kaynak.Height; y++)
            {
                for (int x = 0; x < kaynak.Width; x++)
                {
                    Color renk = kaynak.GetPixel(x, y);
                    int gri = (renk.R + renk.G + renk.B) / 3;

                    if (gri < altEsik)
                        sonuc.SetPixel(x, y, Color.Black);
                    else if (gri > ustEsik)
                        sonuc.SetPixel(x, y, Color.White);
                    else
                        sonuc.SetPixel(x, y, Color.Gray);
                }
            }

            return sonuc;
        }
        private Bitmap KenarBulSobel(Bitmap kaynak)
        {
            int[,] sobelX = new int[,] {
        { -1, 0, 1 },
        { -2, 0, 2 },
        { -1, 0, 1 }
    };

            int[,] sobelY = new int[,] {
        { -1, -2, -1 },
        {  0,  0,  0 },
        {  1,  2,  1 }
    };

            Bitmap sonuc = new Bitmap(kaynak.Width, kaynak.Height);

            for (int y = 1; y < kaynak.Height - 1; y++)
            {
                for (int x = 1; x < kaynak.Width - 1; x++)
                {
                    int gx = 0, gy = 0;

                    for (int j = -1; j <= 1; j++)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            Color renk = kaynak.GetPixel(x + i, y + j);
                            int gri = (renk.R + renk.G + renk.B) / 3;

                            gx += gri * sobelX[j + 1, i + 1];
                            gy += gri * sobelY[j + 1, i + 1];
                        }
                    }

                    int kenarDegeri = (int)Math.Sqrt(gx * gx + gy * gy);
                    kenarDegeri = Math.Min(255, Math.Max(0, kenarDegeri));

                    sonuc.SetPixel(x, y, Color.FromArgb(kenarDegeri, kenarDegeri, kenarDegeri));
                }
            }

            return sonuc;
        }
        private Bitmap SaltPepperGurultuEkle(Bitmap kaynak, double oran)
        {
            Bitmap gurultulu = new Bitmap(kaynak);

            Random rnd = new Random();

            int toplamPiksel = kaynak.Width * kaynak.Height;
            int gurultuluPikselSayisi = (int)(toplamPiksel * oran);

            for (int i = 0; i < gurultuluPikselSayisi; i++)
            {
                int x = rnd.Next(0, kaynak.Width);
                int y = rnd.Next(0, kaynak.Height);

                // %50 siyah, %50 beyaz olacak şekilde belirle
                Color renk = (rnd.NextDouble() < 0.5) ? Color.Black : Color.White;

                gurultulu.SetPixel(x, y, renk);
            }

            return gurultulu;
        }
        private Bitmap MedianFiltreUygula(Bitmap kaynak)
        {
            Bitmap sonuc = new Bitmap(kaynak.Width, kaynak.Height);

            for (int y = 1; y < kaynak.Height - 1; y++)
            {
                for (int x = 1; x < kaynak.Width - 1; x++)
                {
                    List<byte> komsuR = new List<byte>();
                    List<byte> komsuG = new List<byte>();
                    List<byte> komsuB = new List<byte>();

                    for (int j = -1; j <= 1; j++)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            Color renk = kaynak.GetPixel(x + i, y + j);
                            komsuR.Add(renk.R);
                            komsuG.Add(renk.G);
                            komsuB.Add(renk.B);
                        }
                    }

                    komsuR.Sort();
                    komsuG.Sort();
                    komsuB.Sort();

                    byte medR = komsuR[4]; // 3x3 komşularda 5. eleman medyan olur
                    byte medG = komsuG[4];
                    byte medB = komsuB[4];

                    sonuc.SetPixel(x, y, Color.FromArgb(medR, medG, medB));
                }
            }

            return sonuc;
        }
        private Bitmap MotionBlurUygula(Bitmap kaynak)
        {
            int[,] kernel = new int[5, 5]
            {
        {1, 0, 0, 0, 0},
        {0, 1, 0, 0, 0},
        {0, 0, 1, 0, 0},
        {0, 0, 0, 1, 0},
        {0, 0, 0, 0, 1}
            };

            int kernelBoyutu = 5;
            int toplam = 5; // Kernel'deki toplam ağırlık (1+1+1+1+1)

            Bitmap sonuc = new Bitmap(kaynak.Width, kaynak.Height);

            for (int y = 2; y < kaynak.Height - 2; y++)
            {
                for (int x = 2; x < kaynak.Width - 2; x++)
                {
                    int r = 0, g = 0, b = 0;

                    for (int j = 0; j < kernelBoyutu; j++)
                    {
                        for (int i = 0; i < kernelBoyutu; i++)
                        {
                            int offsetX = x + i - 2;
                            int offsetY = y + j - 2;
                            Color renk = kaynak.GetPixel(offsetX, offsetY);

                            int k = kernel[j, i];
                            r += renk.R * k;
                            g += renk.G * k;
                            b += renk.B * k;
                        }
                    }

                    r /= toplam;
                    g /= toplam;
                    b /= toplam;

                    // Renk sınırlarını kontrol et
                    r = Math.Min(255, Math.Max(0, r));
                    g = Math.Min(255, Math.Max(0, g));
                    b = Math.Min(255, Math.Max(0, b));

                    sonuc.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return sonuc;
        }
        private Bitmap MorfolojikGenisleme(Bitmap kaynak)
        {


            int genislik = kaynak.Width;
            int yukseklik = kaynak.Height;
            Bitmap sonuc = new Bitmap(genislik, yukseklik);

            // 3x3 yapısal eleman
            int[,] se = new int[,]
            {
        { 1, 1, 1 },
        { 1, 1, 1 },
        { 1, 1, 1 }
            };

            for (int y = 1; y < yukseklik - 1; y++)
            {
                for (int x = 1; x < genislik - 1; x++)
                {
                    bool beyazBulundu = false;

                    // Yapısal elemanı uygula
                    for (int j = -1; j <= 1; j++)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            Color renk = kaynak.GetPixel(x + i, y + j);
                            // Beyaz piksel (foreground) var mı kontrol et
                            if (renk.R == 255 && renk.G == 255 && renk.B == 255)
                            {
                                beyazBulundu = true;
                                break;
                            }
                        }
                        if (beyazBulundu) break;
                    }

                    // Eğer çevrede beyaz varsa bu pikseli beyaz yap
                    if (beyazBulundu)
                    {
                        sonuc.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        sonuc.SetPixel(x, y, Color.Black);
                    }
                }
            }

            return sonuc;
        }

        private Bitmap MorfolojikAsinma(Bitmap kaynak)
        {
            int genislik = kaynak.Width;
            int yukseklik = kaynak.Height;
            Bitmap sonuc = new Bitmap(genislik, yukseklik);

            // 3x3 yapısal eleman
            int[,] se = new int[,]
            {
        { 1, 1, 1 },
        { 1, 1, 1 },
        { 1, 1, 1 }
            };

            for (int y = 1; y < yukseklik - 1; y++)
            {
                for (int x = 1; x < genislik - 1; x++)
                {
                    bool siyahBulundu = false;

                    for (int j = -1; j <= 1; j++)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            Color renk = kaynak.GetPixel(x + i, y + j);
                            // Siyah piksel varsa (arka plan), o zaman bu piksel aşınır (siyah yapılır)
                            if (renk.R == 0 && renk.G == 0 && renk.B == 0)
                            {
                                siyahBulundu = true;
                                break;
                            }
                        }
                        if (siyahBulundu) break;
                    }

                    // Eğer komşularda siyah varsa bu pikseli siyah yap, yoksa beyaz bırak
                    if (siyahBulundu)
                    {
                        sonuc.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        sonuc.SetPixel(x, y, Color.White);
                    }
                }
            }

            return sonuc;
        }




        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbIslemler.Items.Add("Görüntüye uygulanacak işlemi seçin");
            cmbIslemler.Items.Add("Gri Dönüşüm");
            cmbIslemler.Items.Add("Binary Dönüşüm");
            cmbIslemler.Items.Add("Görüntü Döndürme");
            cmbIslemler.Items.Add("Görüntü Kırpma");
            cmbIslemler.Items.Add("Görüntü Yaklaştırma/Uzaklaştırma");
            cmbIslemler.Items.Add("Renk Uzayı Dönüşümleri");
            cmbIslemler.Items.Add("Histogram Germe/Genişletme");
            cmbIslemler.Items.Add("Aritmetik İşlemler (Çıkarma)");
            cmbIslemler.Items.Add("Aritmetik İşlemler (Çarpma)");
            cmbIslemler.Items.Add("Kontrast Azaltma");
            cmbIslemler.Items.Add("Konvolüsyon (Median)");
            cmbIslemler.Items.Add("Çift Eşikleme");
            cmbIslemler.Items.Add("Kenar Bulma (Canny)");
            cmbIslemler.Items.Add("Gürültü Ekleme");
            cmbIslemler.Items.Add("Gürültü Temizleme");
            cmbIslemler.Items.Add("Filtre Uygulama (Motion)");
            cmbIslemler.Items.Add("Morfolojik İşlemler (Genişleme)");
            cmbIslemler.Items.Add("Morfolojik İşlemler (Aşınma)");
            cmbIslemler.Items.Add("Morfolojik İşlemler (Açma)");
            cmbIslemler.Items.Add("Morfolojik İşlemler (Kapama)");
            cmbIslemler.SelectedIndex = 0;

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string secilenIslem = cmbIslemler.SelectedItem.ToString();

            switch (secilenIslem)
            {
                case "Gri Dönüşüm":
                    // gri dönüşüm metodunu çağır
                    Bitmap griResim = ConvertToGrayscale(girisResmi);
                    pbIslemSonucu.Image = griResim;
                    break;
                case "Binary Dönüşüm":
                    // binary dönüşüm metodunu çağır

                    // Kullanıcıdan eşik değeri al, örneğin 128
                    int esikDegeri = 128;

                    // Gri dönüşüm uygulandıktan sonra binary dönüşüm uygulayacağız
                    Bitmap binaryResim = BinaryDonusum(girisResmi, esikDegeri);

                    // Sonucu picturebox'a yükle
                    pbIslemSonucu.Image = binaryResim;
                    pbIslemSonucu.SizeMode = PictureBoxSizeMode.Zoom;
                    break;
                case "Görüntü Döndürme":
                    // döndürme işlemi
                    // Kullanıcıdan döndürme açısını al (Örneğin 90 derece)
                    float donusAcisi = 90;

                    // Görüntü döndürme işlemini uygula
                    Bitmap donmusResim = GoruntuDonusum(girisResmi, donusAcisi);

                    // Sonucu picturebox'a yükle
                    pbIslemSonucu.Image = donmusResim;
                    pbIslemSonucu.SizeMode = PictureBoxSizeMode.Zoom;
                    break;
                case "Görüntü Kırpma":
                    // Kırpılacak alanın sol üst köşesinin koordinatları ve boyutları
                    int xBaslangic = 50;    // Kırpılacak alanın x koordinatı
                    int yBaslangic = 50;    // Kırpılacak alanın y koordinatı
                    int genislik = 200;     // Kırpılacak alanın genişliği
                    int yukseklik = 150;    // Kırpılacak alanın yüksekliği

                    // Görüntü kırpma işlemini uygula
                    Bitmap kirpilmisResim = GoruntuKirp(girisResmi, xBaslangic, yBaslangic, genislik, yukseklik);

                    // Sonucu picturebox'a yükle
                    pbIslemSonucu.Image = kirpilmisResim;
                    pbIslemSonucu.SizeMode = PictureBoxSizeMode.Zoom;

                    break;
                case "Görüntü Yaklaştırma/Uzaklaştırma":
                    //float oran = 1.5f; // Yaklaştırma ya da 0.5f uzaklaştırma

                    //Bitmap kaynak = (Bitmap)pbGirisResmi.Image;
                    //Bitmap sonuc = GoruntuYakalastirVeyaUzaklastir(kaynak, oran);

                    //if (sonuc != null)
                    //{
                    //    pbIslemSonucu.SizeMode = PictureBoxSizeMode.Zoom;
                    //    pbIslemSonucu.Image = sonuc;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Yaklaştırma/Uzaklaştırma işlemi başarısız oldu.");
                    //}
                    pbIslemSonucu.Image = GoruntuYakalastirVeyaUzaklastir(girisResmi, 2.1f);


                    break;
                case "Renk Uzayı Dönüşümleri":
                    pbIslemSonucu.Image = RenkUzayiDonusumuHueGorsel(girisResmi);

                    break;
                case "Aritmetik İşlemler (Çıkarma)":
                    if (girisResmi != null)
                    {
                        OpenFileDialog ofd = new OpenFileDialog();
                        ofd.Title = "Çıkarmak için ikinci resmi seçin";
                        ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";

                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            Bitmap ikinciResim = new Bitmap(ofd.FileName);

                            // Boyut farkı uyarısı (isteğe bağlı)
                            if (ikinciResim.Width != girisResmi.Width || ikinciResim.Height != girisResmi.Height)
                            {
                                MessageBox.Show("İki resim aynı boyutta olmalı!");
                            }
                            else
                            {
                                pbIslemSonucu.Image = GoruntuCikarma(girisResmi, ikinciResim);
                                pbIslemSonucu.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen önce bir giriş resmi yükleyin.");
                    }
                    break;
                case "Aritmetik İşlemler (Çarpma)":
                    if (girisResmi != null)
                    {
                        OpenFileDialog ofd = new OpenFileDialog();
                        ofd.Title = "Çarpmak için ikinci resmi seçin";
                        ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";

                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            Bitmap ikinciResim = new Bitmap(ofd.FileName);

                            if (ikinciResim.Width != girisResmi.Width || ikinciResim.Height != girisResmi.Height)
                            {
                                MessageBox.Show("İki resim aynı boyutta olmalı!");
                            }
                            else
                            {
                                pbIslemSonucu.Image = GoruntuCarpma(girisResmi, ikinciResim);
                                pbIslemSonucu.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen önce bir giriş resmi yükleyin.");
                    }
                    break;
                case "Kontrast Azaltma":
                    if (girisResmi != null)
                    {
                        Bitmap sonuc = KontrastAzalt(girisResmi, 0.5f); // kontrastı yarıya indir
                        pbIslemSonucu.Image = sonuc;
                        pbIslemSonucu.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        MessageBox.Show("Lütfen önce bir resim yükleyin.");
                    }
                    break;
                case "Konvolüsyon (Median)":
                    if (girisResmi != null)
                    {
                        Bitmap sonuc = MedianFiltre(girisResmi);
                        pbIslemSonucu.Image = sonuc;
                        pbIslemSonucu.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        MessageBox.Show("Lütfen önce bir resim yükleyin.");
                    }
                    break;
                case "Çift Eşikleme":
                    // Alt ve üst eşik değerlerini kendin belirleyebilirsin
                    int altEsik = 100;
                    int ustEsik = 200;
                    pbIslemSonucu.Image = CiftEşiklemeUygula((Bitmap)pbGirisResmi.Image, altEsik, ustEsik);
                    break;
                case "Kenar Bulma (Canny)":
                    pbIslemSonucu.Image = KenarBulSobel((Bitmap)pbGirisResmi.Image);
                    break;
                case "Gürültü Ekleme":
                    pbIslemSonucu.Image = SaltPepperGurultuEkle((Bitmap)pbGirisResmi.Image, 0.02); // %2 gürültü oranı
                    break;
                case "Gürültü Temizleme":
                    pbIslemSonucu.Image = MedianFiltreUygula((Bitmap)pbGirisResmi.Image);
                    break;
                case "Filtre Uygulama (Motion)":
                    pbIslemSonucu.Image = MotionBlurUygula((Bitmap)pbGirisResmi.Image);
                    break;
                case "Morfolojik İşlemler (Genişleme)":

                    // giriş resmi binary döbüşüm uygulanmış olması daha doğru sonuç veriyor
                    
                    Bitmap binResim = BinaryDonusum((Bitmap)pbGirisResmi.Image, 128);
                    pbIslemSonucu.Image = MorfolojikGenisleme(binResim);
                    break;
                case "Morfolojik İşlemler (Aşınma)":
                    Bitmap binResim2 = BinaryDonusum((Bitmap)pbGirisResmi.Image, 128);
                    Bitmap genisletiilmisResim = MorfolojikGenisleme(binResim2);
                    pbIslemSonucu.Image = MorfolojikAsinma(genisletiilmisResim);
                    break;

                //case "Morfolojik İşlemler (Açma)":
                //    pbIslemSonucu.Image = MorfolojikAcma((Bitmap)pbGirisResmi.Image);
                //    break;





            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Bir resim seçiniz";
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                girisResmi = new Bitmap(ofd.FileName); // resmi Bitmap olarak al
                pbGirisResmi.Image = girisResmi;        // PictureBox'ta göster
                pbGirisResmi.SizeMode = PictureBoxSizeMode.Zoom; // resim sığsın
            }
        }
    }
}

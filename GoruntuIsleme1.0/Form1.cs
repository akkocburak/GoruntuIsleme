using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GoruntuIsleme1._0
{
    public partial class Form1 : Form
    {
        private Bitmap girisResmi;

        public Form1()
        {
            InitializeComponent();
            TextBoxlariGizle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ComboBox'a işlemler ekleniyor
            cmbIslemler.Items.AddRange(new[]
            {
                "Görüntüye uygulanacak işlemi seçin",
                "Gri Tonlama",
                "İkili (Binary) Dönüşüm",
                "Görüntü Döndürme",
                "Görüntü Kırpma",
                "Yakınlaştırma/Uzaklaştırma",
                "Renk Uzayı Dönüşümü (Hue)",
                "Histogram Germe/Genişletme",
                "Aritmetik İşlem (Çıkarma)",
                "Aritmetik İşlem (Çarpma)",
                "Kontrast Değiştirme",
                "Konvolüsyon (Median Filtre)",
                "Konvolüsyon (Mean Filtre)",
                "Çift Eşikleme",
                "Kenar Bulma (Sobel)",
                "Tuz-Biber Gürültüsü Ekleme",
                "Gürültü Temizleme",
                "Hareket Bulanıklığı (Motion Blur)",
                "Morfolojik Genişleme",
                "Morfolojik Aşınma",
                "Morfolojik Açma",
                "Morfolojik Kapama"
            });
            cmbIslemler.SelectedIndex = 0;

            TextBoxlariGizle();
            KontrolleriGizle();
        }

        private void TextBoxlariGizle()
        {
            textaltesik.Visible = false;
            textustesik.Visible = false;
            txtKontrastFaktor.Visible = false;
            txtGenisletmeFaktoru.Visible = false;
            btnKontrastUygula.Visible = false;
        }

        private void KontrolleriGizle()
        {
            button3.Visible = false;
            button4.Visible = false;
            nudX.Visible = false;
            nudY.Visible = false;
            nudGenislik.Visible = false;
            nudYukseklik.Visible = false;
            nudOran.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            lblalt.Visible = false;
            lblust.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilenIslem = cmbIslemler.SelectedItem.ToString();
            KontrolleriGizle();

            switch (secilenIslem)
            {
                case "Görüntü Döndürme":
                    button3.Visible = true; // Sol döndürme
                    button4.Visible = true; // Sağ döndürme
                    break;

                case "Görüntü Kırpma":
                    nudX.Visible = true;
                    nudY.Visible = true;
                    nudGenislik.Visible = true;
                    nudYukseklik.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    break;

                case "Yakınlaştırma/Uzaklaştırma":
                    nudOran.Visible = true;
                    label8.Visible = true;
                    break;

                case "Çift Eşikleme":
                    textaltesik.Visible = true;
                    textustesik.Visible = true;
                    textaltesik.Text = "100";
                    textustesik.Text = "200";
                    lblalt.Visible = true;
                    lblust.Visible = true;
                    break;

                case "Kontrast Değiştirme":
                    btnKontrastUygula.Visible = true;
                    txtKontrastFaktor.Visible = true;
                    button2.Visible = false;
                    break;

                case "Histogram Germe/Genişletme":
                    txtGenisletmeFaktoru.Visible = true;
                    label7.Visible = true;
                    break;

                default:
                    button2.Visible = true;
                    txtGenisletmeFaktoru.Visible = false;
                    txtKontrastFaktor.Visible = false;
                    btnKontrastUygula.Visible = false;
                    textaltesik.Visible = false;
                    textustesik.Visible = false;
                    lblalt.Visible = false;
                    lblust.Visible = false;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Bir resim seçiniz",
                Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    girisResmi = new Bitmap(ofd.FileName);
                    pbGirisResmi.Image = girisResmi;
                    pbGirisResmi.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbIslemler.SelectedIndex == 0)
            {
                MessageBox.Show("Lütfen bir işlem seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (girisResmi == null)
            {
                MessageBox.Show("Lütfen önce bir giriş resmi yükleyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string secilenIslem = cmbIslemler.SelectedItem.ToString();
            Bitmap sonucResim = null;

            switch (secilenIslem)
            {
                case "Gri Tonlama":
                    sonucResim = ConvertToGrayscale(girisResmi);
                    break;

                case "İkili (Binary) Dönüşüm":
                    sonucResim = BinaryDonusum(girisResmi, 128);
                    break;

                case "Görüntü Döndürme":
                    sonucResim = GoruntuDonusum(girisResmi, 90);
                    break;

                case "Görüntü Kırpma":
                    int x = (int)nudX.Value;
                    int y = (int)nudY.Value;
                    int genislik = (int)nudGenislik.Value;
                    int yukseklik = (int)nudYukseklik.Value;
                    sonucResim = GoruntuKirp(girisResmi, x, y, genislik, yukseklik);
                    break;

                case "Yakınlaştırma/Uzaklaştırma":
                    float oran = (float)nudOran.Value;
                    sonucResim = GoruntuYakalastirVeyaUzaklastir(girisResmi, oran);
                    if (sonucResim == null)
                    {
                        return; // Hata mesajı metod içinde gösterildi
                    }
                    break;

                case "Renk Uzayı Dönüşümü (Hue)":
                    sonucResim = RenkUzayiDonusumuHueGorsel(girisResmi);
                    break;

                case "Histogram Germe/Genişletme":
                    if (!double.TryParse(txtGenisletmeFaktoru.Text, out double faktor) || faktor <= 0)
                    {
                        MessageBox.Show("Lütfen geçerli ve pozitif bir genişletme faktörü girin.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    sonucResim = HistogramGerme(girisResmi, faktor);
                    break;

                case "Aritmetik İşlem (Çıkarma)":
                    using (OpenFileDialog ofd = new OpenFileDialog
                    {
                        Title = "Çıkarmak için ikinci resmi seçin",
                        Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp"
                    })
                    {
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            using (Bitmap ikinciOrijinal = new Bitmap(ofd.FileName))
                            {
                                Bitmap ikinciResim = ResizeImage(ikinciOrijinal, girisResmi.Width, girisResmi.Height);
                                sonucResim = GoruntuCikarma(girisResmi, ikinciResim);
                            }
                        }
                    }
                    break;

                case "Aritmetik İşlem (Çarpma)":
                    using (OpenFileDialog ofd = new OpenFileDialog
                    {
                        Title = "Çarpmak için ikinci resmi seçin",
                        Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp"
                    })
                    {
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            using (Bitmap ikinciOrijinal = new Bitmap(ofd.FileName))
                            {
                                Bitmap ikinciResim = ResizeImage(ikinciOrijinal, girisResmi.Width, girisResmi.Height);
                                sonucResim = GoruntuCarpma(girisResmi, ikinciResim);
                            }
                        }
                    }
                    break;

                case "Kontrast Değiştirme":
                    sonucResim = KontrastDegistir(girisResmi, 0.5f);
                    break;

                case "Konvolüsyon (Median Filtre)":
                    sonucResim = MedianFiltre(girisResmi);
                    break;

                case "Konvolüsyon (Mean Filtre)":
                    sonucResim = MeanFiltreUygula(girisResmi, 3);
                    break;

                case "Çift Eşikleme":
                    if (!int.TryParse(textaltesik.Text, out int altEsik) || !int.TryParse(textustesik.Text, out int ustEsik))
                    {
                        MessageBox.Show("Lütfen geçerli sayısal değerler girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (altEsik < 0 || altEsik > 255 || ustEsik < 0 || ustEsik > 255 || altEsik > ustEsik)
                    {
                        MessageBox.Show("Eşik değerleri 0-255 arasında olmalı ve alt eşik üst eşikten küçük olmalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sonucResim = CiftEşiklemeUygula(girisResmi, altEsik, ustEsik);
                    break;

                case "Kenar Bulma (Sobel)":
                    sonucResim = KenarBulSobel(girisResmi);
                    break;

                case "Tuz-Biber Gürültüsü Ekleme":
                    sonucResim = SaltPepperGurultuEkle(girisResmi, 0.02);
                    break;

                case "Gürültü Temizleme":
                    sonucResim = MedianFiltreUygula(girisResmi);
                    break;

                case "Hareket Bulanıklığı (Motion Blur)":
                    sonucResim = MotionBlurUygula(girisResmi);
                    break;

                case "Morfolojik Genişleme":
                    sonucResim = MorfolojikGenisleme(BinaryDonusum(girisResmi, 128));
                    break;

                case "Morfolojik Aşınma":
                    sonucResim = MorfolojikAsinma(BinaryDonusum(girisResmi, 128));
                    break;

                case "Morfolojik Açma":
                    sonucResim = MorfolojikAcma(BinaryDonusum(girisResmi, 128));
                    break;

                case "Morfolojik Kapama":
                    sonucResim = MorfolojikKapama(BinaryDonusum(girisResmi, 128));
                    break;

                default:
                    MessageBox.Show("Geçersiz işlem!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            if (sonucResim != null)
            {
                pbIslemSonucu.Image = sonucResim;
                pbIslemSonucu.SizeMode = PictureBoxSizeMode.Zoom;

                // Boyut kontrolü, Yakınlaştırma/Uzaklaştırma da dahil değil
                if (secilenIslem != "Görüntü Döndürme" && secilenIslem != "Görüntü Kırpma" && secilenIslem != "Yakınlaştırma/Uzaklaştırma")
                {
                    if (sonucResim.Width != girisResmi.Width || sonucResim.Height != girisResmi.Height)
                    {
                        MessageBox.Show($"Boyut eşleşmesi başarısız: {secilenIslem}\nGiriş: {girisResmi.Width}x{girisResmi.Height}, Çıkış: {sonucResim.Width}x{sonucResim.Height}");
                    }
                }
            }
        }
        
        
        //GÖRÜNTÜ DÖNDÜRME İÇİN KULLANILIYOR 
        private void button3_Click(object sender, EventArgs e)
        {
            if (pbIslemSonucu.Image == null)
            {
                MessageBox.Show("Lütfen önce bir resim yükleyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Bitmap aktifResim = new Bitmap(pbIslemSonucu.Image))
            {
                pbIslemSonucu.Image = GoruntuDonusum(aktifResim, -90);
                pbIslemSonucu.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pbIslemSonucu.Image == null)
            {
                MessageBox.Show("Lütfen önce bir resim yükleyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Bitmap aktifResim = new Bitmap(pbIslemSonucu.Image))
            {
                pbIslemSonucu.Image = GoruntuDonusum(aktifResim, 90);
                pbIslemSonucu.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnKontrastUygula_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(txtKontrastFaktor.Text, out float faktor))
            {
                MessageBox.Show("Lütfen geçerli bir kontrast faktörü girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Bitmap kaynak = new Bitmap(pbGirisResmi.Image))
            {
                pbIslemSonucu.Image = KontrastDegistir(kaynak, faktor);
                pbIslemSonucu.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textaltesik.Text) && !int.TryParse(textaltesik.Text, out _))
            {
                MessageBox.Show("Lütfen geçerli bir sayısal değer girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textaltesik.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textustesik.Text) && !int.TryParse(textustesik.Text, out _))
            {
                MessageBox.Show("Lütfen geçerli bir sayısal değer girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textustesik.Text = "";
            }
        }

        // Görüntü İşleme Metotları

        private Bitmap ConvertToGrayscale(Bitmap source)
        {
            Bitmap grayBitmap = new Bitmap(source.Width, source.Height);
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color originalColor = source.GetPixel(x, y);
                    int grayValue = (int)(originalColor.R * 0.3 + originalColor.G * 0.59 + originalColor.B * 0.11);
                    grayBitmap.SetPixel(x, y, Color.FromArgb(grayValue, grayValue, grayValue));
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
                    Color pixelRenk = kaynak.GetPixel(x, y);
                    int griDeger = (pixelRenk.R + pixelRenk.G + pixelRenk.B) / 3;
                    binaryResim.SetPixel(x, y, griDeger >= esikDegeri ? Color.White : Color.Black);
                }
            }
            return binaryResim;
        }

        private Bitmap GoruntuDonusum(Bitmap kaynak, float aciDerece)
        {
            double radyan = aciDerece * Math.PI / 180.0;
            double cos = Math.Cos(radyan);
            double sin = Math.Sin(radyan);

            int genislik = kaynak.Width;
            int yukseklik = kaynak.Height;

            // Yeni boyutları hesapla (dönüş sonrası görüntü boyutları)
            int yeniGenislik = (int)(Math.Abs(genislik * cos) + Math.Abs(yukseklik * sin)) + 1;
            int yeniYukseklik = (int)(Math.Abs(genislik * sin) + Math.Abs(yukseklik * cos)) + 1;

            Bitmap donmusResim = new Bitmap(yeniGenislik, yeniYukseklik);
            int merkezX = genislik / 2;
            int merkezY = yukseklik / 2;
            int yeniMerkezX = yeniGenislik / 2;
            int yeniMerkezY = yeniYukseklik / 2;

            // Arka planı siyah yap
            for (int y = 0; y < yeniYukseklik; y++)
            {
                for (int x = 0; x < yeniGenislik; x++)
                {
                    donmusResim.SetPixel(x, y, Color.Black);
                }
            }

            // Her piksel için ters dönüşüm uygula
            for (int y = 0; y < yeniYukseklik; y++)
            {
                for (int x = 0; x < yeniGenislik; x++)
                {
                    // Yeni koordinatları orijinal koordinatlara dönüştür
                    int x2 = x - yeniMerkezX;
                    int y2 = y - yeniMerkezY;
                    int orijinalX = (int)(x2 * cos + y2 * sin + merkezX);
                    int orijinalY = (int)(-x2 * sin + y2 * cos + merkezY);

                    // Orijinal koordinatlar geçerliyse pikseli kopyala
                    if (orijinalX >= 0 && orijinalX < genislik && orijinalY >= 0 && orijinalY < yukseklik)
                    {
                        donmusResim.SetPixel(x, y, kaynak.GetPixel(orijinalX, orijinalY));
                    }
                }
            }

            return donmusResim;
        }

        private Bitmap GoruntuKirp(Bitmap kaynak, int x, int y, int genislik, int yukseklik)
        {
            // Geçerlilik kontrolü
            if (x < 0 || y < 0 || x + genislik > kaynak.Width || y + yukseklik > kaynak.Height)
            {
                MessageBox.Show("Kırpma boyutları veya koordinatları geçersiz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            Bitmap kirpilmisResim = new Bitmap(genislik, yukseklik);
            for (int i = 0; i < yukseklik; i++)
            {
                for (int j = 0; j < genislik; j++)
                {
                    kirpilmisResim.SetPixel(j, i, kaynak.GetPixel(x + j, y + i));
                }
            }
            return kirpilmisResim;
        }

        private Bitmap GoruntuYakalastirVeyaUzaklastir(Bitmap kaynak, float oran)
        {
            if (kaynak == null || oran <= 0)
                return kaynak;

            // Yakınlaştırma (oran > 1) → ortadan kırpıp tekrar eski boyuta büyüt
            if (oran > 1.0f)
            {
                int yeniGenislik = (int)(kaynak.Width / oran);
                int yeniYukseklik = (int)(kaynak.Height / oran);

                int baslangicX = (kaynak.Width - yeniGenislik) / 2;
                int baslangicY = (kaynak.Height - yeniYukseklik) / 2;

                // Kırpma işlemi
                Bitmap kirpilmis = new Bitmap(yeniGenislik, yeniYukseklik);
                for (int y = 0; y < yeniYukseklik; y++)
                {
                    for (int x = 0; x < yeniGenislik; x++)
                    {
                        Color piksel = kaynak.GetPixel(baslangicX + x, baslangicY + y);
                        kirpilmis.SetPixel(x, y, piksel);
                    }
                }

                // Büyütme işlemi (en yakın komşu interpolasyonu)
                Bitmap buyutulmus = new Bitmap(kaynak.Width, kaynak.Height);
                float xOran = (float)yeniGenislik / kaynak.Width;
                float yOran = (float)yeniYukseklik / kaynak.Height;

                for (int y = 0; y < kaynak.Height; y++)
                {
                    for (int x = 0; x < kaynak.Width; x++)
                    {
                        int kaynakX = (int)(x * xOran);
                        int kaynakY = (int)(y * yOran);
                        if (kaynakX >= yeniGenislik) kaynakX = yeniGenislik - 1;
                        if (kaynakY >= yeniYukseklik) kaynakY = yeniYukseklik - 1;

                        Color piksel = kirpilmis.GetPixel(kaynakX, kaynakY);
                        buyutulmus.SetPixel(x, y, piksel);
                    }
                }

                return buyutulmus;
            }
            // Uzaklaştırma (oran < 1) → resim küçültülür, ortalanarak etrafı boş bırakılır
            else
            {
                int kucultulmusGenislik = (int)(kaynak.Width * oran);
                int kucultulmusYukseklik = (int)(kaynak.Height * oran);

                // Küçültme işlemi (en yakın komşu interpolasyonu)
                Bitmap kucultulmus = new Bitmap(kucultulmusGenislik, kucultulmusYukseklik);
                float xOran = (float)kaynak.Width / kucultulmusGenislik;
                float yOran = (float)kaynak.Height / kucultulmusYukseklik;

                for (int y = 0; y < kucultulmusYukseklik; y++)
                {
                    for (int x = 0; x < kucultulmusGenislik; x++)
                    {
                        int kaynakX = (int)(x * xOran);
                        int kaynakY = (int)(y * yOran);
                        if (kaynakX >= kaynak.Width) kaynakX = kaynak.Width - 1;
                        if (kaynakY >= kaynak.Height) kaynakY = kaynak.Height - 1;

                        Color piksel = kaynak.GetPixel(kaynakX, kaynakY);
                        kucultulmus.SetPixel(x, y, piksel);
                    }
                }

                // Ortalama ve boş alanları gri yapma
                Bitmap uzakResim = new Bitmap(kaynak.Width, kaynak.Height);
                int baslangicX = (kaynak.Width - kucultulmusGenislik) / 2;
                int baslangicY = (kaynak.Height - kucultulmusYukseklik) / 2;

                for (int y = 0; y < kaynak.Height; y++)
                {
                    for (int x = 0; x < kaynak.Width; x++)
                    {
                        if (x >= baslangicX && x < baslangicX + kucultulmusGenislik &&
                            y >= baslangicY && y < baslangicY + kucultulmusYukseklik)
                        {
                            Color piksel = kucultulmus.GetPixel(x - baslangicX, y - baslangicY);
                            uzakResim.SetPixel(x, y, piksel);
                        }
                        else
                        {
                            uzakResim.SetPixel(x, y, Color.Gray);
                        }
                    }
                }

                return uzakResim;
            }
        }

        private Bitmap ResizeImage(Bitmap orijinal, int hedefGenislik, int hedefYukseklik)
        {
            Bitmap yeniResim = new Bitmap(hedefGenislik, hedefYukseklik);
            float oranX = (float)orijinal.Width / hedefGenislik;
            float oranY = (float)orijinal.Height / hedefYukseklik;

            for (int y = 0; y < hedefYukseklik; y++)
            {
                for (int x = 0; x < hedefGenislik; x++)
                {
                    // Orijinal görüntüdeki karşılık gelen koordinatları hesapla
                    int orijinalX = (int)(x * oranX);
                    int orijinalY = (int)(y * oranY);

                    // Sınır kontrolü
                    orijinalX = Math.Max(0, Math.Min(orijinalX, orijinal.Width - 1));
                    orijinalY = Math.Max(0, Math.Min(orijinalY, orijinal.Height - 1));

                    // En yakın komşu pikselini kopyala
                    yeniResim.SetPixel(x, y, orijinal.GetPixel(orijinalX, orijinalY));
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
                    float rf = renk.R / 255f;
                    float gf = renk.G / 255f;
                    float bf = renk.B / 255f;

                    float max = Math.Max(rf, Math.Max(gf, bf));
                    float min = Math.Min(rf, Math.Min(gf, bf));
                    float delta = max - min;
                    float h = 0;

                    if (delta == 0) h = 0;
                    else if (max == rf) h = 60 * (((gf - bf) / delta) % 6);
                    else if (max == gf) h = 60 * (((bf - rf) / delta) + 2);
                    else if (max == bf) h = 60 * (((rf - gf) / delta) + 4);

                    if (h < 0) h += 360;

                    float s = 1;
                    float v = 1;
                    float c = v * s;
                    float x2 = c * (1 - Math.Abs((h / 60) % 2 - 1));
                    float m = v - c;
                    float r1 = 0, g1 = 0, b1 = 0;

                    if (h < 60) { r1 = c; g1 = x2; b1 = 0; }
                    else if (h < 120) { r1 = x2; g1 = c; b1 = 0; }
                    else if (h < 180) { r1 = 0; g1 = c; b1 = x2; }
                    else if (h < 240) { r1 = 0; g1 = x2; b1 = c; }
                    else if (h < 300) { r1 = x2; g1 = 0; b1 = c; }
                    else { r1 = c; g1 = 0; b1 = x2; }

                    int rFinal = (int)((r1 + m) * 255);
                    int gFinal = (int)((g1 + m) * 255);
                    int bFinal = (int)((b1 + m) * 255);

                    yeniResim.SetPixel(x, y, Color.FromArgb(rFinal, gFinal, bFinal));
                }
            }
            return yeniResim;
        }

        private Bitmap HistogramGerme(Bitmap kaynak, double genisletmeFaktoru = 1.2)
        {
            int width = kaynak.Width;
            int height = kaynak.Height;

            // Min-Max değerlerini bul
            int rMin = 255, rMax = 0, gMin = 255, gMax = 0, bMin = 255, bMax = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color renk = kaynak.GetPixel(x, y);
                    rMin = Math.Min(rMin, renk.R);
                    rMax = Math.Max(rMax, renk.R);
                    gMin = Math.Min(gMin, renk.G);
                    gMax = Math.Max(gMax, renk.G);
                    bMin = Math.Min(bMin, renk.B);
                    bMax = Math.Max(bMax, renk.B);
                }
            }

            // Histogram germe
            Bitmap gecici = new Bitmap(width, height);
            int rRange = Math.Max(1, rMax - rMin);
            int gRange = Math.Max(1, gMax - gMin);
            int bRange = Math.Max(1, bMax - bMin);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color renk = kaynak.GetPixel(x, y);
                    int r = (int)((renk.R - rMin) * 255.0 / rRange);
                    int g = (int)((renk.G - gMin) * 255.0 / gRange);
                    int b = (int)((renk.B - bMin) * 255.0 / bRange);
                    r = Math.Max(0, Math.Min(255, r));
                    g = Math.Max(0, Math.Min(255, g));
                    b = Math.Max(0, Math.Min(255, b));
                    gecici.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            // İstatistikleri hesapla
            double rToplam = 0, gToplam = 0, bToplam = 0;
            double rKareToplam = 0, gKareToplam = 0, bKareToplam = 0;
            int pixelSayisi = width * height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color renk = gecici.GetPixel(x, y);
                    rToplam += renk.R;
                    gToplam += renk.G;
                    bToplam += renk.B;
                    rKareToplam += renk.R * renk.R;
                    gKareToplam += renk.G * renk.G;
                    bKareToplam += renk.B * renk.B;
                }
            }

            double rOrt = rToplam / pixelSayisi;
            double gOrt = gToplam / pixelSayisi;
            double bOrt = bToplam / pixelSayisi;
            double rStd = Math.Sqrt((rKareToplam / pixelSayisi) - (rOrt * rOrt));
            double gStd = Math.Sqrt((gKareToplam / pixelSayisi) - (gOrt * gOrt));
            double bStd = Math.Sqrt((bKareToplam / pixelSayisi) - (bOrt * bOrt));

            // Genişletme uygula
            Bitmap sonuc = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color renk = gecici.GetPixel(x, y);
                    int r = (int)((renk.R - rOrt) * genisletmeFaktoru + rOrt);
                    int g = (int)((renk.G - gOrt) * genisletmeFaktoru + gOrt);
                    int b = (int)((renk.B - bOrt) * genisletmeFaktoru + bOrt);
                    r = Math.Max(0, Math.Min(255, r));
                    g = Math.Max(0, Math.Min(255, g));
                    b = Math.Max(0, Math.Min(255, b));
                    sonuc.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return sonuc;
        }

        private Bitmap GoruntuCikarma(Bitmap img1, Bitmap img2)
        {
            int genislik = Math.Min(img1.Width, img2.Width);
            int yukseklik = Math.Min(img1.Height, img2.Height);
            Bitmap sonuc = new Bitmap(img1.Width, img1.Height);

            for (int y = 0; y < img1.Height; y++)
            {
                for (int x = 0; x < img1.Width; x++)
                {
                    if (x < genislik && y < yukseklik)
                    {
                        Color renk1 = img1.GetPixel(x, y);
                        Color renk2 = img2.GetPixel(x, y);
                        int r = Math.Max(0, renk1.R - renk2.R);
                        int g = Math.Max(0, renk1.G - renk2.G);
                        int b = Math.Max(0, renk1.B - renk2.B);
                        sonuc.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                    else
                    {
                        sonuc.SetPixel(x, y, Color.Black);
                    }
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

        private Bitmap KontrastDegistir(Bitmap kaynak, float kontrastFaktor)
        {
            Bitmap sonuc = new Bitmap(kaynak.Width, kaynak.Height);
            for (int y = 0; y < kaynak.Height; y++)
            {
                for (int x = 0; x < kaynak.Width; x++)
                {
                    Color piksel = kaynak.GetPixel(x, y);
                    int ortalama = 128;
                    int r = (int)((piksel.R - ortalama) * kontrastFaktor + ortalama);
                    int g = (int)((piksel.G - ortalama) * kontrastFaktor + ortalama);
                    int b = (int)((piksel.B - ortalama) * kontrastFaktor + ortalama);
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

            for (int y = 0; y < kaynak.Height; y++)
            {
                for (int x = 0; x < kaynak.Width; x++)
                {
                    if (y < offset || y >= kaynak.Height - offset || x < offset || x >= kaynak.Width - offset)
                    {
                        sonuc.SetPixel(x, y, kaynak.GetPixel(x, y));
                        continue;
                    }

                    List<byte> RList = new List<byte>();
                    List<byte> GList = new List<byte>();
                    List<byte> BList = new List<byte>();

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

        private Bitmap MeanFiltreUygula(Bitmap kaynak, int filtreBoyutu = 3)
        {
            Bitmap sonuc = new Bitmap(kaynak.Width, kaynak.Height);
            int offset = filtreBoyutu / 2;

            for (int y = 0; y < kaynak.Height; y++)
            {
                for (int x = 0; x < kaynak.Width; x++)
                {
                    if (y < offset || y >= kaynak.Height - offset || x < offset || x >= kaynak.Width - offset)
                    {
                        sonuc.SetPixel(x, y, kaynak.GetPixel(x, y));
                        continue;
                    }

                    int toplamR = 0, toplamG = 0, toplamB = 0;
                    int pikselSayisi = 0;

                    for (int j = -offset; j <= offset; j++)
                    {
                        for (int i = -offset; i <= offset; i++)
                        {
                            Color renk = kaynak.GetPixel(x + i, y + j);
                            toplamR += renk.R;
                            toplamG += renk.G;
                            toplamB += renk.B;
                            pikselSayisi++;
                        }
                    }

                    int ortalamaR = toplamR / pikselSayisi;
                    int ortalamaG = toplamG / pikselSayisi;
                    int ortalamaB = toplamB / pikselSayisi;
                    sonuc.SetPixel(x, y, Color.FromArgb(ortalamaR, ortalamaG, ortalamaB));
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
                    if (gri < altEsik) sonuc.SetPixel(x, y, Color.Black);
                    else if (gri > ustEsik) sonuc.SetPixel(x, y, Color.White);
                    else sonuc.SetPixel(x, y, Color.Gray);
                }
            }
            return sonuc;
        }

        private Bitmap KenarBulSobel(Bitmap kaynak)
        {
            int[,] sobelX = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] sobelY = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
            Bitmap sonuc = new Bitmap(kaynak.Width, kaynak.Height);

            for (int y = 0; y < kaynak.Height; y++)
            {
                for (int x = 0; x < kaynak.Width; x++)
                {
                    if (y < 1 || y >= kaynak.Height - 1 || x < 1 || x >= kaynak.Width - 1)
                    {
                        sonuc.SetPixel(x, y, kaynak.GetPixel(x, y));
                        continue;
                    }

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
            Bitmap gurultulu = new Bitmap(kaynak.Width, kaynak.Height);
            for (int y = 0; y < kaynak.Height; y++)
            {
                for (int x = 0; x < kaynak.Width; x++)
                {
                    gurultulu.SetPixel(x, y, kaynak.GetPixel(x, y));
                }
            }

            Random rnd = new Random();
            int toplamPiksel = kaynak.Width * kaynak.Height;
            int gurultuluPikselSayisi = (int)(toplamPiksel * oran);

            for (int i = 0; i < gurultuluPikselSayisi; i++)
            {
                int x = rnd.Next(0, kaynak.Width);
                int y = rnd.Next(0, kaynak.Height);
                Color renk = rnd.NextDouble() < 0.5 ? Color.Black : Color.White;
                gurultulu.SetPixel(x, y, renk);
            }
            return gurultulu;
        }

        private Bitmap MedianFiltreUygula(Bitmap kaynak)
        {
            Bitmap sonuc = new Bitmap(kaynak.Width, kaynak.Height);
            for (int y = 0; y < kaynak.Height; y++)
            {
                for (int x = 0; x < kaynak.Width; x++)
                {
                    if (y < 1 || y >= kaynak.Height - 1 || x < 1 || x >= kaynak.Width - 1)
                    {
                        sonuc.SetPixel(x, y, kaynak.GetPixel(x, y));
                        continue;
                    }

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
                    byte medR = komsuR[4];
                    byte medG = komsuG[4];
                    byte medB = komsuB[4];
                    sonuc.SetPixel(x, y, Color.FromArgb(medR, medG, medB));
                }
            }
            return sonuc;
        }

        private Bitmap MotionBlurUygula(Bitmap kaynak)
        {
            int[,] kernel = {
                {1, 0, 0, 0, 0},
                {0, 1, 0, 0, 0},
                {0, 0, 1, 0, 0},
                {0, 0, 0, 1, 0},
                {0, 0, 0, 0, 1}
            };
            int kernelBoyutu = 5;
            int toplam = 5;
            int offset = kernelBoyutu / 2;
            Bitmap sonuc = new Bitmap(kaynak.Width, kaynak.Height);

            for (int y = 0; y < kaynak.Height; y++)
            {
                for (int x = 0; x < kaynak.Width; x++)
                {
                    if (y < offset || y >= kaynak.Height - offset || x < offset || x >= kaynak.Width - offset)
                    {
                        sonuc.SetPixel(x, y, kaynak.GetPixel(x, y));
                        continue;
                    }

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
            int[,] se = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };

            for (int y = 0; y < yukseklik; y++)
            {
                for (int x = 0; x < genislik; x++)
                {
                    if (y < 1 || y >= yukseklik - 1 || x < 1 || x >= genislik - 1)
                    {
                        sonuc.SetPixel(x, y, kaynak.GetPixel(x, y));
                        continue;
                    }

                    bool beyazBulundu = false;
                    for (int j = -1; j <= 1; j++)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            Color renk = kaynak.GetPixel(x + i, y + j);
                            if (renk.R == 255 && renk.G == 255 && renk.B == 255)
                            {
                                beyazBulundu = true;
                                break;
                            }
                        }
                        if (beyazBulundu) break;
                    }
                    sonuc.SetPixel(x, y, beyazBulundu ? Color.White : Color.Black);
                }
            }
            return sonuc;
        }

        private Bitmap MorfolojikAsinma(Bitmap kaynak)
        {
            int genislik = kaynak.Width;
            int yukseklik = kaynak.Height;
            Bitmap sonuc = new Bitmap(genislik, yukseklik);
            int[,] se = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };

            for (int y = 0; y < yukseklik; y++)
            {
                for (int x = 0; x < genislik; x++)
                {
                    if (y < 1 || y >= yukseklik - 1 || x < 1 || x >= genislik - 1)
                    {
                        sonuc.SetPixel(x, y, kaynak.GetPixel(x, y));
                        continue;
                    }

                    bool siyahBulundu = false;
                    for (int j = -1; j <= 1; j++)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            Color renk = kaynak.GetPixel(x + i, y + j);
                            if (renk.R == 0 && renk.G == 0 && renk.B == 0)
                            {
                                siyahBulundu = true;
                                break;
                            }
                        }
                        if (siyahBulundu) break;
                    }
                    sonuc.SetPixel(x, y, siyahBulundu ? Color.Black : Color.White);
                }
            }
            return sonuc;
        }

        private Bitmap MorfolojikAcma(Bitmap kaynak)
        {
            using (Bitmap asinmis = MorfolojikAsinma(kaynak))
            {
                return MorfolojikGenisleme(asinmis);
            }
        }

        private Bitmap MorfolojikKapama(Bitmap kaynak)
        {
            using (Bitmap genisletilmis = MorfolojikGenisleme(kaynak))
            {
                return MorfolojikAsinma(genisletilmis);
            }
        }

        
    }
}
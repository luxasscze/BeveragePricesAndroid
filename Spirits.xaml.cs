using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Net;
using Xamarin.Essentials;
using System.Drawing;
using System.Threading;
using FluentFTP;
using FluentFTP.Rules;


namespace BeveragePrices.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class Spirits : ContentPage
    {


        
        
        
        public static void DownloadFiles()
        {
            
            using (var ftp = new FtpClient("ftp://ftp.drivehq.com", "luxasscze", "Kasumi2Goto"))
            {
                ftp.Connect();


                // download a folder and all its files
                ftp.DownloadDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)), @"/BeveragePrices", FtpFolderSyncMode.Mirror, FtpLocalExists.Overwrite);

                

            }
        }

        public void SpiritsOnlineSync(object sender, EventArgs e)
        {
            
            UploadFiles();
            
            
            DisplayAlert("UPLOAD SYNC", "Sync is done.", "OK");
        }

        public void SpiritsOnlineSyncDownload(object sender, EventArgs e)
        {

            DownloadFiles();


            DisplayAlert("DOWNLOAD SYNC", "Sync is done.", "OK");
        }



        public static void UploadFiles()
        {
            using (var ftp = new FtpClient("ftp://ftp.drivehq.com", "luxasscze", "Kasumi2Goto"))
            {
                ftp.Connect();

                            

               
                ftp.UploadDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)), @"/BeveragePrices", FtpFolderSyncMode.Mirror, FtpRemoteExists.Overwrite);

            }
        }


        public string SpiritPathName(string spirit)
        {
            string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), spirit + ".spirit");
            return _fileName;
        }

        public void ShowSpirit(string spirit)
        {
            if (spiritSelect.SelectedIndex == 0)
            {
                if (!File.Exists(spirit + ".spirit"))
                {
                    File.WriteAllText(spirit + ".spirit", "Test text in file");

                }
            }
        }

        public void SpiritSave(string spirit, decimal buyPrice, decimal sellPrice, decimal ml25Price)
        {

            File.WriteAllText(SpiritPathName(spirit), spirit + ";" + buyPrice + ";" + sellPrice + ";" + ml25Price + ";");


        }

        public decimal GetSpiritBuyPrice(string spirit)
        {
            if (File.Exists(SpiritPathName(spirit)))
            {
                string allText = File.ReadAllText(SpiritPathName(spirit));
                string[] separated = allText.Split(';');
                return decimal.Parse(separated[1]);
            }
            else
            {
                return 0;
            }
        }

        public decimal GetSpiritSellPrice(string spirit)
        {
            if (File.Exists(SpiritPathName(spirit)))
            {
                string allText = File.ReadAllText(SpiritPathName(spirit));
                string[] separated = allText.Split(';');
                return decimal.Parse(separated[2]);
            }
            else
            {
                return 0;
            }
        }

        public decimal GetSpiritMl25Price(string spirit)
        {
            if (File.Exists(SpiritPathName(spirit)))
            {
                string allText = File.ReadAllText(SpiritPathName(spirit));
                string[] separated = allText.Split(';');
                return decimal.Parse(separated[3]);
            }
            else
            {
                return 0;
            }
        }

        public string GetSpiritName(string spirit)
        {
            if (File.Exists(SpiritPathName(spirit)))
            {
                string allText = File.ReadAllText(SpiritPathName(spirit));
                string[] separated = allText.Split(';');
                return separated[0];
            }
            else
            {
                return "0";
            }
        }

        public void SpiritIn(string spirit)
        {
            spiritImage.Source = spirit + ".jpg";
            buyPriceText.Text = GetSpiritBuyPrice(spirit).ToString();
            sellPriceText.Text = GetSpiritSellPrice(spirit).ToString();
            ml25PriceText.Text = GetSpiritMl25Price(spirit).ToString();
            ml50PriceText.Text = (GetSpiritMl25Price(spirit) * 2).ToString();
            profitPerBottleText.Text = (GetSpiritSellPrice(spirit) - GetSpiritBuyPrice(spirit)).ToString();
            
        }

        

        public void onBuyPrice(string spirit)
        {
            SpiritSave(spirit, decimal.Parse(buyPriceInput.Text), GetSpiritSellPrice(spirit), GetSpiritMl25Price(spirit));
            SpiritIn(spirit);
        }

        public void onSellPrice(string spirit)
        {
            SpiritSave(spirit, GetSpiritBuyPrice(spirit), decimal.Parse(sellPriceInput.Text), GetSpiritMl25Price(spirit));
            SpiritIn(spirit);
        }

        public void onMl25SellPrice(string spirit)
        {
            SpiritSave(spirit, GetSpiritBuyPrice(spirit), GetSpiritSellPrice(spirit), decimal.Parse(ml25sellPriceInput.Text));
            SpiritIn(spirit);
        }

        public void onExportExcel(object sender, EventArgs e)
        {
            DisplayAlert("Expot to Excel", "This feature is not available yet.", "OK");
        }

        public void onExportPDF(object sender, EventArgs e)
        {
             DisplayAlert("Export to PDF", "This feature is not available yet.", "OK");

            
        }

        public void onSendViaEmail(object sender, EventArgs e)
        {
            DisplayAlert("Send via Email", "This feature is not available yet.", "OK");
        }

        public void onSpiritSelect(object sender, EventArgs e) // ------------------------------FIRST------------------------------
        {
           

            if (spiritSelect.SelectedIndex == 0)
            {
                SpiritIn("Aberlour10YearOld");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 1)
            {
                SpiritIn("AbsolutOriginal");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 2)
            {
                SpiritIn("Aperol");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 3)
            {
                SpiritIn("ArchersWhiskey");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 4)
            {
                SpiritIn("BacardiCartaBlanca");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 5)
            {
                SpiritIn("Baileys");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 6)
            {
                SpiritIn("Beefeater");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 7)
            {
                SpiritIn("BlueMonkeyGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 8)
            {
                SpiritIn("BlueMonkeyMangoAndPassionFruitGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 9)
            {
                SpiritIn("BlueMonkeyRhubarbAndCustardGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 10)
            {
                SpiritIn("BlueMonkeySaltedCaramelGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 11)
            {
                SpiritIn("BlueMonkeySevilleOrangeGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 12)
            {
                SpiritIn("BlueMonkeySummerBerries");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 13)
            {
                SpiritIn("BombaySapphire");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 14)
            {
                SpiritIn("Bowmore12YrsOld");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 15)
            {
                SpiritIn("BulleitBourbonFrontierWhiskey");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 16)
            {
                SpiritIn("Campari");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 17)
            {
                SpiritIn("CaptainMorgan");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 18)
            {
                SpiritIn("CaptainMorganSpicedRum");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 19)
            {
                SpiritIn("Cointreau");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 20)
            {
                SpiritIn("CourvoisierXO");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 21)
            {
                SpiritIn("CremeDeCassis");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 22)
            {
                SpiritIn("Disaronno");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 23)
            {
                SpiritIn("EristoffVodka");
                SetPrices();
            }

            // --------------------------------------SECOND---------------------------------------------
        }

        public void onBuyPriceInput(object sender, EventArgs e)
        {
            if (spiritSelect.SelectedIndex == 0)
            {
                onBuyPrice("Aberlour10YearOld");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 1)
            {
                onBuyPrice("AbsolutOriginal");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 2)
            {
                onBuyPrice("Aperol");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 3)
            {
                onBuyPrice("ArchersWhiskey");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 4)
            {
                onBuyPrice("BacardiCartaBlanca");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 5)
            {
                onBuyPrice("Baileys");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 6)
            {
                onBuyPrice("Beefeater");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 7)
            {
                onBuyPrice("BlueMonkeyGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 8)
            {
                onBuyPrice("BlueMonkeyMangoAndPassionFruitGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 9)
            {
                onBuyPrice("BlueMonkeyRhubarbAndCustardGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 10)
            {
                onBuyPrice("BlueMonkeySaltedCaramelGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 11)
            {
                onBuyPrice("BlueMonkeySevilleOrangeGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 12)
            {
                onBuyPrice("BlueMonkeySummerBerries");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 13)
            {
                onBuyPrice("BombaySapphire");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 14)
            {
                onBuyPrice("Bowmore12YrsOld");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 15)
            {
                onBuyPrice("BulleitBourbonFrontierWhiskey");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 16)
            {
                onBuyPrice("Campari");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 17)
            {
                onBuyPrice("CaptainMorgan");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 18)
            {
                onBuyPrice("CaptainMorganSpicedRum");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 19)
            {
                onBuyPrice("Cointreau");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 20)
            {
                onBuyPrice("CourvoisierXO");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 21)
            {
                onBuyPrice("CremeDeCassis");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 22)
            {
                onBuyPrice("Disaronno");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 23)
            {
                onBuyPrice("EristoffVodka");
                SetPrices();
            }

            // ----------------------------------------THIRD------------------------------------------------
        }

        public void onSellPriceInput(object sender, EventArgs e)
        {
            if (spiritSelect.SelectedIndex == 0)
            {
                onSellPrice("Aberlour10YearOld");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 1)
            {
                onSellPrice("AbsolutOriginal");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 2)
            {
                onSellPrice("Aperol");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 3)
            {
                onSellPrice("ArchersWhiskey");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 4)
            {
                onSellPrice("BacardiCartaBlanca");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 5)
            {
                onSellPrice("Baileys");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 6)
            {
                onSellPrice("Beefeater");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 7)
            {
                onSellPrice("BlueMonkeyGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 8)
            {
                onSellPrice("BlueMonkeyMangoAndPassionFruitGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 9)
            {
                onSellPrice("BlueMonkeyRhubarbAndCustardGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 10)
            {
                onSellPrice("BlueMonkeySaltedCaramelGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 11)
            {
                onSellPrice("BlueMonkeySevilleOrangeGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 12)
            {
                onSellPrice("BlueMonkeySummerBerries");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 13)
            {
                onSellPrice("BombaySapphire");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 14)
            {
                onSellPrice("Bowmore12YrsOld");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 15)
            {
                onSellPrice("BulleitBourbonFrontierWhiskey");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 16)
            {
                onSellPrice("Campari");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 17)
            {
                onSellPrice("CaptainMorgan");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 18)
            {
                onSellPrice("CaptainMorganSpicedRum");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 19)
            {
                onSellPrice("Cointreau");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 20)
            {
                onSellPrice("CourvoisierXO");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 21)
            {
                onSellPrice("CremeDeCassis");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 22)
            {
                onSellPrice("Disaronno");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 23)
            {
                onSellPrice("EristoffVodka");
                SetPrices();
            }

            // -----------------------------------------------FOURTH--------------------------------------------------------------
        }

        public void onMl25SellPriceInput(object sender, EventArgs e)
        {
            if (spiritSelect.SelectedIndex == 0)
            {
                onMl25SellPrice("Aberlour10YearOld");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 1)
            {
                onMl25SellPrice("AbsolutOriginal");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 2)
            {
                onMl25SellPrice("Aperol");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 3)
            {
                onMl25SellPrice("ArchersWhiskey");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 4)
            {
                onMl25SellPrice("BacardiCartaBlanca");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 5)
            {
                onMl25SellPrice("Baileys");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 6)
            {
                onMl25SellPrice("Beefeater");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 7)
            {
                onMl25SellPrice("BlueMonkeyGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 8)
            {
                onMl25SellPrice("BlueMonkeyMangoAndPassionFruitGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 9)
            {
                onMl25SellPrice("BlueMonkeyRhubarbAndCustardGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 10)
            {
                onMl25SellPrice("BlueMonkeySaltedCaramelGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 11)
            {
                onMl25SellPrice("BlueMonkeySevilleOrangeGin");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 12)
            {
                onMl25SellPrice("BlueMonkeySummerBerries");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 13)
            {
                onMl25SellPrice("BombaySapphire");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 14)
            {
                onMl25SellPrice("Bowmore12YrsOld");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 15)
            {
                onMl25SellPrice("BulleitBourbonFrontierWhiskey");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 16)
            {
                onMl25SellPrice("Campari");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 17)
            {
                onMl25SellPrice("CaptainMorgan");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 18)
            {
                onMl25SellPrice("CaptainMorganSpicedRum");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 19)
            {
                onMl25SellPrice("Cointreau");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 20)
            {
                onMl25SellPrice("CourvoisierXO");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 21)
            {
                onMl25SellPrice("CremeDeCassis");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 22)
            {
                onMl25SellPrice("Disaronno");
                SetPrices();
            }
            else if (spiritSelect.SelectedIndex == 23)
            {
                onMl25SellPrice("EristoffVodka");
                SetPrices();
            }

            // ------------------------------------------END-------------------------------------------



        }
        public void SetPrices()
        {
            buyPriceInput.Text = buyPriceText.Text;
            sellPriceInput.Text = sellPriceText.Text;
            ml25sellPriceInput.Text = ml25PriceText.Text;
        }


        public Spirits()
        {
            InitializeComponent();

            spiritSelect.SelectedIndex = 0;
            DownloadFiles();

            SetPrices();

            Title = "Spirits";

        }
    }
}

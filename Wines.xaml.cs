using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace BeveragePrices.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    

    
    public partial class Wines : ContentPage
    {

        public string WinePathName(string wine)
        {
            string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), wine + ".wine");
            return _fileName;
        }

        public void WineSave(string wine, decimal buyPriceWine, decimal sellPriceWine, decimal ml125Price, decimal ml175Price, decimal ml250Price)
        {

            File.WriteAllText(WinePathName(wine), wine + ";" + buyPriceWine + ";" + sellPriceWine + ";" + ml125Price + ";" + ml175Price + ";" + ml250Price + ";");

        }

        public decimal GetWineBuyPrice(string wine)
        {
            if (File.Exists(WinePathName(wine)))
            {
                string allText = File.ReadAllText(WinePathName(wine));
                string[] separated = allText.Split(';');
                return decimal.Parse(separated[1]);
            }
            else
            {
                return 0;
            }
        }

        public decimal GetWineSellPrice(string wine)
        {
            if (File.Exists(WinePathName(wine)))
            {
                string allText = File.ReadAllText(WinePathName(wine));
                string[] separated = allText.Split(';');
                return decimal.Parse(separated[2]);
            }
            else
            {
                return 0;
            }
        }

        public decimal GetWineMl125Price(string wine)
        {
            if (File.Exists(WinePathName(wine)))
            {
                string allText = File.ReadAllText(WinePathName(wine));
                string[] separated = allText.Split(';');
                return decimal.Parse(separated[3]);
            }
            else
            {
                return 0;
            }
        }

        public decimal GetWineMl175Price(string wine)
        {
            if (File.Exists(WinePathName(wine)))
            {
                string allText = File.ReadAllText(WinePathName(wine));
                string[] separated = allText.Split(';');
                return decimal.Parse(separated[4]);
            }
            else
            {
                return 0;
            }
        }

        public decimal GetWineMl250Price(string wine)
        {
            if (File.Exists(WinePathName(wine)))
            {
                string allText = File.ReadAllText(WinePathName(wine));
                string[] separated = allText.Split(';');
                return decimal.Parse(separated[5]);
            }
            else
            {
                return 0;
            }
        }

        public void WineIn(string wine)
        {
            wineImage.Source = wine + ".jpg";
            buyPriceTextWine.Text = GetWineBuyPrice(wine).ToString();
            sellPriceTextWine.Text = GetWineSellPrice(wine).ToString();
            ml125PriceText.Text = GetWineMl125Price(wine).ToString();
            ml175PriceText.Text = GetWineMl175Price(wine).ToString();
            ml250PriceText.Text = GetWineMl250Price(wine).ToString();            
            profitPerBottleTextWine.Text = (GetWineSellPrice(wine) - GetWineBuyPrice(wine)).ToString();

        }


        

        public void onBuyPriceWine(string wine)
        {
            WineSave(wine, decimal.Parse(buyPriceInputWine.Text), GetWineSellPrice(wine), GetWineMl125Price(wine), GetWineMl175Price(wine), GetWineMl250Price(wine));
            WineIn(wine);
        }

        public void onSellPriceWine(string wine)
        {
            WineSave(wine, GetWineBuyPrice(wine), decimal.Parse(sellPriceInputWine.Text), GetWineMl125Price(wine), GetWineMl175Price(wine), GetWineMl250Price(wine));
            WineIn(wine);
        }

        public void onMl125SellPrice(string wine)
        {
            WineSave(wine, GetWineBuyPrice(wine), GetWineSellPrice(wine), decimal.Parse(ml125sellPriceInput.Text), GetWineMl175Price(wine), GetWineMl250Price(wine));
            WineIn(wine);
        }

        public void onMl175SellPrice(string wine)
        {
            WineSave(wine, GetWineBuyPrice(wine), GetWineSellPrice(wine), GetWineMl125Price(wine), decimal.Parse(ml175sellPriceInput.Text), GetWineMl250Price(wine));
            WineIn(wine);
        }

        public void onMl250SellPrice(string wine)
        {
            WineSave(wine, GetWineBuyPrice(wine), GetWineSellPrice(wine), GetWineMl125Price(wine), GetWineMl175Price(wine), decimal.Parse(ml250sellPriceInput.Text));
            WineIn(wine);
        }

        public void onWineSelect(object sender, EventArgs e)
        {
            if (wineSelect.SelectedIndex == 0)
            {
                WineIn("BerriEstatesChardonnay");
                SetPrices();
            }
            else if (wineSelect.SelectedIndex == 1)
            {
                WineIn("BollaPinotGrigio");
                SetPrices();
            }
        }

        public void onBuyPriceInputWine(object sender, EventArgs e)
        {
            if (wineSelect.SelectedIndex == 0)
            {
                onBuyPriceWine("BerriEstatesChardonnay");
                SetPrices();
            }
            else if (wineSelect.SelectedIndex == 1)
            {
                onBuyPriceWine("BollaPinotGrigio");
                SetPrices();
            }
        }

        public void onSellPriceInputWine(object sender, EventArgs e)
        {
            if (wineSelect.SelectedIndex == 0)
            {
                onSellPriceWine("BerriEstatesChardonnay");
                SetPrices();
            }
            else if (wineSelect.SelectedIndex == 1)
            {
                onSellPriceWine("BollaPinotGrigio");
                SetPrices();
            }
        }

        public void onMl125SellPriceInputWine(object sender, EventArgs e)
        {
            if (wineSelect.SelectedIndex == 0)
            {
                onMl125SellPrice("BerriEstatesChardonnay");
                SetPrices();
            }
            else if (wineSelect.SelectedIndex == 1)
            {
                onMl125SellPrice("BollaPinotGrigio");
                SetPrices();
            }
        }

        public void onMl175SellPriceInputWine(object sender, EventArgs e)
        {
            if (wineSelect.SelectedIndex == 0)
            {
                onMl175SellPrice("BerriEstatesChardonnay");
                SetPrices();
            }
            else if (wineSelect.SelectedIndex == 1)
            {
                onMl175SellPrice("BollaPinotGrigio");
                SetPrices();
            }
        }

        public void onMl250SellPriceInputWine(object sender, EventArgs e)
        {
            if (wineSelect.SelectedIndex == 0)
            {
                onMl250SellPrice("BerriEstatesChardonnay");
                SetPrices();
            }
            else if (wineSelect.SelectedIndex == 1)
            {
                onMl250SellPrice("BollaPinotGrigio");
                SetPrices();
            }
        }

        public void onExportExcelWine(object sender, EventArgs e)
        {
            DisplayAlert("Expot to Excel", "This feature is not available yet.", "OK");
        }

        public void onExportPDFWine(object sender, EventArgs e)
        {
            DisplayAlert("Export to PDF", "This feature is not available yet.", "OK");
        }

        public void onSendViaEmailWine(object sender, EventArgs e)
        {
            DisplayAlert("Send via Email", "This feature is not available yet.", "OK");
        }

        public void SetPrices()
        {
            buyPriceInputWine.Text = buyPriceTextWine.Text;
            sellPriceInputWine.Text = sellPriceTextWine.Text;
            ml125sellPriceInput.Text = ml125PriceText.Text;
            ml175sellPriceInput.Text = ml175PriceText.Text;
            ml250sellPriceInput.Text = ml250PriceText.Text;

        }

        public Wines()
        {
            InitializeComponent();

            Title = "Wines";

            wineSelect.SelectedIndex = 0;

            SetPrices();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
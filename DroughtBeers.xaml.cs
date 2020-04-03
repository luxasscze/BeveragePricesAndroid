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
    public partial class DroughtBeers : ContentPage
    {


        public string DroughtBeerPathName(string droughtBeer)
        {
            string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), droughtBeer + ".drought");
            return _fileName;
        }

        public void DroughtBeerSave(string droughtBeer, decimal buyPriceDroughtBeer, decimal sellPriceDroughtBeer, decimal pintSellPriceDroughtBeer, decimal halfPintSellPriceDroughtBeer)
        {

            File.WriteAllText(DroughtBeerPathName(droughtBeer), droughtBeer + ";" + buyPriceDroughtBeer + ";" + sellPriceDroughtBeer + ";" + pintSellPriceDroughtBeer + ";" + halfPintSellPriceDroughtBeer + ";");

        }

        public decimal GetDroughtBeerBuyPrice(string droughtBeer)
        {
            if (File.Exists(DroughtBeerPathName(droughtBeer)))
            {
                string allText = File.ReadAllText(DroughtBeerPathName(droughtBeer));
                string[] separated = allText.Split(';');
                return decimal.Parse(separated[1]);
            }
            else
            {
                return 0;
            }
        }

        public decimal GetDroughtBeerSellPrice(string droughtBeer)
        {
            if (File.Exists(DroughtBeerPathName(droughtBeer)))
            {
                string allText = File.ReadAllText(DroughtBeerPathName(droughtBeer));
                string[] separated = allText.Split(';');
                return decimal.Parse(separated[2]);
            }
            else
            {
                return 0;
            }
        }

        public decimal GetDroughtBeerPintSellPrice(string droughtBeer)
        {
            if (File.Exists(DroughtBeerPathName(droughtBeer)))
            {
                string allText = File.ReadAllText(DroughtBeerPathName(droughtBeer));
                string[] separated = allText.Split(';');
                return decimal.Parse(separated[3]);
            }
            else
            {
                return 0;
            }
        }

        public decimal GetDroughtBeerHalfPintSellPrice(string droughtBeer)
        {
            if (File.Exists(DroughtBeerPathName(droughtBeer)))
            {
                string allText = File.ReadAllText(DroughtBeerPathName(droughtBeer));
                string[] separated = allText.Split(';');
                return decimal.Parse(separated[4]);
            }
            else
            {
                return 0;
            }
        }

        public void DroughtBeerIn(string droughtBeer)
        {
            droughtBeerImage.Source = droughtBeer + ".jpg";
            buyPriceTextDroughtBeer.Text = GetDroughtBeerBuyPrice(droughtBeer).ToString();
            sellPriceTextDroughtBeer.Text = GetDroughtBeerSellPrice(droughtBeer).ToString();
            pintSellPriceTextDroughtBeer.Text = GetDroughtBeerPintSellPrice(droughtBeer).ToString();
            halfPintSellPriceTextDroughtBeer.Text = GetDroughtBeerHalfPintSellPrice(droughtBeer).ToString();
            profitPerBarrelTextDroughtBeer.Text = (GetDroughtBeerSellPrice(droughtBeer) - GetDroughtBeerBuyPrice(droughtBeer)).ToString();

        }

        public void onBuyPriceDroughtBeer(string droughtBeer)
        {
            DroughtBeerSave(droughtBeer, decimal.Parse(buyPriceInputDroughtBeer.Text), GetDroughtBeerSellPrice(droughtBeer), GetDroughtBeerPintSellPrice(droughtBeer), GetDroughtBeerHalfPintSellPrice(droughtBeer));
            DroughtBeerIn(droughtBeer);
        }

        public void onSellPriceDroughtBeer(string droughtBeer)
        {
            DroughtBeerSave(droughtBeer, GetDroughtBeerBuyPrice(droughtBeer), decimal.Parse(sellPriceInputDroughtBeer.Text), GetDroughtBeerPintSellPrice(droughtBeer), GetDroughtBeerHalfPintSellPrice(droughtBeer));
            DroughtBeerIn(droughtBeer);
        }

        public void onPintSellPriceDroughtBeer(string droughtBeer)
        {
            DroughtBeerSave(droughtBeer, GetDroughtBeerBuyPrice(droughtBeer), GetDroughtBeerSellPrice(droughtBeer), decimal.Parse(pintSellPriceInputDroughtBeer.Text), GetDroughtBeerHalfPintSellPrice(droughtBeer));
            DroughtBeerIn(droughtBeer);
        }

        public void onHalfPintSellPriceDroughtBeer(string droughtBeer)
        {
            DroughtBeerSave(droughtBeer, GetDroughtBeerBuyPrice(droughtBeer), GetDroughtBeerSellPrice(droughtBeer), GetDroughtBeerPintSellPrice(droughtBeer), decimal.Parse(halfPintSellPriceInputDroughtBeer.Text));
            DroughtBeerIn(droughtBeer);
        }

        public void onDroughtBeerSelect(object sender, EventArgs e)
        {
            if (droughtBeerSelect.SelectedIndex == 0)
            {
                DroughtBeerIn("BudweiserLight");
                SetPrices();
            }
            else if (droughtBeerSelect.SelectedIndex == 1)
            {
                DroughtBeerIn("StellaArtois");
                SetPrices();
            }
            else if (droughtBeerSelect.SelectedIndex == 2)
            {
                DroughtBeerIn("CamdenPaleAle");
                SetPrices();
            }
        }

        public void onBuyPriceInputDroughtBear(object sender, EventArgs e)
        {
            if (droughtBeerSelect.SelectedIndex == 0)
            {
                onBuyPriceDroughtBeer("BudweiserLight");
                SetPrices();
            }
            else if (droughtBeerSelect.SelectedIndex == 1)
            {
                onBuyPriceDroughtBeer("StellaArtois");
                SetPrices();
            }
            else if (droughtBeerSelect.SelectedIndex == 2)
            {
                onBuyPriceDroughtBeer("CamdenPaleAle");
                SetPrices();
            }
        }

        public void onSellPriceInputDroughtBeer(object sender, EventArgs e)
        {
            if (droughtBeerSelect.SelectedIndex == 0)
            {
                onSellPriceDroughtBeer("BudweiserLight");
                SetPrices();
            }
            else if (droughtBeerSelect.SelectedIndex == 1)
            {
                onSellPriceDroughtBeer("StellaArtois");
                SetPrices();
            }
            else if (droughtBeerSelect.SelectedIndex == 2)
            {
                onSellPriceDroughtBeer("CamdenPaleAle");
                SetPrices();
            }
        }

        public void onPintSellPriceInputDroughtBeer(object sender, EventArgs e)
        {
            if (droughtBeerSelect.SelectedIndex == 0)
            {
                onPintSellPriceDroughtBeer("BudweiserLight");
                SetPrices();
            }
            else if (droughtBeerSelect.SelectedIndex == 1)
            {
                onPintSellPriceDroughtBeer("StellaArtois");
                SetPrices();
            }
            else if (droughtBeerSelect.SelectedIndex == 2)
            {
                onPintSellPriceDroughtBeer("CamdenPaleAle");
                SetPrices();
            }
        }

        public void onHalfPintSellPriceInputDroughtBeer(object sender, EventArgs e)
        {
            if (droughtBeerSelect.SelectedIndex == 0)
            {
                onHalfPintSellPriceDroughtBeer("BudweiserLight");
                SetPrices();
            }
            else if (droughtBeerSelect.SelectedIndex == 1)
            {
                onHalfPintSellPriceDroughtBeer("StellaArtois");
                SetPrices();
            }
            else if (droughtBeerSelect.SelectedIndex == 2)
            {
                onHalfPintSellPriceDroughtBeer("CamdenPaleAle");
                SetPrices();
            }
        }

        public void onExportExcelDroughtBeer(object sender, EventArgs e)
        {
            DisplayAlert("Expot to Excel", "This feature is not available yet.", "OK");
        }

        public void onExportPDFDroughtBeer(object sender, EventArgs e)
        {
            DisplayAlert("Export to PDF", "This feature is not available yet.", "OK");
        }

        public void onSendViaEmailDroughtBeer(object sender, EventArgs e)
        {
            DisplayAlert("Send via Email", "This feature is not available yet.", "OK");
        }

        public void SetPrices()
        {
            buyPriceInputDroughtBeer.Text = buyPriceTextDroughtBeer.Text;
            sellPriceInputDroughtBeer.Text = sellPriceTextDroughtBeer.Text;
            pintSellPriceInputDroughtBeer.Text = pintSellPriceTextDroughtBeer.Text;
            halfPintSellPriceInputDroughtBeer.Text = halfPintSellPriceTextDroughtBeer.Text;

        }


        public DroughtBeers()
        {
            InitializeComponent();

            Title = "Drought Beers";

            droughtBeerSelect.SelectedIndex = 0;

            SetPrices();
        }
    }
}
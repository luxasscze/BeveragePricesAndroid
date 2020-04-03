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
    public partial class BottledBeers : ContentPage
    {


        public string BottledBeerPathName(string bottledBeer)
        {
            string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), bottledBeer + ".bottled");
            return _fileName;
        }

        public void BottledBeerSave(string bottledBeer, decimal buyPriceBottledBeer, decimal sellPriceBottledBeer)
        {

            File.WriteAllText(BottledBeerPathName(bottledBeer), bottledBeer + ";" + buyPriceBottledBeer  + ";" + sellPriceBottledBeer + ";");

        }

        public decimal GetBottledBeerBuyPrice(string bottledBeer)
        {
            if (File.Exists(BottledBeerPathName(bottledBeer)))
            {
                string allText = File.ReadAllText(BottledBeerPathName(bottledBeer));
                string[] separated = allText.Split(';');
                return decimal.Parse(separated[1]);
            }
            else
            {
                return 0;
            }
        }

        public decimal GetBottledBeerSellPrice(string bottledBeer)
        {
            if (File.Exists(BottledBeerPathName(bottledBeer)))
            {
                string allText = File.ReadAllText(BottledBeerPathName(bottledBeer));
                string[] separated = allText.Split(';');
                return decimal.Parse(separated[2]);
            }
            else
            {
                return 0;
            }
        }

        public void BottledBeerIn(string bottledBeer)
        {
            bottledBeerImage.Source = bottledBeer + ".jpg";
            buyPriceTextBottledBeer.Text = GetBottledBeerBuyPrice(bottledBeer).ToString();
            sellPriceTextBottledBeer.Text = GetBottledBeerSellPrice(bottledBeer).ToString();            
            profitPerBottleTextBottledBeer.Text = (GetBottledBeerSellPrice(bottledBeer) - GetBottledBeerBuyPrice(bottledBeer)).ToString();

        }

        public void onBuyPriceBottledBeer(string bottledBeer)
        {
            BottledBeerSave(bottledBeer, decimal.Parse(buyPriceInputBottledBeer.Text), GetBottledBeerSellPrice(bottledBeer));
            BottledBeerIn(bottledBeer);
        }

        public void onSellPriceBottledBeer(string bottledBeer)
        {
            BottledBeerSave(bottledBeer, GetBottledBeerBuyPrice(bottledBeer), decimal.Parse(sellPriceInputBottledBeer.Text));
            BottledBeerIn(bottledBeer);
        }

        public void onBottledBeerSelect(object sender, EventArgs e)
        {
            if (bottledBeerSelect.SelectedIndex == 0)
            {
                BottledBeerIn("BudweiserNrb");
                SetPrices();
            }
            else if (bottledBeerSelect.SelectedIndex == 1)
            {
                BottledBeerIn("BudweiserProhibition");
                SetPrices();
            }
        }

        public void onBuyPriceInputBottledBear(object sender, EventArgs e)
        {
            if (bottledBeerSelect.SelectedIndex == 0)
            {
                onBuyPriceBottledBeer("BudweiserNrb");
                SetPrices();
            }
            else if (bottledBeerSelect.SelectedIndex == 1)
            {
                onBuyPriceBottledBeer("BudweiserProhibition");
                SetPrices();
            }
        }

        public void onSellPriceInputBottledBeer(object sender, EventArgs e)
        {
            if (bottledBeerSelect.SelectedIndex == 0)
            {
                onSellPriceBottledBeer("BudweiserNrb");
                SetPrices();
            }
            else if (bottledBeerSelect.SelectedIndex == 1)
            {
                onSellPriceBottledBeer("BudweiserProhibition");
                SetPrices();
            }
        }

        public void onExportExcelBottledBeer(object sender, EventArgs e)
        {
            DisplayAlert("Expot to Excel", "This feature is not available yet.", "OK");
        }

        public void onExportPDFBottledBeer(object sender, EventArgs e)
        {
            DisplayAlert("Export to PDF", "This feature is not available yet.", "OK");
        }

        public void onSendViaEmailBottledBeer(object sender, EventArgs e)
        {
            DisplayAlert("Send via Email", "This feature is not available yet.", "OK");
        }

        public void SetPrices()
        {
            buyPriceInputBottledBeer.Text = buyPriceTextBottledBeer.Text;
            sellPriceInputBottledBeer.Text = sellPriceTextBottledBeer.Text;
            
        }


        public BottledBeers()
        {
            InitializeComponent();

            Title = "Bottled Beers";

            bottledBeerSelect.SelectedIndex = 0;
            SetPrices();
            
        }

        private void buyPriceInputBottledBeer_Unfocused(object sender, FocusEventArgs e)
        {

        }
    }
}
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
    public partial class SoftDrinks : ContentPage
    {


        public string SoftDrinkPathName(string softDrink)
        {
            string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), softDrink + ".soft");
            return _fileName;
        }

        public void SoftDrinkSave(string softDrink, decimal buyPriceSoftDrink, decimal sellPriceSoftDrink)
        {

            File.WriteAllText(SoftDrinkPathName(softDrink), softDrink + ";" + buyPriceSoftDrink + ";" + sellPriceSoftDrink + ";");

        }

        public decimal GetSoftDrinkBuyPrice(string softDrink)
        {
            if (File.Exists(SoftDrinkPathName(softDrink)))
            {
                string allText = File.ReadAllText(SoftDrinkPathName(softDrink));
                string[] separated = allText.Split(';');
                return decimal.Parse(separated[1]);
            }
            else
            {
                return 0;
            }
        }

        public decimal GetSoftDrinkSellPrice(string softDrink)
        {
            if (File.Exists(SoftDrinkPathName(softDrink)))
            {
                string allText = File.ReadAllText(SoftDrinkPathName(softDrink));
                string[] separated = allText.Split(';');
                return decimal.Parse(separated[2]);
            }
            else
            {
                return 0;
            }
        }

        public void SoftDrinkIn(string softDrink)
        {
            
            softDrinkImage.Source = softDrink + ".jpg";
            buyPriceTextSoftDrink.Text = GetSoftDrinkBuyPrice(softDrink).ToString();
            sellPriceTextSoftDrink.Text = GetSoftDrinkSellPrice(softDrink).ToString();
            profitPerBottleTextSoftDrink.Text = (GetSoftDrinkSellPrice(softDrink) - GetSoftDrinkBuyPrice(softDrink)).ToString();

        }

        public void onBuyPriceSoftDrink(string softDrink)
        {
            SoftDrinkSave(softDrink, decimal.Parse(buyPriceInputSoftDrink.Text), GetSoftDrinkSellPrice(softDrink));
            SoftDrinkIn(softDrink);
        }

        public void onSellPriceSoftDrink(string softDrink)
        {
            SoftDrinkSave(softDrink, GetSoftDrinkBuyPrice(softDrink), decimal.Parse(sellPriceInputSoftDrink.Text));
            SoftDrinkIn(softDrink);
        }


        public void Helper(int type, int index, string softDrink) /// TODO: Try to implement more effecient solution! 31/3/2020 14:20
        {
            
            
            if (type == 0) // IN
            {
                if (softDrinkSelect.SelectedIndex == index)
                {
                    SoftDrinkIn(softDrink);
                }
                
            }
            else if (type == 1) // BUY
            {
                if (softDrinkSelect.SelectedIndex == 0)
                {
                    onBuyPriceSoftDrink("AngosturaBitters");
                }
                else if (softDrinkSelect.SelectedIndex == 1)
                {
                    onBuyPriceSoftDrink("AngosturaOrangeBitters");
                }
            }
            else if (type == 2) // SELL
            {
                if (softDrinkSelect.SelectedIndex == 0)
                {
                    onSellPriceSoftDrink("AngosturaBitters");
                }
                else if (softDrinkSelect.SelectedIndex == 1)
                {
                    onSellPriceSoftDrink("AngosturaOrangeBitters");
                }
            }
        }

            public void onSoftDrinkSelect(object sender, EventArgs e)
            {
                if (softDrinkSelect.SelectedIndex == 0)
                {
                    SoftDrinkIn("AngosturaBitters");
                    SetPrices();
            }
                else if (softDrinkSelect.SelectedIndex == 1)
                {
                    SoftDrinkIn("AngosturaOrangeBitters");
                    SetPrices();
            }
            }

            public void onBuyPriceInputSoftDrink(object sender, EventArgs e)
            {
                if (softDrinkSelect.SelectedIndex == 0)
                {
                    onBuyPriceSoftDrink("AngosturaBitters");
                    SetPrices();
            }
                else if (softDrinkSelect.SelectedIndex == 1)
                {
                    onBuyPriceSoftDrink("AngosturaOrangeBitters");
                    SetPrices();
            }
            }

            public void onSellPriceInputSoftDrink(object sender, EventArgs e)
            {
                if (softDrinkSelect.SelectedIndex == 0)
                {
                    onSellPriceSoftDrink("AngosturaBitters");
                    SetPrices();
            }
                else if (softDrinkSelect.SelectedIndex == 1)
                {
                    onSellPriceSoftDrink("AngosturaOrangeBitters");
                    SetPrices();
            }
            }
        

        public void onExportExcelSoftDrink(object sender, EventArgs e)
        {
            DisplayAlert("Expot to Excel", "This feature is not available yet.", "OK");
        }

        public void onExportPDFSoftDrink(object sender, EventArgs e)
        {
            DisplayAlert("Export to PDF", "This feature is not available yet.", "OK");
        }

        public void onSendViaEmailSoftDrink(object sender, EventArgs e)
        {
            DisplayAlert("Send via Email", "This feature is not available yet.", "OK");
        }

        public void SetPrices()
        {
            buyPriceInputSoftDrink.Text = buyPriceTextSoftDrink.Text;
            sellPriceInputSoftDrink.Text = sellPriceTextSoftDrink.Text;

        }


        public SoftDrinks()
        {
            InitializeComponent();

            Title = "Soft Drinks";

            softDrinkSelect.SelectedIndex = 0;

            SetPrices();
        }
    }
}
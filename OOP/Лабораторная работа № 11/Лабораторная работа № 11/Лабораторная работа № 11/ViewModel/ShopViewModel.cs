using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа___11.ViewModel
{
    public class ShopViewModel : INotifyPropertyChanged
    {
        public SHOP Shop;
        public ShopViewModel(SHOP shop)
        {
            this.Shop = shop;
        }
        public int Id_Product
        {
            get 
            { 
                return Shop.ID_PRODUCT;
            }
            set
            {
                Shop.ID_PRODUCT = value;
                OnPropertyChanged("ID_PRODUCT");
            }
        }

        public string Name_Product
        {
            get
            {
                return Shop.NAME_PRODUCT;
            }
            set
            {
                Shop.NAME_PRODUCT = value;
                OnPropertyChanged("NAME_PRODUCT");
            }
        }

        public int Price_Product
        {
            get
            {
                return (int)Shop.PRICE_PRODUCT;
            }
            set
            {
                Shop.PRICE_PRODUCT = value;
                OnPropertyChanged("PRICE_PRODUCT");
            }
        }

        public int Count_Product
        {
            get 
            { 
                return (int)Shop.COUNT_PRODUCT;
            }
            set
            {
                Shop.COUNT_PRODUCT = value;
                OnPropertyChanged("COUNT_PRODUCT");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using Лабораторная_работа___11.Command;
//связывает модель и представление
//коллекция, которая умеет отслеживать изменения в себе.
namespace Лабораторная_работа___11.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<SHOP> shops;
        public ObservableCollection<SHOP> basket;
        public ICommand addToBasketCommand;
        public ICommand removeFromBasketCommand;

        public ObservableCollection<SHOP> Shops
        {
            get => shops;
            set
            {
                shops = value;
                OnPropertyChanged(nameof(Shops));
            }
        }
        public ObservableCollection<SHOP> Basket
        {
            get => basket;
            set
            {
                basket = value;
                OnPropertyChanged(nameof(Basket));
            }
        }

        public int TotalCount => GetTotalCount();

        public ICommand AddToBasketCommand
        {
            get
            {
                if (addToBasketCommand == null)
                {
                    addToBasketCommand = new RelayCommand(
                        param => AddToBasket(param as SHOP));
                }

                return addToBasketCommand;
            }
        }
        public ICommand RemoveFromBasketCommand
        {
            get
            {
                if (removeFromBasketCommand == null)
                {
                    removeFromBasketCommand = new RelayCommand(
                        param => RemoveFromBasket(param as SHOP),
                        param => CanRemoveFromBasket(param as SHOP));
                }

                return removeFromBasketCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel()
        {
            using (var db = new ApplicationContext())
            {
                Shops = new ObservableCollection<SHOP>(db.Shop.ToList());
            }
            Basket = new ObservableCollection<SHOP>();
        }

        public void AddToBasket(SHOP product)
        {
            if (product == null)
            {
                return;
            }
            product.COUNT_PRODUCT++;
            Basket.Add(product);
            OnPropertyChanged(nameof(TotalCount));
        }

        public void RemoveFromBasket(SHOP product)
        {
            if (product == null)
            {
                return;
            }
            product.COUNT_PRODUCT--;
            Basket.Remove(product);
            OnPropertyChanged(nameof(TotalCount));
        }

        public bool CanRemoveFromBasket(SHOP product)
        {
            return product != null && product.COUNT_PRODUCT != 0;
        }

        public int GetTotalCount()
        {
            return Basket.Count();
        }

    }
}

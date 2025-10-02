
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Grocery.App.ViewModels
{
    public partial class BestSellingProductsViewModel : BaseViewModel
    {
        private readonly IGroceryListItemsService _groceryListItemsService;
        private readonly IBestSellingProductsService _bestSellingProductsService;
        public ObservableCollection<BestSellingProducts> Products { get; set; } = [];
        public BestSellingProductsViewModel(IGroceryListItemsService groceryListItemsService, IBestSellingProductsService bestSellingProductsService)
        {
            _groceryListItemsService = groceryListItemsService;
            _bestSellingProductsService = bestSellingProductsService;
            Products = [];
            Load();
        }

        public override void Load()
        {
            Products.Clear();
            foreach (BestSellingProducts item in _bestSellingProductsService.GetBestSellingProducts())
            {
                Products.Add(item);
            }
        }

        public override void OnAppearing()
        {
            Load();
        }

        public override void OnDisappearing()
        {
            Products.Clear();
        }
    }
}

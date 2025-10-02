using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;


namespace Grocery.Core.Services
{
    public class BestSellingProductsService : IBestSellingProductsService
    {
        private readonly IGroceryListItemsRepository _groceriesRepository;
        private readonly IProductRepository _productRepository;

        public BestSellingProductsService(IGroceryListItemsRepository groceriesRepository, IProductRepository productRepository)
        {
            _groceriesRepository = groceriesRepository;
            _productRepository = productRepository;
        }
        public List<BestSellingProducts> GetBestSellingProducts(int amount = 5)
        {

            var BestProductList = new List<BestSellingProducts>();

            List<Product> allProducts = _productRepository.GetAll();
            List<GroceryListItem> groceries = _groceriesRepository.GetAll();

            // Start by looping through all items
            foreach(Product item in allProducts)
            {
                int soldAmount = 0;

                // Loop through items within the grocery lists
                foreach(GroceryListItem listedItem in groceries)
                {
                    // Check if ID matches, always unique
                    if(listedItem.ProductId == item.Id)
                    {
                        // If the item is within a grocery list, apply the amount
                        soldAmount += listedItem.Amount;
                    }
                }

                // Make a new best selling product, applying soldAmount
                // (amount of times present in a grocery list)
                BestSellingProducts soldProduct = new(item.Id, item.Name, item.Stock, soldAmount, 0);
                BestProductList.Add(soldProduct);
            }

            // Loop through the bestproductlist and order by descending based on sold amount
            // Then only take the top 5
            BestProductList = [.. BestProductList.OrderByDescending(
                product => product.NrOfSells
            ).Take(amount)];

            int rankingOrder = 1;
            foreach(BestSellingProducts product in BestProductList)
            {
                product.Ranking += rankingOrder;
                rankingOrder++;
            }

            return BestProductList;
        }
    }
}

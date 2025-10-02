
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class BoughtProductsService : IBoughtProductsService
    {
        private readonly IGroceryListItemsRepository _groceryListItemsRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IProductRepository _productRepository;
        private readonly IGroceryListRepository _groceryListRepository;
        public BoughtProductsService(IGroceryListItemsRepository groceryListItemsRepository, IGroceryListRepository groceryListRepository, IClientRepository clientRepository, IProductRepository productRepository)
        {
            _groceryListItemsRepository=groceryListItemsRepository;
            _groceryListRepository=groceryListRepository;
            _clientRepository=clientRepository;
            _productRepository=productRepository;
        }
        public List<BoughtProducts> Get(int? productId)
        {
            List<BoughtProducts> result = new List<BoughtProducts>();

              var listItems = _groceryListItemsRepository.GetAll()
                .Where(item => productId == null || item.ProductId == productId.Value)
                .ToList();

            foreach (var item in listItems)
            {
                // Get the grocery list for this item
                GroceryList? groceryList = _groceryListRepository.Get(item.GroceryListId);
                if (groceryList == null)
                    continue;

                // Get the client for the grocery list of the item
                Client? client = _clientRepository.Get(groceryList.ClientId); 
                if(client == null)
                    continue;

                // Get the product for this item
                Product? product = _productRepository.Get(item.ProductId);
                if(product == null)
                    continue;

                // Put everything together
                result.Add(new BoughtProducts(client, groceryList, product));
            }
            return result;
        }
    }
}

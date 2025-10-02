using Grocery.Core.Models;


namespace Grocery.Core.Interfaces.Services
{
    public interface IBestSellingProductsService
    {
        List<BestSellingProducts> GetBestSellingProducts(int amount = 5);
    }
}

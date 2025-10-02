namespace Grocery.Core.Models
{
    public class Product : Model
    {
        // Replace ObservableProperty<int> with a standard property and use SetProperty for change notification
        private int _stock;
        public int Stock
        {
            get => _stock;
            set => SetProperty(ref _stock, value);
        }

        public Product(int id, string name, int stock) : base(id, name)
        {
            Stock = stock;
        }
    }
}

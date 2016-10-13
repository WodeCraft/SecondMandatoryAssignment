using MbmStore.Models;

namespace MbmStore.ViewModels
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
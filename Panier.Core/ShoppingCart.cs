using System;
using System.Collections.Generic;
using System.Text;

namespace Panier.Core
{
    public sealed class ShoppingCart
    {
        private List<CartItem> _items = [];
        public int GetItemCount() => _items.Where(i => i.Quantity > 0).Sum(i => i.Quantity);
        public void AddItem(string name, decimal price, int quantity) => throw new NotImplementedException();
        public decimal GetTotal() => throw new NotImplementedException();
        public void ApplyDiscount(decimal percentage) => throw new NotImplementedException();
    }
}

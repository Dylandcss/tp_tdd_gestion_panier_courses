using System;
using System.Collections.Generic;
using System.Text;
using Panier.Core.Exceptions;

namespace Panier.Core
{
    public sealed class ShoppingCart
    {
        private List<CartItem> _items = [];
        public int GetItemCount() => _items.Where(i => i.Quantity > 0).Sum(i => i.Quantity);
        public void AddItem(string name, decimal price, int quantity) => _items.Add(new CartItem(name, price, quantity));
        public decimal GetTotal() => _items.Sum(i => i.Quantity * i.Price);

        public void ApplyDiscount(decimal percentage)
        {
            if (_items.Count == 0) throw new ShoppingCartEmptyException("The shopping cart is empty");
        }
    }
}

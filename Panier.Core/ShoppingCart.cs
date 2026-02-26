using System;
using System.Collections.Generic;
using System.Text;
using Panier.Core.Exceptions;

namespace Panier.Core
{
    public sealed class ShoppingCart
    {
        private List<CartItem> _items = [];
        private decimal _discountPercentage = 0m;
        public int GetItemCount() => _items.Where(i => i.Quantity > 0).Sum(i => i.Quantity);

        public void AddItem(string name, decimal price, int quantity)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new InvalidOperationException("Nom invalide.");
            if(price <= 0) throw new InvalidOperationException("Le prix doit être supérieur à zéro.");
            if (quantity <= 0) throw new InvalidOperationException("La quantité doit être supérieur à zéro.");
            _items.Add(new CartItem(name, price, quantity));
        }


        public decimal GetTotal()
        {
            var total = _items.Sum(i => i.Quantity * i.Price);

            if (_discountPercentage > 0)
            {
                var discountFactor = _discountPercentage / 100m;
                total -= total * discountFactor;
            }

            return total;
        }

        public void ApplyDiscount(decimal percentage)
        {
            if (_items.Count == 0)
                throw new ShoppingCartEmptyException("Le panier est vide.");

            if (percentage <= 0 || percentage > 100)
                throw new ArgumentException("Le pourcentage doit être entre 0 et 100.");

            _discountPercentage = Math.Round(percentage, 2);
        }
    }
}

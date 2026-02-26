using Panier.Core;
using Panier.Core.Exceptions;

namespace Panier.Tests;

[TestClass]
public class ShoppingCartTests
{
    private static ShoppingCart _setUp()
    {
        ShoppingCart shoppingCart = new();
        return shoppingCart;
    }
    
    [TestMethod]
    public void WhenGetItemCount_WithZeroArticles_ThenResultShouldBeZero()
    {
        var shoppingCart = _setUp();

        var expected = 0;
        
        var result = shoppingCart.GetItemCount();
        
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void WhenGetTotal_WithZeroArticles_ThenResultShouldBeZero()
    {
        var shoppingCart = _setUp();
        
        var expected = 0;
        
        var result = shoppingCart.GetTotal();
        
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void WhenApplyDiscount_WithZeroArticles_ThenShouldThrowException()
    {
        var shoppingCart = _setUp();
        Assert.Throws<ShoppingCartEmptyException>(() => shoppingCart.ApplyDiscount(0.8m));
    }
}

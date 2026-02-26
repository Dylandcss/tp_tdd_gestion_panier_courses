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
    
    [TestMethod]
    public void WhenAddItem_WithOneArticle_ThenResultShouldBeOne()
    {
        var shoppingCart = _setUp();
        var expected = 1;
        shoppingCart.AddItem("test", 2.50m, 1);
        var result = shoppingCart.GetItemCount();
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow(" ")]
    public void WhenAddItem_WithInvalidName_ThenShouldThrowException(string name)
    {
        var shoppingCart = _setUp();
        Assert.Throws<InvalidOperationException>(() => shoppingCart.AddItem(name, 2.50m, 1));
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(-1)]
    public void WhenAddItem_WithPriceUnderOrEqualToZero_ThenShouldThrowException(double price)
    {
        var shoppingCart = _setUp();
        Assert.Throws<InvalidOperationException>(() => shoppingCart.AddItem("test", (decimal)price, 1));
    }
}

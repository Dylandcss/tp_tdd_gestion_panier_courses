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
    
    [TestMethod]
    [DataRow(0)]
    [DataRow(-1)]
    public void WhenAddItem_WithQuantityUnderOrEqualToZero_ThenShouldThrowException(int quantity)
    {
        var shoppingCart = _setUp();
        Assert.Throws<InvalidOperationException>(() => shoppingCart.AddItem("test", 2m, quantity));
    }

    [TestMethod]
    public void WhenGetTotal_WithOneArticleAtFifty_ThenResultShouldBeFifty()
    {
        var shoppingCart = _setUp();
        shoppingCart.AddItem("test", 50m, 1);
        var expected = 50;
        var result = shoppingCart.GetTotal();
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void WhenGetTotal_WithTwoArticleAtFifty_ThenResultShouldBeOneHundred()
    {
        var shoppingCart = _setUp();
        shoppingCart.AddItem("test", 50m, 1);
        shoppingCart.AddItem("test", 50m, 1);
        var expected = 100;
        var result = shoppingCart.GetTotal();
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void WhenGetTotal_With10PercentDiscountApplied_ThenResultShouldBe45()
    {
        var shoppingCart = _setUp();
        shoppingCart.AddItem("test", 50m, 1);
        shoppingCart.ApplyDiscount(10m);
        var expected = 45;
        var result = shoppingCart.GetTotal();
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void WhenGetTotal_With0PercentDiscountApplied_ThenResultShouldBe50()
    {
        var shoppingCart = _setUp();
        shoppingCart.AddItem("test", 50m, 1);
        shoppingCart.ApplyDiscount(0m);
        var expected = 50;
        var result = shoppingCart.GetTotal();
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void WhenGetTotal_With100PercentDiscountApplied_ThenResultShouldBe0()
    {
        var shoppingCart = _setUp();
        shoppingCart.AddItem("test", 50m, 1);
        shoppingCart.ApplyDiscount(100m);
        var expected = 0;
        var result = shoppingCart.GetTotal();
        Assert.AreEqual(expected, result);
    }
    
}

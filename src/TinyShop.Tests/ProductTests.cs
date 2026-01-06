using DataEntities;

namespace TinyShop.Tests;

[TestClass]
public class ProductTests
{
    [TestMethod]
    public void Product_NewInstance_HasDefaultValues()
    {
        // Arrange & Act
        var product = new Product();

        // Assert
        Assert.AreEqual(0, product.Id);
        Assert.IsNull(product.Name);
        Assert.IsNull(product.Description);
        Assert.AreEqual(0m, product.Price);
        Assert.IsNull(product.ImageUrl);
    }
}

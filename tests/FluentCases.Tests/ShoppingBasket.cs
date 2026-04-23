namespace FluentCases.Tests;

sealed class ShoppingBasket
{
    public decimal Total { get; private set; }

    public int ItemCount { get; private set; }

    public void StartEmpty()
    {
        Total = 0m;
        ItemCount = 0;
    }

    public void AddItem(decimal price)
    {
        Total += price;
        ItemCount++;
    }

    public void TotalShouldBe(decimal amount)
    {
        Assert.Equal(amount, Total);
    }

    public void ItemCountShouldBe(int count)
    {
        Assert.Equal(count, ItemCount);
    }
}

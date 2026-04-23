namespace FluentCases.Tests;

public sealed class CaseTests
{
    [Fact]
    public void Adding_an_item_updates_total_and_count()
    {
        ShoppingBasket basket = new();

        Case
            .Given(basket, x => x.StartEmpty())
            .When(x => x.AddItem(price: 12.50m))
            .Then(x => x.TotalShouldBe(12.50m))
            .And(x => x.ItemCountShouldBe(1));
    }
}

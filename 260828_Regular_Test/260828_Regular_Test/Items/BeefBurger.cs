public class BeefBurger : Item, ISaleable
{
    private const float SALE_RATE = 0.8f;
    private const int SALE_COUNT = 3;

    public BeefBurger() : base("소고기 버거", 5900, ItemType.Hamburger) {

    }

    public override int GetPrice()
    {
        if (ItemCount >= SALE_COUNT)
        {
            return (int)(BasePrice * SALE_RATE);
        }

        return BasePrice;
    }
}
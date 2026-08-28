public class ChickenBurger : Item, ISaleable
{
    private const float SALE_RATE = 0.8f;
    private const int SALE_COUNT = 3;
    public ChickenBurger() : base("치킨 샌드위치", 5500, ItemType.Hamburger) {

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
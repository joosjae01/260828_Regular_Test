public class ChickenBurger : Item, ISaleable
{
    private const float SALE_RATE = 0.8f;
    public ChickenBurger() : base("치킨 샌드위치", 5500, ItemType.Hamburger) {

    }

    public int ApplySale()
    {
        return (int)(BasePrice * SALE_RATE);
    }
}
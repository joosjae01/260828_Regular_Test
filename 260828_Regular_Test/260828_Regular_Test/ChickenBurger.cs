public class ChickenBurger : Item, ISaleable
{
    private const float SALE_RATE = 0.8f;
    private const int SALE_COUNT = 3;
    public ChickenBurger() : base("치킨 샌드위치", 5500, ItemType.Hamburger) {

    }

    public override int GetPrice()
    {
        if (_ItemCount >= SALE_COUNT)
        {
            return (int)(BasePrice * SALE_RATE);
        }

        return BasePrice;
    }

    public override void PrintItem()
    {
        base.PrintItem();
        Console.WriteLine("[3개 이상 20% 할인]");
    }
}
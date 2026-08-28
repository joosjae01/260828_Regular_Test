public class BurgerBase : ItemBase, ISaleable
{
    private const float SALE_RATE = 0.8f;
    private const int SALE_COUNT = 3;

    public BurgerBase(string name, int price) : base(name, price, ItemType.Hamburger) {
        
    }

    public override int GetPrice()
    {
        return BasePrice;
    }

    public override void PrintItem()
    {
        base.PrintItem();
        Console.WriteLine("[3개 이상 20% 할인]");
    }

    public float GetSaleRate()
    {
        return SALE_RATE;
    }
}
public class FriedChicken : Item, ISaleable
{
    public FriedChicken() : base("후라이드 치킨", 13000, ItemType.Chicken) {

    }

    public int ApplySale(float SaleRate)
    {
        return (int)(BasePrice * SaleRate);
    }
}
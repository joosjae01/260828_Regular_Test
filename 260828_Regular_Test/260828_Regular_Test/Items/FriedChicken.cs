public class FriedChicken : Item
{
    public FriedChicken() : base("후라이드 치킨", 13000, ItemType.Chicken) {

    }

    public override int GetPrice()
    {
        return BasePrice;
    }
}
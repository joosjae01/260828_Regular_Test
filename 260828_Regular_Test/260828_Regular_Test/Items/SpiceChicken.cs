public class SpiceChicken : Item
{
    public SpiceChicken() : base("양념 치킨", 14000, ItemType.Chicken) {

    }

    public override int GetPrice()
    {
        return BasePrice;
    }
}
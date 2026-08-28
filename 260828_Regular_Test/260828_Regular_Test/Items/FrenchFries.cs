public class FrenchFries : Item
{
    public FrenchFries() : base("감자 튀김", 1500, ItemType.SideMenus) {

    }

    public override int GetPrice()
    {
        return BasePrice;
    }
}
public class SideMenuBase : ItemBase
{
    public SideMenuBase(string name, int price) : base(name, price, ItemType.SideMenus) {

    }

    public override int GetPrice()
    {
        return BasePrice;
    }

    public override void PrintItem()
    {
        base.PrintItem();
        Console.WriteLine("[정가]");
    }
}
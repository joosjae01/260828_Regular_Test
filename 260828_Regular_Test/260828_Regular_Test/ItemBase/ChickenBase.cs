public class ChickenBase : ItemBase
{
    public ChickenBase(string name, int price) : base(name, price, ItemType.Chicken) {

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
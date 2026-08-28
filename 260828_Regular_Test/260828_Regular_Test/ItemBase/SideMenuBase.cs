public class SideMenuBase : ItemBase
{
    private int _comboCount = 0;
    public SideMenuBase(string name, int price) : base(name, price, ItemType.SideMenus) {

    }

    public void InitComboCount()
    {
        _comboCount = 0;
    }

    public void IncreaseComboCount()
    {
        _comboCount++;
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
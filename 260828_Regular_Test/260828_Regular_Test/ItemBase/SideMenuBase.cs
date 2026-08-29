public class SideMenuBase : ItemBase, ISaleable
{
    private int _comboCount = 0;
    private const float SALE_RATE = 0.9f;
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

    public int GetComboCount()
    {
        return _comboCount;
    }

    public override int GetPrice()
    {
        return BasePrice;
    }

    public override void PrintItem()
    {
        base.PrintItem();
        Console.WriteLine("[버거 메뉴 하나 당 10% 할인]");
    }

    public float GetSaleRate()
    {
        return SALE_RATE;
    }
}
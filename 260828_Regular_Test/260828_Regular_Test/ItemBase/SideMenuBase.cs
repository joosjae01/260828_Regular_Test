public class SideMenuBase : ItemBase, ISaleable
{
    private int _comboCount = 0;
    private const float SALE_RATE = 0.7f;
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
        Console.WriteLine("[세트 메뉴 주문시 30% 할인]");
    }

    public int ApplySale()
    {
        return (int)(BasePrice * SALE_RATE);
    }
}
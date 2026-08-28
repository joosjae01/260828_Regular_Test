public class FrenchFries : Item, ISaleable
{
    private const float SALE_RATE = 0.8f;
    private bool _isSale = false;
    public FrenchFries() : base("감자 튀김", 1500, ItemType.SideMenus) {

    }

    public override int GetPrice()
    {
        if (_isSale)
        {
            _isSale = false;
            return (int)(BasePrice * SALE_RATE);
        }

        return BasePrice;
    }

    public void ApplySale()
    {
        _isSale = true;
    }
}
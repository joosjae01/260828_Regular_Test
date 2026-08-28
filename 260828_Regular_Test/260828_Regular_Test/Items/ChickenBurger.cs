public class ChickenBurger : Item, ISaleable
{
    private const float SALE_RATE = 0.8f;
    private bool _isSale = false;
    public ChickenBurger() : base("치킨 샌드위치", 5500, ItemType.Hamburger) {

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
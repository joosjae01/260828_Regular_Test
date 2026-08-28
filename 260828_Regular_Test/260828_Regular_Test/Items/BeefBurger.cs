public class BeefBurger : Item, ISaleable
{
    private const float SALE_RATE = 0.7f;
    private bool _isSale = false;

    public BeefBurger() : base("소고기 버거", 5900, ItemType.Hamburger) {

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
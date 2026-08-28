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
            return ApplySale();
        }

        return BasePrice;
    }
    public int ApplySale()
    {
        return (int)(BasePrice * SALE_RATE);
    }
}
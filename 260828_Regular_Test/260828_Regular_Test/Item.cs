public abstract class Item
{
    public int BasePrice {  get; set; }

    public Item(int price)
    {
        BasePrice = price;
    }

    public abstract void CalculatePrice();
}
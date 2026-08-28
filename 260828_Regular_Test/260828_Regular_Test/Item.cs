public abstract class Item
{
    public string Name { get; }
    public int BasePrice {  get; set; }

    public ItemType Type { get; set; }

    public Item(int price)
    {
        BasePrice = price;
    }

    public abstract void CalculatePrice();
}
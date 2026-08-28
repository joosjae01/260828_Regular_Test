public abstract class Item
{
    public string Name { get; }
    public int BasePrice {  get; }

    public ItemType Type { get;}

    public Item(string name, int price, ItemType type)
    {
        Name = name;
        BasePrice = price;
        Type = type;

    }

    public abstract int GetPrice();
}
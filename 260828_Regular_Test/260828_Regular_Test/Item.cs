public abstract class Item
{
    public string Name { get; }
    public int BasePrice {  get; }

    public ItemType Type { get;}
    public int ItemCount = 0;

    public Item(string name, int price, ItemType type)
    {
        Name = name;
        BasePrice = price;
        Type = type;

    }

    public abstract int GetPrice();
}
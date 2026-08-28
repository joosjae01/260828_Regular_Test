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

    public void PrintItem()
    {
        Console.Write($" {Name} ({Type}) {BasePrice}원\t");

        if(this is ISaleable)
        {
            Console.WriteLine("[3개 이상 10% 할인]");
        }
        else
        {
            Console.WriteLine("[정가]");
        }
    }
}
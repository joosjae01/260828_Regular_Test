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

    public virtual void PrintItem()
    {

        string korTypeName = "";

        switch (Type)
        {
            case ItemType.Chicken:
                korTypeName += "치킨";
                break;

            case ItemType.Hamburger:
                korTypeName += "버거";
                break;

            case ItemType.SideMenus:
                korTypeName += "간식";
                break;

            default:
                break;
        }

        Console.Write($"\t{Name}\t({korTypeName})\t\t{BasePrice}원\t");
    }
}
public class Kiosk
{
    private List<Item> _itemList = new List<Item>();
    public void AddItem(Item item)
    {
        _itemList.Add(item);
    }

    public void PutItem(User user, Item item)
    {
        user.AddItem(item);
        item.ItemCount++;
    }

    public void RefreshItem()
    {
        for(int i = 0; i < _itemList.Count; i++)
        {
            _itemList[i].ItemCount = 0;
        }
    }

    public void PrintInfo(User user)
    {
        Console.WriteLine("[장바구니]");

        int total = 0;

        foreach(Item item in _itemList)
        {
            if(item.ItemCount != 0)
            {
                Console.WriteLine($"{item.Name} x{item.ItemCount} {CalculatePrice(item)}");
                total += CalculatePrice(item);
            }

            Console.WriteLine(total);
        }
    }

    public int CalculatePrice(Item item)
    {
        int price = 0;
        
        for(int i = 0; i < item.ItemCount; i++)
        {
            price += item.GetPrice();
        }

        return price;
    }

}
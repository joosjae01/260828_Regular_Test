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
    public void PrintMenu()
    {
        Console.WriteLine("[메뉴판]");
        for (int i = 0; i < _itemList.Count; i++)
        {
            Console.Write($"  {i + 1}. {_itemList[i].Name} ({_itemList[i].Type}) {_itemList[i].GetPrice()}원\t");
            if (_itemList[i] is ISaleable)
            {
                Console.WriteLine("[세트 주문시 20% 할인]");
            }
            else
            {
                Console.WriteLine("[정가]");
            }
        }
    }

    public void PrintBasket(User user)
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
        }
        Console.WriteLine($"  합계 : {total}원");
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

    public void PurchaseBasket(User user)
    {

    }

}
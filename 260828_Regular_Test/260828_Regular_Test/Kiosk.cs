public class Kiosk
{
    private List<Item> _itemList = new List<Item>();
    private int _tempTotal = 0;
    public void AddItem(Item item)
    {
        _itemList.Add(item);
    }

    public void PutItem(User user, int index, int count)
    {
        for(int i  = 0; i < count; i++)
        {
            user.AddItem(_itemList[index]);
            _itemList[index].ItemCount++;
        }
    }

    public void RefreshItem(User user)
    {
        user.RefreshItem();
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
            Console.Write($"  {i + 1}. {_itemList[i].Name} ({_itemList[i].Type}) {_itemList[i].BasePrice}원\t");
            if (_itemList[i] is ISaleable)
            {
                Console.WriteLine("[3개 이상 주문시 20% 할인]");
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

        _tempTotal = 0;
        foreach(Item item in _itemList)
        {
            if(item.ItemCount != 0)
            {
                Console.WriteLine($"{item.Name} x{item.ItemCount} {CalculatePrice(item)}");
                _tempTotal += CalculatePrice(item);
            }
        }
        Console.WriteLine($"  합계 : {_tempTotal}원");
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
        if(user.TotalMoney >= _tempTotal)
        {
            user.SetTotalMoney(user.TotalMoney - _tempTotal);
        }
        else
        {

        }
    }

}
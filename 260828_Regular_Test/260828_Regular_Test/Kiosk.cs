public class Kiosk
{
    private List<Item> _itemList = new List<Item>();
    private int _tempTotal = 0;
    private int _totalPurchase = 0;
    private int _totalMoney = 0;

    public Kiosk(List<Item> items)
    {
        _itemList = items;
    }

    public int GetMenuSize()
    {
        return _itemList.Count;
    }

    public void PutToBasket(User user, int index, int count)
    {
        for(int i  = 0; i < count; i++)
        {
            user.AddItem(_itemList[index]);
            _itemList[index].ItemCount++;
        }

        Console.WriteLine($"{_itemList[index].Name} {count} 개를 장바구니에 정상적으로 담았습니다.");
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
            Console.Write($"  {i + 1}.");
            _itemList[i].PrintItem();
        }
    }
    public void PrintTotal()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("[영업 종료]");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"  총 결제 횟수 : {_totalPurchase}번");
        Console.WriteLine($"  총 결제 금액 : {_totalMoney}원");
    }

    public void PrintBasket(User user)
    {
        Console.WriteLine("[장바구니]");

        _tempTotal = 0;
        foreach(Item item in _itemList)
        {
            if(item.ItemCount != 0)
            {
                Console.WriteLine($"  {item.Name} x{item.ItemCount} {CalculatePrice(item)}원");
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
        Console.Clear();
        
        if (_tempTotal == 0)
        {
            Console.WriteLine("제품을 선택해주세요 !");
            return;
        }

        Console.WriteLine("----------------------------------------");
        PrintBasket(user);
        Console.WriteLine("----------------------------------------");

        user.SetTotalMoney(ConsoleInput.ReadIntAtLeast("받은 금액 : ", 0));
        if (user.TotalMoney >= _tempTotal)
        {
            user.SetTotalMoney(user.TotalMoney - _tempTotal);
            _totalPurchase++;
            _totalMoney += _tempTotal;
            RefreshItem(user);
            Console.WriteLine();
            Console.WriteLine($"{_tempTotal}원을 성공적으로 결제하였습니다 !");
            Console.WriteLine($"거스름돈 :  {user.TotalMoney}원");
        }
        else
        {
            Console.WriteLine("금액이 부족합니다 !");
        }
    }
}
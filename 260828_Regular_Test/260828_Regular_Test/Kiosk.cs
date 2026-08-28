public class Kiosk
{
    private List<ItemBase> _itemList = new List<ItemBase>();
    private int _tempTotal = 0;
    private int _totalPurchase = 0;
    private int _totalMoney = 0;

    public Kiosk(List<ItemBase> items)
    {
        _itemList = items;
    }

    public void AddMenu(ItemBase item)
    {
        _itemList.Add(item);
    }

    public int GetMenuSize()
    {
        return _itemList.Count;
    }

    public void PutToBasket(User<ItemBase> user, int index, int count)
    {
        for (int i = 0; i < count; i++)
        {
            user.AddItem(_itemList[index]);
            _itemList[index].IncreaseCount();
        }

        Console.WriteLine($"{_itemList[index].Name} {count} 개를 장바구니에 정상적으로 담았습니다.");
    }

    public void RefreshItem(User<ItemBase> user)
    {
        user.RefreshItem();
        for (int i = 0; i < _itemList.Count; i++)
        {
            _itemList[i].InitCount();
        }
    }
    public void PrintMenu()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("[메뉴판]");
        for (int i = 0; i < _itemList.Count; i++)
        {
            Console.Write($"  {i + 1}.");
            _itemList[i].PrintItem();
        }
        Console.WriteLine("----------------------------------------");
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

    public void PrintBasket(User<ItemBase> user)
    {
        if (user.GetBasketSize() > 0)
        {
            Console.WriteLine("[장바구니]");

            _tempTotal = 0;
            foreach (ItemBase item in _itemList)
            {
                if (item.GetCount() != 0)
                {
                    Console.WriteLine($"  {item.Name} x{item.GetCount()} {CalculatePrice(item)}원");
                    _tempTotal += CalculatePrice(item);
                }
            }
            Console.WriteLine($"  합계 : {_tempTotal}원");
            Console.WriteLine("----------------------------------------");
        }
    }

    public int CalculatePrice(ItemBase item)
    {
        int price = 0;

        for (int i = 0; i < item.GetCount(); i++)
        {
            price += item.GetPrice();
        }

        return price;
    }

    public void PurchaseBasket(User<ItemBase> user)
    {
        Console.Clear();

        if (_tempTotal == 0)
        {
            Console.WriteLine("제품을 선택하지 않았습니다 !");
            return;
        }

        Console.WriteLine("----------------------------------------");
        PrintBasket(user);

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
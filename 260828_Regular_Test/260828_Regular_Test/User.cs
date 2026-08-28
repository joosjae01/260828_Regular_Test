public class User
{
    public int TotalMoney { get; private set; }
    private List<Item> _basket = new List<Item>();

    public User(int totalMoney)
    {
        TotalMoney = totalMoney;
    }

    public void SetTotalMoney(int amount)
    {
        TotalMoney = amount;
    }

    public void AddItem(Item item)
    {
        _basket.Add(item);
    }

    public Item GetItem(int index)
    {
        return _basket[index];
    }

    public int GetBasketSize()
    {
        return _basket.Count;
    }

    public bool CheckItem(int index, ItemType type)
    {
        if(_basket[index].Type == type)
        {
            return true;
        }

        return false;
        
    }

    public void RefreshItem()
    {
        _basket.Clear();
    }
}
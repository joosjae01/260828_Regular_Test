public class User<T>
{
    public int TotalMoney { get; private set; }
    private List<T> _basket = new List<T>();

    public User()
    {
        TotalMoney = 0;
    }

    public void SetTotalMoney(int amount)
    {
        TotalMoney = amount;
    }

    public void AddItem(T item)
    {
        _basket.Add(item);
    }

    public void InitSideMenu()
    {
        foreach(T item in _basket)
        {
            if(item is SideMenuBase)
            {
                (item as SideMenuBase).InitComboCount();
            }
        }
    }

    public void IncreaseComboCount()
    {
        foreach(T item in _basket)
        {
            if(item is SideMenuBase)
            {
                (item as SideMenuBase).IncreaseComboCount();
            }
        }
    }

    public int GetBasketSize()
    {
        return _basket.Count;
    }

    public void RefreshItem()
    {
        InitSideMenu();
        _basket.Clear();
    }
}
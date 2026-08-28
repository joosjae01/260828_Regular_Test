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

    public T GetItem(int index)
    {
        return _basket[index];
    }

    public int GetBasketSize()
    {
        return _basket.Count;
    }

    public void RefreshItem()
    {
        _basket.Clear();
    }
}
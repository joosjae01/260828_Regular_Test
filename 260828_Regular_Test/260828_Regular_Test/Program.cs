//https://github.com/joosjae01/260828_Regular_Test

using System;

class Program
{
    static void Main(string[] args)
    {
        List<ItemBase> items = new List<ItemBase>
        {
            // 1. 치킨류 (ItemType.Chicken)
            new ChickenBase("후라이드 치킨", 13000),
            new ChickenBase("양념 치킨", 14000),
            
            // 2. 버거류 (ItemType.Hamburger)
            new BurgerBase("소고기 버거", 5900),
            new BurgerBase("치킨 샌드위치", 4900),
            
            // 3. 간식류 (ItemType.SideMenus)
            new SideMenuBase("감자 튀김", 2300)
        };

        Kiosk kiosk = new Kiosk(items);
        User<ItemBase> user = new User<ItemBase>();

        const string STORE_NAME = "로켓  치킨  &  버거";
        bool isWorking = true;

        while (isWorking)
        {
            PrintMainMenu(STORE_NAME, kiosk, user);
            isWorking = MainSequence(kiosk, user);
            ConsoleInput.Pause();
        }
    }

    public static void PrintMainMenu(string storeName, Kiosk kiosk, User<ItemBase> user)
    {
        Console.Clear();
        Console.WriteLine(storeName);
        Console.WriteLine();
        kiosk.PrintMenu();
        kiosk.PrintBasket(user);
        Console.WriteLine("  1. 담기\t3. 결제\n  2. 비우기\t4. 영업 종료\n");
    }

    public static bool MainSequence(Kiosk kiosk, User<ItemBase> user)
    {
        int option = ConsoleInput.ReadIntInRange("옵션 선택 : ", 1, 4);

        switch (option)
        {
            // 1. 담기
            case 1:
                Console.Clear();
                kiosk.PrintMenu();
                int orderNumber = ConsoleInput.ReadIntInRange("주문 메뉴 : ", 1, kiosk.GetMenuSize()) - 1;
                int orderCount = ConsoleInput.ReadIntAtLeast("주문 개수 : ", 0);

                kiosk.PutToBasket(user, orderNumber, orderCount);
                break;

            // 2. 비우기
            case 2:
                kiosk.RefreshItem(user);
                break;

            // 3. 결제
            case 3:
                kiosk.PurchaseBasket(user);
                break;

            // 4. 영업 종료
            case 4:
                kiosk.PrintTotal();
                return false;
        }

        return true;
    }
}
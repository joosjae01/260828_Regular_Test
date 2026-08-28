//https://github.com/joosjae01/260828_Regular_Test

using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        List<Item> items = new List<Item>
        {
            // 1. 치킨류 (ItemType.Chicken)
            new FriedChicken(),
            new SpiceChicken(),
            
            // 2. 버거류 (ItemType.Hamburger)
            new BeefBurger(),
            new ChickenBurger(),
            
            // 3. 간식류 (ItemType.SideMenus)
            new FrenchFries()
        };

        Kiosk kiosk = new Kiosk(items);
        User user = new User();

        const string STORE_NAME = "로켓  치킨  &  버거";
        bool isWorking = true;

        while (isWorking)
        {
            PrintMainMenu(STORE_NAME, kiosk, user);

            int option = ConsoleInput.ReadIntInRange("옵션 선택 : ", 1, 4);

            switch (option)
            {
                // 1. 담기
                case 1:
                    Console.Clear();
                    Console.WriteLine("----------------------------------------");
                    kiosk.PrintMenu();
                    Console.WriteLine("----------------------------------------");
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
                    isWorking = false;
                    break;
            }

            ConsoleInput.Pause();
        }
    }

    public static void PrintMainMenu(string storeName, Kiosk kiosk, User user)
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine(storeName);
        Console.WriteLine("----------------------------------------");
        kiosk.PrintMenu();
        Console.WriteLine("----------------------------------------");
        kiosk.PrintBasket(user);
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("1. 담기  2. 비우기  3. 결제  4. 영업 종료");
    }
}
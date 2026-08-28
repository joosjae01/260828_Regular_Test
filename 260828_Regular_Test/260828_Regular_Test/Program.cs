//https://github.com/joosjae01/260828_Regular_Test

using System;

class Program
{
    static void Main(string[] args)
    {
        const int USER_BASE_MONEY = 100000;

        List<Item> items = new List<Item>
        {
            // 1. 치킨류
            new FriedChicken(),
            new SpiceChicken(),
            
            // 2. 버거류
            new BeefBurger(),
            new ChickenBurger(),
            
            // 3. 간식류
            new FrenchFries()
        };

        Kiosk kiosk = new Kiosk(items);
        User user = new User(USER_BASE_MONEY);

        bool isWorking = true;

        while (isWorking)
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("로켓  치킨");
            Console.WriteLine("----------------------------------------");
            kiosk.PrintMenu();
            Console.WriteLine("----------------------------------------");
            kiosk.PrintBasket(user);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"사용자 잔액  :  {user.TotalMoney}원");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1. 담기  2. 전체 비우기  3. 결제  4. 영업 종료");

            int picked = ConsoleInput.ReadIntInRange("옵션 선택 : ", 1, 4);

            switch (picked)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("----------------------------------------");
                    kiosk.PrintMenu();
                    Console.WriteLine("----------------------------------------");
                    int orderNumber = ConsoleInput.ReadIntInRange("주문 메뉴 : ", 1, kiosk.GetMenuSize()) - 1;
                    int orderCount = ConsoleInput.ReadIntAtLeast("주문 개수 : ", 0);

                    kiosk.PutToBasket(user, orderNumber, orderCount);
                    break;

                case 2:
                    kiosk.RefreshItem(user);
                    break;

                case 3:
                    kiosk.PurchaseBasket(user);
                    break;

                case 4:
                    kiosk.PrintTotal();
                    isWorking = false;
                    break;
            }

            ConsoleInput.Pause();
        }
    }
}
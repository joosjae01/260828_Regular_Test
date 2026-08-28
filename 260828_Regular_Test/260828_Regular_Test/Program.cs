//https://github.com/joosjae01/260828_Regular_Test

using System;

class Program
{
    static void Main(string[] args)
    {
        const int MENU_SIZE = 5;

        BeefBurger beefBurger = new BeefBurger();
        ChickenBurger chickenBurger = new ChickenBurger();
        FrenchFries frenchFries = new FrenchFries();
        FriedChicken friedChicken = new FriedChicken();
        SpiceChicken spiceChicken = new SpiceChicken();

        Kiosk kiosk = new Kiosk();
        User user = new User(100000);
        // === 치킨류 ===
        kiosk.AddItem(friedChicken);
        kiosk.AddItem(spiceChicken);

        // === 버거류 ===
        kiosk.AddItem(beefBurger);
        kiosk.AddItem(chickenBurger);

        // === 사이드 ===
        kiosk.AddItem(frenchFries);

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
            int picked = ConsoleInput.ReadIntInRange("번호 : ", 1, 4);

            // 골라진 번호대로 처리하고 결과를 출력한다
            switch (picked)
            {
                case 1:
                    int menuNumber = ConsoleInput.ReadIntInRange("메뉴 번호 : ", 1, MENU_SIZE);
                    int count = ConsoleInput.ReadIntAtLeast("개수 : ", 0);

                    kiosk.PutItem(user, (menuNumber - 1), count);
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
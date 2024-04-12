namespace Etermium.Mechanic;

public class HomeGenerator
{
    private readonly object _obj = new();

    public static int Dollars { get; set; }

    public void Run()
    {
        Dollars = 0;
        while (true)
        {
            lock (_obj)
            {
                Dollars += 1;
            }

            try
            {
                Thread.Sleep(3000);
            }
            catch (Exception)
            {
                Console.WriteLine("Chyba ve třídě MoneyGenerator");
            }
        }
    }

    public static void CestaDom()
    {
        Console.WriteLine(" ___  ,--.  __________________________/   ,   /_______\r\n" + "    'O---O'~\r\n"
            + " _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _   ,--.   _ _ _ _ _\r\n"
            + "         _____                       ~'O---O'\r\n"
            + " _______|Domov >_____        __________________________\r\n" + "           ||      /   ,   /");
    }

    public static void SweetHome()
    {
        Console.WriteLine("\n\n           )\r\n" + "         ( _   _._\r\n" + "          |_|-'_~_`-._\r\n"
                          + "       _.-'-_~_-~_-~-_`-._\r\n" + "   _.-'_~-_~-_-~-_~_~-_~-_`-._\r\n"
                          + "  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\r\n" + "    |  []  []   []   []  [] |\r\n"
                          + "    |           __    ___   |\r\n"
                          + "  ._|  []  []  | .|  [___]  |_._._._._._._._._._._._._._._._._.\r\n"
                          + "  |=|________()|__|()_______|=|=|=|=|=|=|=|=|=|=|=|=|=|=|=|=|=|\r\n"
                          + "^^^^^^^^^^^^^^^ === ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\r\n" +
                          "   _________      ===\r\n"
                          + "  <_hráč/ka_>       ===\r\n" + "      ^|^             ===\r\n" +
                          "       |                ===\n\n");
    }

    public static void CestaZDom()
    {
        Console.WriteLine(" ___  ,--.  __________________________/   ,   /_______\r\n" + "    'O---O'~\r\n"
            + " _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _   ,--.   _ _ _ _ _\r\n"
            + "         _____                       ~'O---O'\r\n"
            + " _______< Menu|_____        __________________________\r\n" + "           ||      /   ,   /");
    }
}
using Etermium.Mechanic;

namespace Etermium.start_and_config;

public abstract class Password
{
    private const string GamePassword = "adf06566e521050416314c28eb6d4eaa";
    private const string AdminPassword = "21232f297a57a5a743894a0e4a801fc3";
    private static readonly AdminManager.AdminManager AdminManager = new();

    public static void PPassword()
    {
        Console.WriteLine("\n\n		    .. ..           \r\n" +
                          "		  o:  '  :o    \r\n"
                          + "		 o '.   .' o              \r\n" + "		  o _`.' _o          ..                 .. \r\n"
                          + "		   ('>  <`)         :  :               :  :\r\n"
                          + "		  (\\/)  (\\/)         ::     .''.''.     ::\r\n"
                          + "		  .\"\".  .\"\".  .''.  .''. .'';  ;  ;''. .''.  .''.  .''.  .''.\r\n"
                          + "		  |  |oo| ||  |  |  |  | |     ;  ;  | |  |  |  |  |  |oo|  |\r\n"
                          + "		--|  |--| d|--|  |--|  |-|  ;  ;  ;  |-|  |--|  |--|  |--|  |--\r\n"
                          + "		--|| |--|  |--|  |--|  |-|  ;     ;  |-|  |--|  |--|  |--|  |--\r\n"
                          + "		.o|b |  |  |o.|  |  |  | |     ;     | |  |  |  |.o|  |  |  |o.\r\n"
                          + "		o'|  |  |  |`o|  |  |  | |  ;     ; o| |  |  |  |o'|  |  |  |`o\r\n"
                          + "		o |  |  | || o|  |  |  | |  ;     ;  | |  |  |  |o |  |  |  | o\r\n"
                          + "		--|  |--| b|--|  |--|  |-|     ;  ;  |-|  |--|  |--|  |--|  |--\r\n"
                          + "		--|  |--|  |--|  |--|  |-|  ;  ;     |-|  |--|  |--|  |--|  |--\r\n"
                          + "		`o|  |  |  |o'|  |  |  | |  ;  ;  ;  | |  |  |  |`o|  |  |  |o'\r\n"
                          + "		 `|__|oo|__|' |__|  |__| |__;__;__;__| |__|  |__| `|__|oo|__|'\r\n"
                          + "		   \"\"    \"\"               ___________\r\n"
                          + "		  \"\"       \"\"      \"\"    /           \\\r\n"
                          + "		                        /\"\" WELCOME   \\ \r\n"
                          + "		                       /           \"\"  \\   \r\n"
                          + "		                       ~~~~~~~~~~~~~~~~~ ");

        Console.WriteLine("\n\n------------------------------------------------------------");
        Console.WriteLine(
            "(PROSÍM OKNO NA CELOU OBRAZOVKU - F11 nebo ALT + ENTER) \n\nPři hře budeš potřebovat českou klávesnici a pouze malá písmena, pouze jedno slovo, ale nepiš háčky a čárky.");

        Thread.Sleep(5000);

        var passwordAttempt = 5;
        while (passwordAttempt != 0)
        {
            Console.WriteLine(
                "První jednoduchá otázka, jak se jmenuje hra, kterou jsi právě spustil/a? (napiš přesně): ");
            var passwordEntered = Console.ReadLine()!.Trim();
            var hashPasswordEntered = Md5Hash.CalculateMd5Hash(passwordEntered!);

            if (hashPasswordEntered == GamePassword)
            {
                Console.WriteLine("------------------------------------");
                passwordAttempt = 0;
            }
            else if (hashPasswordEntered == AdminPassword)
            {
                AdminManager.ManagerAdmin();
            }
            else
            {
                passwordAttempt--;
                Console.WriteLine("\nZbývající počet pokusů: " + passwordAttempt);

                if (passwordAttempt == 0)
                {
                    const string text =
                        "To je ostuda, že hraješ hru a ani nevíš, jak se jmenuje :(, program skončil, musíš ho pustit znovu.";
                    for (var i = 0; i < text.Length; i++)
                    {
                        Console.Write(text[i]);
                        Thread.Sleep(40);
                    }

                    Console.WriteLine("\nStiskni \"Enter\" pro vypnutí programu.");
                    try
                    {
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ve třídě 'password' je chyba.");
                    }
                }
            }
        }
    }
}
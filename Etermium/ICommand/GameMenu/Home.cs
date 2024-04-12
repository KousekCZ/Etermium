using Etermium.Entits;
using Etermium.Entity;
using Etermium.Mechanic;

namespace Etermium.ICommand.GameMenu;

public class Home : ICommand
{
    public void Execute(Player player, Enemy enemy)
    {
        start_and_config.GameMenu.NewFrame();
        HomeGenerator.CestaDom();
        Thread.Sleep(3500);
        start_and_config.GameMenu.NewFrame();
        Console.Clear();
        HomeGenerator.SweetHome();
        const string text = "\nVítej ve svém domečku, zde se ti generují peníze, 1$ za 3s, co bys rád udělal?";
        foreach (var t in text)
        {
            Console.Write(t);
            Thread.Sleep(30);
        }

        var atHome = true;
        while (atHome)
        {
            Console.WriteLine(
                "\n- Vyzvednout peníze - (v)\n- Zjistit kolik už je vygenerováno peněz - (i)\n- odejít zpět do menu beze změny - (z)\n");
            var dotaz = Console.ReadLine()!.Trim().ToLower();
            switch (dotaz)
            {
                case "v":
                    player.Money += HomeGenerator.Dollars;
                    Console.WriteLine("Vyzvedl sis: " + HomeGenerator.Dollars + " $, aktuálně máš: " + player.Money);
                    HomeGenerator.Dollars = 0;
                    break;
                case "i":
                    Console.WriteLine("Vygenerováno: " + HomeGenerator.Dollars + " $");
                    Thread.Sleep(1000);
                    break;
                case "z":
                    start_and_config.GameMenu.NewFrame();
                    HomeGenerator.CestaZDom();
                    Thread.Sleep(3500);
                    start_and_config.GameMenu.NewFrame();
                    atHome = false;
                    break;
            }
        }
    }
}
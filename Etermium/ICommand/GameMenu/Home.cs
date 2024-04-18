using Etermium.Entits;
using Etermium.Mechanic;
using System;
using System.Threading;

namespace Etermium.ICommand.GameMenu;

/// <summary>
/// Class representing the command to return home.
/// </summary>
public class Home : ICommand
{
    /// <summary>
    /// Executes the command to return home.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    public void Execute(Player player, Enemy enemy)
    {
        Start_Config.GameMenu.NewFrame();
        HomeGenerator.CestaDom();
        Thread.Sleep(3500);
        Start_Config.GameMenu.NewFrame();
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
            var choose = Console.ReadLine()!.Trim().ToLower();
            switch (choose)
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
                    Start_Config.GameMenu.NewFrame();
                    HomeGenerator.CestaZDom();
                    Thread.Sleep(3500);
                    Start_Config.GameMenu.NewFrame();
                    atHome = false;
                    break;
            }
        }
    }
}
using System;
using System.Threading;

namespace Etermium.PrintOut;

/// <summary>
/// Abstract class for displaying information about the program.
/// </summary>
public abstract class AboutProgram
{
    private static string? _text;

    /// <summary>
    /// Displays the introductory story of the game.
    /// </summary>
    public static void BeginStory()
    {
        const int pause = 40;

        _text = "\nVítám tě ve hře Etermium.";
        foreach (var t in _text)
        {
            Console.Write(t);
            Thread.Sleep(pause);
        }

        Thread.Sleep(2000);

        _text =
            "\nTento typ hry je RPG. Název je převzatý od hry Eternium, která je také RPG, tak se tato hra jmenuje Etermium";
        foreach (var t in _text)
        {
            Console.Write(t);
            Thread.Sleep(pause);
        }

        Thread.Sleep(2000);

        _text =
            "\nTvým úkolem bude bojovat s nepřáteli, odpovídat správně na hádanky a splnit úkoly zadavatele. Vše si důkladně projdi. Cíl hry je porazit bosse 'Dragona', poté jsi vyhrál/a. :)";
        foreach (var t in _text)
        {
            Console.Write(t);
            Thread.Sleep(pause);
        }

        Thread.Sleep(2000);

        _text = "\nHru si můžeš kdykoli uložit a po startu hry zas načíst tam, kde jsi skončil/a.";
        foreach (var t in _text)
        {
            Console.Write(t);
            Thread.Sleep(pause);
        }

        Thread.Sleep(2000);

        _text = "\nHlavní vývojář hry: Jan Kus";
        foreach (var t in _text)
        {
            Console.Write(t);
            Thread.Sleep(pause);
        }

        Console.WriteLine("\n\nStiskni \"Enter\" pro pokračování");
        try
        {
            Console.ReadKey();
        }
        catch
            (Exception)
        {
            Console.WriteLine("Chyba ve třídě Story");
        }
    }

    /// <summary>
    /// Displays a message indicating that the introductory story won't be shown again.
    /// </summary>
    public static void DontShowYouStoryAgain()
    {
        _text =
            "Už sis ho četl, tak proč by sis ho četl/a znova? Vyber si jinou možnost.";
        foreach (var t in _text)
        {
            Console.Write(t);
            Thread.Sleep(40);
        }
    }
}
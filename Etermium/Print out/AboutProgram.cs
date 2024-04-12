namespace Etermium.Print_out;

public class AboutProgram
{
    private static string? _text;

    public static void BeginStory()
    {
        const int pause = 40;

        _text = "\nVítám tě ve hře Etermium.";
        for (var i = 0; i < _text.Length; i++)
        {
            Console.Write(_text[i]);
            Thread.Sleep(pause);
        }

        Thread.Sleep(2000);

        _text =
            "\nTento typ hry je RPG. Název je převzatý od hry Eternium, která je také RPG, tak se tato hra jmenuje Etermium";
        for (var i = 0; i < _text.Length; i++)
        {
            Console.Write(_text[i]);
            Thread.Sleep(pause);
        }

        Thread.Sleep(2000);

        _text =
            "\nTvým úkolem bude bojovat s nepřáteli, odpovídat správně na hádanky a splnit úkoly zadavatele. Vše si důkladně projdi. Cíl hry je porazit bosse 'Dragona', poté jsi vyhrál/a. :)";
        for (var i = 0; i < _text.Length; i++)
        {
            Console.Write(_text[i]);
            Thread.Sleep(pause);
        }

        Thread.Sleep(2000);

        _text = "\nHru si můžeš kdykoli uložit a po startu hry zas načíst tam, kde jsi skončil/a.";
        for (var i = 0; i < _text.Length; i++)
        {
            Console.Write(_text[i]);
            Thread.Sleep(pause);
        }

        Thread.Sleep(2000);

        _text = "\nHlavní vývojář hry: Jan Kus";
        for (var i = 0; i < _text.Length; i++)
        {
            Console.Write(_text[i]);
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

    public static void DontShowYouStoryAgain()
    {
        _text =
            "Už sis ho četl, tak proč by sis ho četl/a znova? Vyber si jinou možnost.";
        for (var i = 0; i < _text.Length; i++)
        {
            Console.Write(_text[i]);
            Thread.Sleep(40);
        }
    }
}
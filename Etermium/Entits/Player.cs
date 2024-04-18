using Etermium.ICommand.SaveManager;
using Etermium.Mechanic;
using System;
using System.Threading;

namespace Etermium.Entits;

/// <summary>
/// Represents the player entity in the game.
/// </summary>
public class Player
{
    private bool _newPlayer = true;
    private readonly Random _rd = new();
    private readonly SavePlayer _savePlayer = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Player"/> class.
    /// </summary>
    public Player()
    {
    }

    public int Hp { get; set; }
    public int Mana { get; set; }
    public int AttackPower { get; set; }
    public string PlayerName { get; set; }
    private string? _password;
    public int Money { get; set; }
    public int HpPotion { get; set; }
    public int PowerPotion { get; set; }
    public bool StartLoad { get; set; } = true;

    /// <summary>
    /// Creates a new player or loads an existing one.
    /// </summary>
    /// <param name="player">The player instance.</param>
    public void NewPlayer(Player player)
    {
        while (_newPlayer)
        {
            Console.WriteLine(
                "\n---------------------------------------------------------------------------------");
            Console.WriteLine("Chceš načíst uloženou hru? - (n), nebo si vytvořit postavu? - (v)");
            var save = Console.ReadLine()!.Trim();

            while (!(save.Equals("n", StringComparison.OrdinalIgnoreCase) ||
                     save.Equals("v", StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Znovu, chceš načíst uloženou hru?");
                save = Console.ReadLine()!.Trim();
            }

            if (save.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                var loadPlayer = new LoadPlayer();

                if (!loadPlayer.Login(player))
                {
                    _newPlayer = false;
                }
            }

            if (save.Equals("v", StringComparison.OrdinalIgnoreCase))
            {
                _newPlayer = false;
                Console.WriteLine("Dobře, tak ti vytvořím novou postavu, jsi kluk nebo holka?");
                var gender = Console.ReadLine()!.Trim();

                while (!(gender.Equals("kluk", StringComparison.OrdinalIgnoreCase) ||
                         gender.Equals("holka", StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Znovu, jsi holka nebo kluk?");
                    gender = Console.ReadLine()!.Trim();
                }

                do
                {
                    Console.Write("\nZadej své herní jméno v rozsahu 5 až 50 znaků: ");
                    PlayerName = Console.ReadLine()!;
                    PlayerName = PlayerName.Replace(" ", "");

                    string hesloZnovu;
                    do
                    {
                        Console.Write("\nZadej nové heslo, minimálně 8 znaků: ");
                        _password = Console.ReadLine()!;

                        Console.Write("\nZadej znovu nové heslo: ");
                        hesloZnovu = Console.ReadLine()!;

                        if (_password != hesloZnovu)
                        {
                            Console.WriteLine("\nHesla se neshodují");
                        }
                    } while (_password != hesloZnovu);
                } while (!CheckUserName.CheckSameName(PlayerName, _password));

                if (gender.Equals("kluk", StringComparison.OrdinalIgnoreCase))
                {
                    // vytvoření HP a Many muže
                    Hp = 25;
                    Mana = 10;
                    AttackPower = 7;
                    Money = _rd.Next(51);
                    HpPotion = 0;
                    PowerPotion = 0;
                }

                if (gender.Equals("holka", StringComparison.OrdinalIgnoreCase))
                {
                    // vytvoření HP a Many ženy
                    Hp = 20;
                    Mana = 16;
                    AttackPower = 5;
                    Money = _rd.Next(51);
                    HpPotion = 0;
                    PowerPotion = 0;
                }

                _savePlayer.Execute(player, null);
            }
        }
    }

    /// <summary>
    /// Prints the player's status.
    /// </summary>
    public void Print()
    {
        Console.Clear();
        Console.Write("\nMáš HP: (" + Hp + ") ");
        for (var i = 0; i < Hp; i++)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("█");
            Thread.Sleep(30);
        }

        Console.Write(" \nMáš Many: (" + Mana + ") ");
        for (var i = 0; i < Mana; i++)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("█");
            Thread.Sleep(30);
        }

        Thread.Sleep(300);
        Console.WriteLine("\nTvoje síla útoku: (" + AttackPower + ")");
        Thread.Sleep(500);
        Console.WriteLine("Máš: " + Money + " $");
        Thread.Sleep(500);
        Console.WriteLine("Počet léčících lektvarů: (" + HpPotion + ")");
        Thread.Sleep(500);
        Console.WriteLine("Počet lektvarů na sílu: (" + PowerPotion + ")");
        Thread.Sleep(500);
    }

    /// <summary>
    /// Prints the player's status during battle.
    /// </summary>
    public void BattlePrint()
    {
        Console.WriteLine("\n\nTvoje info: ");
        Console.Write("HP: (" + Hp + ") ");
        for (var i = 0; i < Hp; i++) Console.Write("█");

        Console.Write(" \nMáš Many: (" + Mana + ") ");
        for (var i = 0; i < Mana; i++) Console.Write("█");

        Console.WriteLine("\nTvoje síla útoku: " + AttackPower);
        Console.WriteLine("Lektvarů HP: " + HpPotion);
        Console.WriteLine("Lektvarů Síly: " + PowerPotion);
    }
}
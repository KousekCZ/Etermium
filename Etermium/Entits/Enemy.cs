using Etermium.Mechanic;
using System;
using System.Threading;
using Etermium.PrintOut;
using Etermium.Start_Config;

namespace Etermium.Entits;

/// <summary>
/// Represents the enemy entity in the game.
/// </summary>
public class Enemy
{
    private readonly Riddles _riddles = new();
    private readonly CsvMap _map = new();
    private readonly Battle _battle = new();
    private readonly Random _random = new();

    public string Name { get; set; } = null!;
    public int Hp { get; set; }
    public int AttackPower { get; set; }
    public bool BossEnd { get; set; }

    /// <summary>
    /// Generates a battle or a riddle encounter for the enemy.
    /// </summary>
    /// <param name="enemy">The enemy instance.</param>
    /// <param name="player">The player instance.</param>
    [Obsolete("Obsolete")]
    public void GenerateBattleOrRiddle(Enemy enemy, Player player)
    {
        GameMenu.NewFrame();
        var random = _random.Next(15);

        switch (random)
        {
            case 0:
                _map.PlayMiniGame(player);
                break;
            case 1:
                Pictures.BatPicture();
                SetEnemy("podzemní netopýr", 5, _random.Next(3));
                _battle.StartBattle(enemy, player);
                break;
            case 2:
                _riddles.Riddle1(player);
                break;
            case 3:
                Pictures.RatPicture();
                SetEnemy("podzemní krysa", 15, _random.Next(3, 9));
                _battle.StartBattle(enemy, player);
                break;
            case 4:
                _riddles.Riddle2(player);
                break;
            case 5:
                SetEnemy("obří hovnivál", 40, _random.Next(6, 12));
                _battle.StartBattle(enemy, player);
                break;
            case 6:
                _riddles.Riddle3(player);
                break;
            case 7:
                SetEnemy("hloupý troll", 70, _random.Next(9, 15));
                _battle.StartBattle(enemy, player);
                break;
            case 8:
                _riddles.Riddle4(player);
                break;
            case 9:
                SetEnemy("kentaur", 75, _random.Next(12, 18));
                _battle.StartBattle(enemy, player);
                break;
            case 10:
                _riddles.Riddle5(player);
                break;
            case 11:
                SetEnemy("vzteklý trpaslík", 13, _random.Next(20, 40));
                _battle.StartBattle(enemy, player);
                break;
            case 12:
                _riddles.Riddle6(player);
                break;
            case 13:
                Pictures.WolfPicture();
                SetEnemy("bílý vlk", 160, _random.Next(10, 25));
                _battle.StartBattle(enemy, player);
                break;
            case 14:
                _riddles.Riddle7(player);
                break;
        }
    }

    /// <summary>
    /// Sets the properties of the enemy.
    /// </summary>
    /// <param name="name">The name of the enemy.</param>
    /// <param name="hp">The health points of the enemy.</param>
    /// <param name="attackPower">The attack power of the enemy.</param>
    private void SetEnemy(string name, int hp, int attackPower)
    {
        Name = name;
        Hp = hp;
        AttackPower = attackPower;
    }

    /// <summary>
    /// Initiates a boss battle.
    /// </summary>
    /// <param name="enemy">The enemy instance.</param>
    /// <param name="player">The player instance.</param>
    [Obsolete("Obsolete")]
    public void Boss(Enemy enemy, Player player)
    {
        SetEnemy("Ohnivý drak", 690, _random.Next(10, 25));
        BossEnd = true;
        _battle.StartBattle(enemy, player);
    }
}
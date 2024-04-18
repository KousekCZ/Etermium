using Etermium.Entits;
using Etermium.ICommand.Battle;
using Etermium.ICommand.SaveManager;
using System;
using System.Collections.Generic;
using System.Threading;
using Etermium.PrintOut;
using Etermium.Start_Config;

namespace Etermium.Mechanic;

/// <summary>
/// Class responsible for managing battles between the player and enemies.
/// </summary>
public class Battle
{
    private readonly Random _rd = new();
    private readonly SavePlayer _savePlayer = new();
    public static int UpHp { get; set; } = 15;
    public static int UpSila { get; set; } = 25;
    public static int UpPowerCount { get; set; }
    public static bool IsFighting { get; set; } = true;

    /// <summary>
    /// Starts a battle between the player and an enemy.
    /// </summary>
    /// <param name="enemy">The enemy object.</param>
    /// <param name="player">The player object.</param>
    [Obsolete("Obsolete")]
    public void StartBattle(Enemy enemy, Player player)
    {
        var tmpAttackPower = player.AttackPower;
        while (IsFighting)
        {
            Console.Clear();
            Console.WriteLine("\nPozor nepřítel: " + enemy.Name);
            Console.Write("HP: (" + enemy.Hp + ") ");
            for (var i = 0; i < enemy.Hp; i++)
            {
                Console.Write("▒");
            }

            Thread.Sleep(1500);

            player.BattlePrint();
            if (UpPowerCount >= 1)
            {
                Console.WriteLine("Zbývající počet úderů se zvýšenou sílou: " + UpPowerCount);
            }
            else
            {
                player.AttackPower = tmpAttackPower;
            }

            Thread.Sleep(2500);

            Console.WriteLine("\nMožnosti:");
            Console.WriteLine(" zaútočit - (z)"
                              + "\n zkusit se vyhnout a udělit dvojnásobný dmg {50% šance, jinak se to obrátí proti hráči} - (v)"
                              + "\n použít lektvar HP, sebere 8 many, vyléčí " + UpHp +
                              " HP - (hp)\n použít lekvar Síla, sebere 11 many, zvedne sílu na jeden boj o " +
                              UpSila + " dmg - (s)"
                              + "\n utéct {50% šance útěk bez obdržení dmg} - (u) ");
            var choose = Console.ReadLine()!.ToLower().Trim();
            //var itWasBoss = false;

            var commands = new Dictionary<string, ICommand.ICommand>
            {
                { "z", new Attack() }, // normální útok
                { "v", new DoubleAttackStrength() }, // Odvážný útok
                { "hp", new HealHp() }, // Vyléčit v bitvě
                { "s", new UsePowerPotion() }, // Zvednout si sílu útoku pomocí lektvaru
                { "u", new RunAway() } // Utéct
            };

            ICommand.ICommand command;
            if (commands.TryGetValue(choose!, out command!)) command.Execute(player, enemy);

            // Kontroly, jestli nebojuje s bosem, nebo jestli neprohrál
            if (enemy is
                {
                    BossEnd: true, Hp: <= 0
                })
            {
                GameMenu.NewFrame();
                Console.WriteLine("Porazil jsi " + enemy.Name + " výborně. Vyhrál jsi hru!");
                //itWasBoss = true;
                Thread.Sleep(4500);
                IsFighting = false;
                _savePlayer.Execute(player, null);
                MusicPlayer.Play("Data/Audio/Legends.mp3", enemy);
                EndGame.WinGame();
            }

            if (enemy is { Hp: <= 0, BossEnd: false })
            {
                IsFighting = false;
                var money = _rd.Next(30, 101);
                Console.WriteLine("\nPorazil jsi " + enemy.Name + " výborně. Dostáváš odměnu v podobě " + money +
                                  " $ a vracím tě do menu.");
                player.Money += money;
                Thread.Sleep(6000);
                _savePlayer.Execute(player, null);
                GameMenu.NewFrame();
            }

            if (player.Hp <= 0) // && itWasBoss is false
            {
                Console.WriteLine("Zabil tě nepřítel jménem: " + enemy.Name);
                Thread.Sleep(1500);
                IsFighting = false;
                MusicPlayer.PlayOnce("Data/Audio/Legends.mp3", enemy);
                EndGame.LostGame();
            }
        }
    }
}
using System;
using System.Threading;
using Etermium.Start_Config;

namespace Etermium.AdminManager;

/// <summary>
/// Manages administrative functions for the Etermium game.
/// </summary>
public class AdminManager
{
    private readonly DatabaseConfig _config = new();
    private readonly ExportData _exportData = new();

    /// <summary>
    /// Initiates the administrative functionality for managing user data.
    /// </summary>
    public void ManagerAdmin()
    {
        Console.Clear();
        Console.WriteLine(
            "Přihlásil jsi se za správce hry Etermium a máš přístup ke všem dat uživatelů.\nMáš možnost zobrazit si všechny uživatele s jejich uloženými pozicemi, nebo je kompletně smazat z databáze.");

        var adminWorking = true;
        while (adminWorking)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine(
                "1) Zobrazit všechny užvatele s jmény a hesly.\n" +
                "2) Smazat uživatele se všemi jeho daty a herními pozicemi.\n" +
                "3) \"Odinstalace\" všech dat hry: Smazat kompletně databázi hry. Hra se po tomto kroku sama ukončí.\n" +
                "4) Exportovat seznam uživatelů registrovaných ve hře do csv.\n" +
                "0) Odhlásit se ze správce a odejít zpět do hry.");
            var choose = Console.ReadLine()!.Trim();
            switch (choose)
            {
                case "0":
                    adminWorking = false;
                    Console.Clear();
                    break;
                case "1":
                    ShowAllUsers.ShowAllUserss(_config.StableConnect());
                    break;
                case "2":
                    Console.Write("Zadej jméno hráče ke smazání: ");
                    var playerName = Console.ReadLine()!;
                    if (DeleteUsers.DeleteUser(_config.StableConnect(), playerName.ToLower()))
                    {
                        Console.WriteLine($"Uživatel {playerName} byl smazán z databáze.");
                    }
                    else
                    {
                        Console.WriteLine(
                            $"Při mazání uživatele '{playerName}' nastala chyba. Tento uživatel se v databázi nejspíš nenachází.");
                    }

                    break;
                case "3":
                    do
                    {
                        Console.WriteLine(
                            "Opravdu chcete smazat všechna data hry, všechny uživatele a jejich uložené pozice? ano/ne");
                        choose = Console.ReadLine()!;
                    } while (choose.Equals("ano", StringComparison.OrdinalIgnoreCase) &&
                             choose.Equals("ne", StringComparison.OrdinalIgnoreCase));

                    if (choose.Equals("ano"))
                    {
                        if (RemoveEtermiumDatabase.RemoveDatabase(_config.FirstOrLastConnect()))
                        {
                            Console.WriteLine(
                                "Databáze hry i se všemi daty byla úspěšně smazána. Hra se nyní vypne. Při novém spuštění se vše znovu vytvoří.");
                            Thread.Sleep(3000);
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine(
                                "Při mazání databáze nastala neznámá chyba: " + RemoveEtermiumDatabase.Message);
                        }
                    }

                    break;
                case "4":
                    if (_exportData.Export())
                    {
                        Console.WriteLine("Data byla úspěšně exportována do souboru export.csv");
                    }
                    else
                    {
                        Console.WriteLine("Data nebyla exportována, nastala neznámá chyba: " + ExportData.Message);
                    }

                    break;
                default:
                    Console.WriteLine("Pod touto volbou se žádná funkce neschovává...");
                    Thread.Sleep(1500);
                    break;
            }
        }
    }
}
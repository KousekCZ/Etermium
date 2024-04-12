using Etermium.start_and_config;
using MySqlConnector;

namespace Etermium.Mechanic;

public abstract class CheckUserName
{
    private static readonly DatabaseConfig Config = new();

    public static bool CheckSameName(string playerName, string password)
    {
        if (playerName.Length is < 5 or > 50)
        {
            Console.WriteLine("Zadané jméno je mimo rozsah.");
            Thread.Sleep(2000);
            return false;
        }

        if (password.Length < 8)
        {
            Console.WriteLine("Zadané heslo je mimo rozsah.");
            Thread.Sleep(2000);
            return false;
        }

        try
        {
            const string query = "select PlayerName from Users;";
            using (MySqlCommand command = new MySqlCommand(query, Config.StableConnect()))
            {
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();
                while (reader.Read())
                    if (reader[0].ToString()?.ToLower() == playerName.ToLower())
                    {
                        Console.WriteLine("Toto jméno je již používané");
                        Thread.Sleep(2000);
                        return false;
                    }

                var hashPassword = Md5Hash.CalculateMd5Hash(password);
                CreatePlayerTable(playerName, hashPassword);
            }

            Console.WriteLine("Postava úspěšně vytvořena!");
            Thread.Sleep(2000);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Chyba při ověření uživatele z databáze: {e.Message}");
            return false;
        }
    }

    private static void CreatePlayerTable(string playerName, string hashPassword)
    {
        try
        {
            var query =
                $"insert into Users(PlayerName, Password) values(@user, @password);\ncreate table if not exists {playerName}(id int auto_increment primary key, Hp int, Mana int, AttackPower int, Money int, HpPotion int, PowerPotion int, Created datetime default NOW(), PlayerName nvarchar(55));";

            using (MySqlCommand command = new MySqlCommand(query, Config.StableConnect()))
            {
                command.Parameters.AddWithValue("@user", playerName);
                command.Parameters.AddWithValue("@password", hashPassword);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Není spuštěna databáze, přečti si README ve složce se hrou, error: {e.Message}");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
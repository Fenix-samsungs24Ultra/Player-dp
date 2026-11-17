

using System;
using System.Collections.Generic;
class Player
{
    public string NickName { get; }
    public int Score { get; set; }
    public int Level { get; set; }
    public Player(string nickName, int score, int level)
    {
        NickName = nickName;
        Score = score;
        Level = level;
    }
    public string GetInfo()
    {
        return $"Нік: {NickName}, Рахунок: {Score}, Рівень: {Level}";
    }
}class PlayerDateBase
{
    private Dictionary<string, Player> players = new Dictionary<string, Player>();
    public void AddPlayer(Player player)
    {
        if (!players.ContainsKey(player.NickName))
        {
            players[player.NickName] = player;
        }
    }
    public Player FindPlayer(string nickName)
    {
        players.TryGetValue(nickName, out Player player);
        return player;
    }
    public bool RemovePlayer(string nickName)
    {
        return players.Remove(nickName);
    }
    public void GetAllPlayers()
    {
        if (players.Count == 0)
        {
            Console.WriteLine("Список гравців порожній.");
            return;
        }
        foreach (var player in players.Values)
        {
            Console.WriteLine(player.GetInfo());
        }
    }
}
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        PlayerDateBase playerDB = new PlayerDateBase();
        bool exit = false; 
        while (!exit) { 
           Console.WriteLine("Для того щоб добавити гравця, натисніть 1,щоб знайти гравця, натисніть 2 ,щоб видалити гравця, натисніть 3, щоб показати всіх гравців, натисніть 4, щоб вийти, натисніть 0");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Write("Введіть нік гравця: ");
                    string nickName = Console.ReadLine();

                    Console.Write("Введіть рахунок гравця: ");
                    int score = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Введіть рівень гравця: ");
                    int level = Convert.ToInt32(Console.ReadLine());

                    Player newPlayer = new Player(nickName, score, level);
                    playerDB.AddPlayer(newPlayer);
                    break;
                case 2:
                    Console.Write("Введіть нік гравця для пошуку: ");
                    string Name = Console.ReadLine();
                    Player found = playerDB.FindPlayer(Name);
                    if (found != null)
                    {
                        Console.WriteLine(found.GetInfo());
                    }
                    else
                    {
                        Console.WriteLine("Гравець не знайдений.");
                    }
                    break;
                case 3:
                    Console.Write("Введіть нік гравця для пошуку: ");
                    string nick = Console.ReadLine();
                    bool removed = playerDB.RemovePlayer(nick);
                    if (removed)
                    {
                        Console.WriteLine("Гравець успішно видалений.");
                    }
                    else
                    {
                        Console.WriteLine("Гравець не знайдений.");
                    }
                    break;
                case 4:
                   Console.WriteLine("Список всіх гравців:");
                    playerDB.GetAllPlayers();
                    break;
                case 0:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
}



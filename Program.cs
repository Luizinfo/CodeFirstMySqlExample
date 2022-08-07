// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Code First Start");
VerifyDB();
InsertData();
ReadData();
Console.ReadKey();


void VerifyDB()
{
    using (var ct = new MainContext())
    {
        ct.Database.EnsureCreated();
    }
}

void InsertData()
{
    using (var ct = new MainContext())
    {
        var team = new Team(){Name = "Flamengo", Manager = "Zico"};
        ct.Team.Add(team);

        ct.Player.Add(new Player(){
            Name = "Pedro",
            Age = 20,
            Team = team
        });

        ct.Player.Add(new Player(){
            Name = "GabiGol",
            Age = 22,
            Team = team
        });

        ct.Player.Add(new Player(){
            Name = "Felipe Luiz",
            Age = 27,
            Team = team
        });

        ct.SaveChanges();
    }
}

void ReadData()
{
    using(var ct = new MainContext()){
        var players = ct.Player.Include(x => x.Team);

        foreach (var player in players)
        {
            Console.WriteLine(player.Print());
        }
    }
}
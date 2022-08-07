public class Player
{
    public int PlayerId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Team Team {get;set;}

    public string Print(){
        return $"Id: {PlayerId}, Name: {Name}, Age: {Age}, Team: {Team.Name}";
    }
}
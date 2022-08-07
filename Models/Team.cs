public class Team
{
    public Team()
    {
        Players = new List<Player>();
    }
    public int TeamId { get; set; }
    public string Name { get; set; }
    public string Manager { get; set; }
    public ICollection<Player> Players {get; set;}
}
namespace Core.Models.Submarines.Schema;

public class Submarine
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Rank { get; set; }

    public List<SubmarinePart> Parts { get; set; } = new();

    public void Copy(Submarine submarine)
    {
        Name = submarine.Name;
        Rank = submarine.Rank;

        Parts.ForEach(x => x.Copy(submarine.Parts.First(y => y.PartId == x.PartId)));
    }
}
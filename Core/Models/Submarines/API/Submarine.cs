using Core.Models.Submarines.Enums;
using db = Core.Models.Submarines.Schema;

namespace Core.Models.Submarines.API;

public class Submarine
{
    public Submarine() { }

    public Submarine(db.Submarine db)
    {
        Id = db.Id;
        Name = db.Name;
        Rank = db.Rank;

        PressureHull = db.Parts.Find(p => p.Part?.Type == PartType.PressureHull) switch
        {
            { } part => new SubmarinePart(part, PartType.PressureHull),
            _ => new SubmarinePart(PartType.PressureHull)
        };
        Stern = db.Parts.Find(p => p.Part?.Type == PartType.Stern) switch
        {
            { } part => new SubmarinePart(part, PartType.Stern),
            _ => new SubmarinePart(PartType.Stern)
        };
        Bow = db.Parts.Find(p => p.Part?.Type == PartType.Bow) switch
        {
            { } part => new SubmarinePart(part, PartType.Bow),
            _ => new SubmarinePart(PartType.Bow)
        };
        Bridge = db.Parts.Find(p => p.Part?.Type == PartType.Bridge) switch
        {
            { } part => new SubmarinePart(part, PartType.Bridge),
            _ => new SubmarinePart(PartType.Bridge)
        };
    }
    
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Rank { get; set; }

    public SubmarinePart PressureHull { get; set; } = new(PartType.PressureHull);
    public SubmarinePart Stern { get; set; } = new(PartType.Stern);
    public SubmarinePart Bow { get; set; } = new(PartType.Bow);
    public SubmarinePart Bridge { get; set; } = new(PartType.Bridge);

    public db.Submarine MapToDb() => new()
    {
        Id = Id,
        Name = Name,
        Rank = Rank,
        
        Parts = new List<db.SubmarinePart>
        {
            PressureHull.MapToDb(Id),
            Stern.MapToDb(Id),
            Bow.MapToDb(Id),
            Bridge.MapToDb(Id)
        }
    };

    public class SubmarinePart
    {
        public SubmarinePart() { }

        public SubmarinePart(PartType type) => Type = type;

        public SubmarinePart(db.SubmarinePart db, PartType type)
        {
            PartId = db.PartId;
            Type = type;
            Dye = db.Dye;
            Condition = db.Condition;
        }
        
        public int PartId { get; set; }
        public PartType Type { get; set; }
        public Dye Dye { get; set; }
        public int Condition { get; set; }

        public db.SubmarinePart MapToDb(int submarineId) => new()
        {
            SubmarineId = submarineId,
            PartId = PartId,
            Dye = Dye,
            Condition = Condition
        };
    }
}
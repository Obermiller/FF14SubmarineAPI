using Core.Models.Submarines.Enums;

namespace Core.Models.Submarines.Schema;

public class Part
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public PartType Type { get; set; }
    public string Description { get; set; } = string.Empty;
    
    //Outfitting Info
    public int Rank { get; set; }
    public int Components { get; set; }
    
    //FunctionalityInfo
    public int Surveillance { get; set; }
    public int Retrieval { get; set; }
    public int Speed { get; set; }
    public int Range { get; set; }
    public int Favor { get; set; }

    //Crafting And Repairs Info
    //public int Condition { get; set; }
    public int Materials { get; set; }
    public bool Desynthesizable { get; set; }

    //public Dyes Dye { get; set; }
    public int ShopSellingPrice { get; set; }
    public int SellingPrice { get; set; }
    public bool MarketboardProhibited { get; set; }

    public List<SubmarinePart>? SubmarineParts { get; set; }

    public void Copy(Part part)
    {
        Name = part.Name;
        Type = part.Type;
        Description = part.Description;

        Rank = part.Rank;
        Components = part.Components;
        Surveillance = part.Surveillance;
        Retrieval = part.Retrieval;
        Speed = part.Speed;
        Range = part.Range;
        Favor = part.Favor;

        Materials = part.Materials;
        Desynthesizable = part.Desynthesizable;

        ShopSellingPrice = part.ShopSellingPrice;
        SellingPrice = part.SellingPrice;
        MarketboardProhibited = part.MarketboardProhibited;
    }
}
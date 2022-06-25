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
}
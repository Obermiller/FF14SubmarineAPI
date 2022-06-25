using Core.Models.Submarines.Enums;
using db = Core.Models.Submarines.Schema;

namespace SubmarineAPI.Submarines.Models
{
    public class Part
    {
        public Part() { }

        public Part(db.Part db)
        {
            Id = db.Id;
            Name = db.Name;
            Type = db.Type;
            Description = db.Description;
            Outfitting = new OutfittingInformation(db);
            Functionality = new FunctionalityInformation(db);
            CraftingAndRepairs = new CraftingAndRepairsInformation(db);
            ShopSellingPrice = db.ShopSellingPrice;
            SellingPrice = db.SellingPrice;
            MarketboardProhibited = db.MarketboardProhibited;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public PartType Type { get; set; }
        public string Description { get; set; } = string.Empty;

        public OutfittingInformation Outfitting { get; set; } = new();
        public FunctionalityInformation Functionality { get; set; } = new();
        public CraftingAndRepairsInformation CraftingAndRepairs { get; set; } = new();

        public int ShopSellingPrice { get; set; }
        public int SellingPrice { get; set; }
        public bool MarketboardProhibited { get; set; }

        public class CraftingAndRepairsInformation
        {
            public CraftingAndRepairsInformation() { }

            public CraftingAndRepairsInformation(db.Part db)
            {
                Materials = db.Materials;
                Desynthesizable = db.Desynthesizable;
            }
            
            public int Materials { get; set; }
            public bool Desynthesizable { get; set; }
        }

        public class FunctionalityInformation
        {
            public FunctionalityInformation() { }

            public FunctionalityInformation(db.Part db)
            {
                Surveillance = db.Surveillance;
                Retrieval = db.Retrieval;
                Speed = db.Speed;
                Range = db.Range;
                Favor = db.Favor;
            }
            
            public int Surveillance { get; set; }
            public int Retrieval { get; set; }
            public int Speed { get; set; }
            public int Range { get; set; }
            public int Favor { get; set; }
        }

        public class OutfittingInformation
        {
            public OutfittingInformation() { }

            public OutfittingInformation(db.Part db)
            {
                Rank = db.Rank;
                Components = db.Components;
            }
            
            public int Rank { get; set; }
            public int Components { get; set; }
        }

        public db.Part MapToDb() => new()
        {
            Id = Id,
            Name = Name,
            Type = Type,
            Description = Description,

            Rank = Outfitting.Rank,
            Components = Outfitting.Components,

            Surveillance = Functionality.Surveillance,
            Retrieval = Functionality.Retrieval,
            Speed = Functionality.Speed,
            Range = Functionality.Range,
            Favor = Functionality.Favor,

            Materials = CraftingAndRepairs.Materials,
            Desynthesizable = CraftingAndRepairs.Desynthesizable,

            ShopSellingPrice = ShopSellingPrice,
            SellingPrice = SellingPrice,
            MarketboardProhibited = MarketboardProhibited
        };
    }
}
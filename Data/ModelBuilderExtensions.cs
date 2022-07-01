using Core.Models.Submarines.Enums;
using Core.Models.Submarines.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Part>()
            .HasData(
                new Part
                {
                    Id = 1,
                    Name = "Shark-class Pressure Hull",
                    Type = PartType.PressureHull,
                    Description = "Comprising the center of a shark-class submersible, this ovoid hull is multi-walled to stabilize and maintain pressure within so that the vessel's crew does not succumb to the crushing weight of the waters it navigates. Several sturdy rudder fins serve to increase maneuverability.",

                    Rank = 1,
                    Components = 5,
                    Surveillance = -10,
                    Retrieval = 30,
                    Speed = 20,
                    Range = 40,
                    Favor = 20,

                    Materials = 1,
                    Desynthesizable = false,

                    ShopSellingPrice = 0,
                    SellingPrice = 16,
                    MarketboardProhibited = true
                },
                new Part
                {
                    Id = 2,
                    Name = "Shark-class Stern",
                    Type = PartType.Stern,
                    Description = "Comprising the rear end of a shark-class submersible, this stern contains the unique independent engine which propels the craft.",
                    
                    Rank = 1,
                    Components = 5,
                    Surveillance = -30,
                    Retrieval = 20,
                    Speed = 60,
                    Range = 30,
                    Favor = 15,

                    Materials = 1,
                    Desynthesizable = false,

                    ShopSellingPrice = 0,
                    SellingPrice = 16,
                    MarketboardProhibited = true
                },
                new Part
                {
                    Id = 3,
                    Name = "Shark-class Bow",
                    Type = PartType.Bow,
                    Description = "Comprising the front end of a shark-class submersible, this bow has been reinforced to double as a battering ram for subduing unruly sea creatures.",
                    
                    Rank = 1,
                    Components = 5,
                    Surveillance = 50,
                    Retrieval = 40,
                    Speed = 10,
                    Range = -20,
                    Favor = 15,

                    Materials = 1,
                    Desynthesizable = false,

                    ShopSellingPrice = 0,
                    SellingPrice = 16,
                    MarketboardProhibited = true
                },
                new Part
                {
                    Id = 4,
                    Name = "Shark-class Bridge",
                    Type = PartType.Bridge,
                    Description = "Comprising the top of a shark-class submersible, the bridge houses all of the equipment necessary for the vessel's crew to navigate the unplumbed depths of the Ruby Sea and beyond.",
                    
                    Rank = 1,
                    Components = 5,
                    Surveillance = 20,
                    Retrieval = 20,
                    Speed = 20,
                    Range = 20,
                    Favor = 20,

                    Materials = 1,
                    Desynthesizable = false,

                    ShopSellingPrice = 0,
                    SellingPrice = 16,
                    MarketboardProhibited = true
                });

        modelBuilder.Entity<Submarine>()
            .HasData(new Submarine 
            {
                Id = 1,
                Name = "Base Sub",
                Rank = 1
            });

        modelBuilder.Entity<SubmarinePart>()
            .HasData(
                new SubmarinePart
                {
                    SubmarineId = 1,
                    PartId = 1,
                    Condition = 100,
                    Dye = Dye.SootBlackDye
                },
                new SubmarinePart
                {
                    SubmarineId = 1,
                    PartId = 2,
                    Condition = 100,
                    Dye = Dye.SootBlackDye
                },
                new SubmarinePart
                {
                    SubmarineId = 1,
                    PartId = 3,
                    Condition = 100,
                    Dye = Dye.SootBlackDye
                },
                new SubmarinePart
                {
                    SubmarineId = 1,
                    PartId = 4,
                    Condition = 100,
                    Dye = Dye.SootBlackDye
                });
    }
}
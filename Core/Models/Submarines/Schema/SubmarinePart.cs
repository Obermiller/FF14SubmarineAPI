using System.ComponentModel.DataAnnotations.Schema;
using Core.Models.Submarines.Enums;

namespace Core.Models.Submarines.Schema;

[Table("Submarine_Part")]
public class SubmarinePart
{
    public int SubmarineId { get; set; }
    public int PartId { get; set; }
    public Dye Dye { get; set; }
    public int Condition { get; set; }

    public Submarine? Submarine { get; set; }
    public Part? Part { get; set; }

    public void Copy(SubmarinePart submarinePart)
    {
        SubmarineId = submarinePart.SubmarineId;
        PartId = submarinePart.PartId;
        Dye = submarinePart.Dye;
        Condition = submarinePart.Condition;
    }
}
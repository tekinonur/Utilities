using System.ComponentModel;

namespace Utilities.Enums;

public enum MomType
{
    [Description("Anneyim")]
    Mother = 0,
    [Description("Hamileyim")]
    Pregnant = 1,
    [Description("Anneyim ve bebek bekliyorum")]
    MotherAndPregnant = 2
}
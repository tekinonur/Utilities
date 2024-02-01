using System.ComponentModel;

namespace Utilities.Enums;

public enum BirthStatus
{
    [Description("Doğmamış")]
    Unborn = 0,
    [Description("Doğmuş")]
    Born = 1
}

using System.ComponentModel;

namespace Utilities.Enums;

public enum GenderType
{
    [Description("Kız")]
    Girl = 0,
    [Description("Erkek")]
    Boy = 1,
    [Description("Belirsiz")]
    NotSet = 2
}
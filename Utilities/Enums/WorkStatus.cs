using System.ComponentModel;

namespace Utilities.Enums;

public enum WorkStatus
{
    [Description("Çalışıyor")]
    Employed = 0,
    [Description("Çalışmıyor")]
    UnEmployed = 1,
    [Description("Serbest Meslek")]
    SelfEmployed = 2,
    [Description("Ev Hanımı")]
    HomeMaker = 3,
    [Description("Emekli")]
    Retired = 4,
    [Description("Öğrenci")]
    Student = 5,
    [Description("Engelli")]
    Disabled = 6
}

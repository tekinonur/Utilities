using System.ComponentModel;

namespace Utilities.Enums;

public enum EducationLevel
{
    [Description("Eğitim Yok")]
    None = 0,
    [Description("İlkokul")]
    PrimarySchool = 1,
    [Description("Ortaokul")]
    MiddleSchool = 2,
    [Description("Lise")]
    HighSchool = 3,
    [Description("Üniversite")]
    College = 4,
    [Description("Lisans Üstü")]
    PostGraduate = 5,
    [Description("Doktora")]
    Doctorate = 6
}
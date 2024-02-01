using System.ComponentModel;

namespace Utilities.Enums;

public enum SpokenLanguage
{
    [Description("Türkçe")]
    Turkish = 0,
    [Description("İngilizce")]
    English = 1,
    [Description("İspanyolcaF")]
    Spanish = 2,
    [Description("Fransızca")]
    French = 3,
    [Description("Almanca")]
    German = 4,
    [Description("Çince")]
    Chinese = 5,
    [Description("Japonca")]
    Japanese = 6,
    [Description("Arapça")]
    Arabic = 7,
    [Description("Rusça")]
    Russian = 8,
    [Description("İtalyanca")]
    Italian = 9,
    [Description("Portekizce")]
    Portuguese = 10,
    [Description("Diğer Diller")]
    Other = 11
}
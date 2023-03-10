using System.Runtime.Serialization;
using iText.Kernel.Colors;

namespace SimpleWordPdfGenerator;

[Serializable]
public struct RGBColor{
    public byte Red {get; set;}    
    public byte Green {get; set;}

    public byte Blue {get; set;}

    public static implicit operator DeviceRgb(RGBColor color) => new DeviceRgb(color.Red, color.Green, color.Blue);
    public RGBColor(){Red = 0; Green = 0; Blue = 0;}
}

[Serializable]
public class ColorTheme{



    private static Color GetColor((int, int, int) tuple){
        return new DeviceRgb(tuple.Item1, tuple.Item2, tuple.Item3);
    }

    public RGBColor BackgroundAccent{
        get;  init;
    } 


    public RGBColor Accent{
        get;  init;

    }

    public RGBColor Netural{
        get;  init;

    }

    public RGBColor MainText{
        get;  init;

    }

    public RGBColor SubText{
        get;  init;

    }

    public RGBColor BackgroundMain{
        get;  init;

    }

} 
using iText.Kernel.Colors;

namespace SimpleWord.ColorThemes;

[Serializable]
public struct RGBColor{
    public byte Red {get; set;}    
    public byte Green {get; set;}

    public byte Blue {get; set;}

    public static implicit operator DeviceRgb(RGBColor color) => new DeviceRgb(color.Red, color.Green, color.Blue);
    public RGBColor(){Red = 0; Green = 0; Blue = 0;}
}
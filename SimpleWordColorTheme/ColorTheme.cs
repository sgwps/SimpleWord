using iText.Kernel.Colors;

namespace SimpleWord.ColorThemes;


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
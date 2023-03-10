using iText.Kernel.Colors;

namespace SimpleWordPdfGenerator;

static internal class Colors{
    private static Color GetColor(int red, int green, int blue){
        return new DeviceRgb(red, green, blue);
    }

    public static Color BackgroundAccent{
        get{
            return GetColor(245,245,220);
        }
    } 


    public static Color Accent{
        get{
            return GetColor(154, 41, 0);
        }
    }

    public static Color Netural{
        get{
            return GetColor(255, 204, 153);
        }
    }


    public static Color MainText{
        get{
            return GetColor(10, 10, 10);
        }
    }


    public static Color SubText{
        get{
            return GetColor(67, 67, 67);
        }
    }


    public static Color BackgroundMain{
        get{
            return GetColor(255, 255, 255);
        }
    }

} 
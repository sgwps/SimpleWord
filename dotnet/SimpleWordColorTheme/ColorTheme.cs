using System.Xml;
using iText.Kernel.Colors;

namespace SimpleWord.ColorThemes;


[Serializable]
public class ColorTheme{

    private void CreateLogoFile(){
        XmlDocument document = new XmlDocument();
        document.Load(Environment.GetEnvironmentVariable("METADATA_PATH")[1..^1] + "/logo.svg");
        document.GetElementsByTagName("path").Item(0).Attributes["fill"].Value = $"rgb({BackgroundAccent.Red}, {BackgroundAccent.Green}, {BackgroundAccent.Blue})";
        document.Save(new FileStream(Environment.GetEnvironmentVariable("METADATA_PATH")[1..^1] + "/" + LogoFile, FileMode.OpenOrCreate));
    }

    string _logoFile = "logo.svg";
    public string LogoFile{
        get{
            return _logoFile;
        } set{
            _logoFile = value;
            if (!File.Exists(Environment.GetEnvironmentVariable("METADATA_PATH")[1..^1] + "/" + _logoFile)) {
                CreateLogoFile();
            }
        }
    }

    public void EnsureLogoCreated(){
        LogoFile = _logoFile;
    }

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
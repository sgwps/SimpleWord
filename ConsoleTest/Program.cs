using SimpleWordModels;
using System.Text.Json;
using System.Text.Json.Serialization;


string data = String.Join(' ', File.ReadAllLines("/home/sgwps/Desktop/DictWebApp/TestData/JSONnew1.json"));
Console.WriteLine(data);

Collection json = JsonSerializer.Deserialize<Collection>(data);
Console.WriteLine(json.Cards[0].Word);
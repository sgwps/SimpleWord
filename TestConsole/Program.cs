using System;
using SimpleWordModels;
using System.Text.Json;
using System.Text.Json.Serialization;
class Program{
    static void Main(){
        Collection temp = JsonSerializer.Deserialize<Collection>(File.ReadAllText("new1.json", System.Text.Encoding.UTF8));
        // Console.WriteLine(temp.Name);
        //string json = temp.GetCollectionsJson();
        /*var options = new JsonSerializerOptions { 
            IncludeFields = false,
            WriteIndented = true, 
        };
        string json = JsonSerializer.Serialize<Collection>(temp, options);*/
        System.Console.WriteLine(temp.UpdateCollectionJSON);
    }
}

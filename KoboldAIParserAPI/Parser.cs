using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public static class Parser
{
    public static KoboldAIData ReadKoboldAIData(string path)
    {
        return JsonConvert.DeserializeObject<KoboldAIData>(File.ReadAllText(path));
    }

    public static void WriteKoboldAIData(KoboldAIData data, string path)
    {
        File.WriteAllText(path, JsonConvert.SerializeObject(data));
    }

    public static KoboldAIWorldInfo ReadKoboldAIWorldInfo(string path)
    {
        return JsonConvert.DeserializeObject<KoboldAIWorldInfo>(File.ReadAllText(path));
    }

    public static void WriteKoboldAIWorldInfo(KoboldAIWorldInfo info, string path)
    {
        File.WriteAllText(path, JsonConvert.SerializeObject(info));
    }
      

    public static KoboldAIData ReadHoloData(string path)
    {
        string memory = "";
        string authorsnote = "";
        List<string> actions = new List<string>();
        List<KoboldAIWorldInfo> worldinfo = new List<KoboldAIWorldInfo>();

        JObject holo = JObject.Parse(File.ReadAllText(path));
        JToken promptToken = holo.SelectToken("content");
        JToken memoryToken = holo.SelectToken("memory");
        JToken authorsToken = holo.SelectToken("authorsNote");
        JToken worldInfoToken = holo.SelectToken("worldInfo");

        foreach (JToken token in promptToken.Children())
        {
            JToken p = token.SelectToken("children[0]");
            string paragraph = (string)p.SelectToken("text");
            paragraph = paragraph.Replace("\\", "");
            paragraph = paragraph.Replace("\"", "");

            actions.Add(paragraph);
            //prompt += paragraph;
        }
        
        authorsnote = (string)authorsToken;
        memory = (string)memoryToken;


        foreach (JToken token in worldInfoToken.Children())
        {

            List<string> keyList = new List<string>();
            JToken keys = token.SelectToken("keys");
            JToken value = token.SelectToken("value");

            foreach (JToken key in keys.Children())
            {
                keyList.Add((string)key);
            }

           worldinfo.Add(new KoboldAIWorldInfo(String.Join(", ",keyList), "", (string)value, "", null, false, false));
        }


        return new KoboldAIData(true, actions[0], memory, authorsnote, "[Genre: <|>]", actions.Skip(1).ToList(), worldinfo) ;
    
    }

   

 
}

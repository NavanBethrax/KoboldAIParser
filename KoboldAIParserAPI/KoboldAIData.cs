using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class KoboldAIData
{
    private bool _gamestarted;
    private string _prompt = "";
    private string _memory = "";
    private string _authorsnote = "";
    private string _anotetemplate = "";
    private List<string> _actions = new List<string>();
    private List<KoboldAIWorldInfo> _worldinfo = new List<KoboldAIWorldInfo>();

    public bool gamestarted { get => _gamestarted; set => _gamestarted = value; }
    public string prompt { get => _prompt; set => _prompt = value; }
    public string memory { get => _memory; set => _memory = value; }
    public string authorsnote { get => _authorsnote; set => _authorsnote = value; }
    public string anotetemplate { get => _anotetemplate; set => _anotetemplate = value; }
    public List<string> actions { get => _actions; set => _actions = value; }
    public List<KoboldAIWorldInfo> worldinfo { get => _worldinfo; set => _worldinfo = value; }
    public Dictionary<String,String> wifolders_d { get => new Dictionary<string, string>(); }
    public List<string> wifolders_l { get => new List<string>(); }  


    public KoboldAIData()
    {
        _gamestarted = false;
        _prompt = "";
        _memory = "";
        _authorsnote = "";
        _anotetemplate = "";
        _actions = new List<string>();
        _worldinfo = new List<KoboldAIWorldInfo>();
    }

    [JsonConstructor]
    public KoboldAIData(bool gamestarted, string prompt, string memory, string authorsnote, string anotetemplate, List<string> actions, List<KoboldAIWorldInfo> worldinfo)
    {
        _gamestarted = gamestarted;
        _prompt = prompt;
        _memory = memory;
        _authorsnote = authorsnote;
        _anotetemplate = anotetemplate;
        _actions = actions;
        _worldinfo = worldinfo;
    }


    public void Sanitize()
    {
        _actions.RemoveAll(action => action == "");
    }
}

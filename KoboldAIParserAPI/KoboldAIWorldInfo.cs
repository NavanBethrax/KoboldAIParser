using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Drawing.Design;

public class KoboldAIWorldInfo
{
    private string _key = "";
    private string _keysecondary = "";
    private string _content = "";
    private string _comment = "";
    private string _folder = "";
    private bool _selective = false;
    private bool _constant = false;

    [CategoryAttribute("Data")]
    public string key{ get => _key.ToLower(); set => _key = value.ToLower(); }
    [CategoryAttribute("Data")]
    public string keysecondary { get => _keysecondary.ToLower(); set => _keysecondary = value.ToLower(); }
    [CategoryAttribute("Data")]
    public string content { get => _content.Replace("\n"," "); set => _content = value.Replace("\n", " "); }
    [CategoryAttribute("Extras")]
    public string comment { get => _comment; set => _comment = value; }
    [CategoryAttribute("Options")]
    public string folder { get => _folder; set => _folder = value; }
    [CategoryAttribute("Options")]
    public bool selective { get => _selective; set => _selective = value; }
    [CategoryAttribute("Options")]
    public bool constant { get => _constant; set => _constant = value; }

    [JsonConstructor]
    public KoboldAIWorldInfo(string key, string keysecondary, string content, string comment, string folder, bool selective, bool constant)
    {
        _key = key;
        _keysecondary = keysecondary;
        _content = content;
        _comment = comment;
        _folder = folder;
        _selective = selective;
        _constant = constant;
    }

}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoboldAICreator
{
    public enum ScanType
    {
        Names,
        Variables
    }


    public partial class FormScanner : Form
    {

        private FormCreator _parent;
        private ScanType _type;

        public FormScanner()
        {
            InitializeComponent();
        }

        public FormScanner(FormCreator parent,ScanType type)
        {
            InitializeComponent();
            _parent = parent;   
            _type = type;   
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            switch (_type)
            {
                case ScanType.Names:
                    foreach (string name in _parent.GetNames())
                    {
                        listBox1.Items.Add(name);
                    }
                    break;
                case ScanType.Variables:
                    foreach (string variable in _parent.GetVariables())
                    {
                        listBox1.Items.Add(variable);
                    }
                    break;
            }
        }
    }
}

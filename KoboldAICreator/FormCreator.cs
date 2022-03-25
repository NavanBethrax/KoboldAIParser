using KoboldAPIConverter;
using System.Diagnostics;

namespace KoboldAICreator
{
    public partial class FormCreator : Form
    {

        public string path = "";
        public KoboldAIData project;

        public FormCreator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            path = "";
            project = new KoboldAIData();
            refreshUI();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            path = "";
            project = new KoboldAIData();
            refreshUI();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "JSON File | *.json";
            open.DefaultExt = "json";
            open.InitialDirectory = Application.StartupPath + "Prompts";

            if (open.ShowDialog() == DialogResult.OK)
            {
                path = open.FileName;
                project = Parser.ReadKoboldAIData(open.FileName);
                refreshUI();
            }


        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commitChanges();

            project.Sanitize();

            if (path != "")
            {
                Parser.WriteKoboldAIData(project, path);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commitChanges();

            project.Sanitize();

            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "JSON File | *.json";
            save.DefaultExt = "json";
            save.InitialDirectory = Application.StartupPath + "Prompts";

            if (save.ShowDialog() == DialogResult.OK)
            {
                Parser.WriteKoboldAIData(project, save.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                propertyGrid1.SelectedObject = project.worldinfo[listBox1.SelectedIndex];
            }

        }

        private void commitChanges()
        {
            project.actions = richTextBox1.Text.Split("\n").ToList();
            project.memory = richTextBox2.Text;
            project.authorsnote = richTextBox3.Text;
            project.gamestarted = checkBox1.Checked;
        }

        private void refreshUI()
        {
            commitChanges();

            richTextBox1.Text = String.Join("\n", project.actions);
            richTextBox2.Text = project.memory;
            richTextBox3.Text = project.authorsnote;
            checkBox1.Checked = project.gamestarted;

            propertyGrid1.SelectedObject = null;
            listBox1.Items.Clear();

            if (project != null)
            {
                foreach (KoboldAIWorldInfo info in project.worldinfo)
                {
                    listBox1.Items.Add(info.key);
                }
            }

        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            refreshUI();
        }

        private void koboldAIConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConverter form = new FormConverter();

            form.ShowDialog();
        }


        public void Replace(string oldText, string newText)
        {
            richTextBox1.Text = richTextBox1.Text.Replace(oldText, newText);
            richTextBox2.Text = richTextBox2.Text.Replace(oldText, newText);
            richTextBox3.Text = richTextBox3.Text.Replace(oldText, newText);

            if (project != null)
            {
                foreach (KoboldAIWorldInfo info in project.worldinfo)
                {
                    info.key = info.key.Replace(oldText, newText);
                    info.content = info.content.Replace(oldText, newText);
                }
            }
        }

        public List<string> GetNames()
        {
            List<string> names = new List<string>();

            string[] promptSplit = new string[] { };
            string[] memorySplit = new string[] { };
            string[] noteSplit = new string[] { };

            if (richTextBox1.Text != "")
            {
                promptSplit = richTextBox1.Text.Split(" ");
            }

            if (richTextBox2.Text != "")
            {
                memorySplit = richTextBox2.Text.Split(" ");
            }

            if (richTextBox3.Text != "")
            {
                noteSplit = richTextBox3.Text.Split(" ");
            }

            List<string[]> infoSplit = new List<string[]>();

            if (project != null)
            {
                foreach (KoboldAIWorldInfo info in project.worldinfo)
                {
                    infoSplit.Add(info.key.Split(" "));
                    infoSplit.Add(info.content.Split(" "));
                }
            }

            foreach (string prompt in promptSplit)
            {
                if (prompt != "")
                {
                    if (Char.IsUpper(prompt, 0))
                    {
                        names.Add(prompt);
                    }
                }

            }

            foreach (string memory in memorySplit)
            {
                if (memory != "")
                {
                    if (Char.IsUpper(memory, 0))
                    {
                        names.Add(memory);
                    }
                }

            }

            foreach (string note in noteSplit)
            {
                if (note != "")
                {
                    if (Char.IsUpper(note, 0))
                    {
                        names.Add(note);
                    }
                }

            }

            foreach (string[] infoArr in infoSplit)
            {
                foreach (string info in infoArr)
                {
                    if (info != "")
                    {
                        if (Char.IsUpper(info, 0))
                        {
                            names.Add(info);
                        }
                    }


                }
            }


            names.RemoveAll(name => name == "A");
            names.RemoveAll(name => name == "As");
            names.RemoveAll(name => name == "He");
            names.RemoveAll(name => name == "He'd");
            names.RemoveAll(name => name == "He'll");
            names.RemoveAll(name => name == "He");
            names.RemoveAll(name => name == "She");
            names.RemoveAll(name => name == "She'd");
            names.RemoveAll(name => name == "She'll");
            names.RemoveAll(name => name == "It");
            names.RemoveAll(name => name == "They");
            names.RemoveAll(name => name == "We");
            names.RemoveAll(name => name == "We'd");
            names.RemoveAll(name => name == "We'll");
            names.RemoveAll(name => name == "We've");
            names.RemoveAll(name => name == "I");
            names.RemoveAll(name => name == "I'd");
            names.RemoveAll(name => name == "I'll");
            names.RemoveAll(name => name == "I've");
            names.RemoveAll(name => name == "You");
            names.RemoveAll(name => name == "You'd");
            names.RemoveAll(name => name == "You'll");
            names.RemoveAll(name => name == "You've");
            names.RemoveAll(name => name == "The");
            names.RemoveAll(name => name == "From");
            names.RemoveAll(name => name == "All");
            names.RemoveAll(name => name == "Were");


            return names;

        }

        public List<string> GetVariables()
        {
            List<string> variables = new List<string>();

            string[] promptSplit = new string[] { };
            string[] memorySplit = new string[] { };
            string[] noteSplit = new string[] { };

            if (richTextBox1.Text != "")
            {
                promptSplit = richTextBox1.Text.Split(" ");
            }

            if (richTextBox2.Text != "")
            {
                memorySplit = richTextBox2.Text.Split(" ");
            }

            if (richTextBox3.Text != "")
            {
                noteSplit = richTextBox3.Text.Split(" ");
            }

            List<string[]> infoSplit = new List<string[]>();

            if (project != null)
            {
                foreach (KoboldAIWorldInfo info in project.worldinfo)
                {
                    infoSplit.Add(info.key.Split(" "));
                    infoSplit.Add(info.content.Split(" "));
                }
            }

            foreach (string prompt in promptSplit)
            {
              if (prompt.StartsWith("$"))
                {
                    variables.Add(prompt);
                }
            }

            foreach (string memory in memorySplit)
            {
                if (memory.StartsWith("$"))
                {
                    variables.Add(memory);
                }
            }

            foreach (string note in noteSplit)
            {
                if (note.StartsWith("$"))
                {
                    variables.Add(note);
                }
            }

            foreach (string[] infoArr in infoSplit)
            {
                foreach (string info in infoArr)
                {
                    if (info.StartsWith("$"))
                    {
                        variables.Add(info);
                    }
                }
            }

            return variables;
        }

        private void replaceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormReplace form = new FormReplace(this);

            form.ShowDialog();
        }

        private void scanForNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormScanner form = new FormScanner(this, ScanType.Names);

            form.ShowDialog();
        }

        private void scanForVariablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormScanner form = new FormScanner(this, ScanType.Variables);

            form.ShowDialog();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            project.worldinfo.Add(new KoboldAIWorldInfo("New Info", "", "", "", null, false, false));

            refreshUI();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                project.worldinfo.RemoveAt(listBox1.SelectedIndex);
            }

            refreshUI();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "JSON File | *.json";
            open.DefaultExt = "json";
            open.InitialDirectory = Application.StartupPath + "WorldInfo";

            if (open.ShowDialog() == DialogResult.OK)
            {
                project.worldinfo.Add(Parser.ReadKoboldAIWorldInfo(open.FileName));
                refreshUI();
            }

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commitChanges();

            project.Sanitize();

            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "JSON File | *.json";
            save.DefaultExt = "json";
            save.InitialDirectory = Application.StartupPath + "WorldInfo";

            if (save.ShowDialog() == DialogResult.OK)
            {
                Parser.WriteKoboldAIWorldInfo(project.worldinfo[listBox1.SelectedIndex],save.FileName);
            }
        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;

            if (index != -1)
            {
                KoboldAIWorldInfo item = project.worldinfo[index];
                project.worldinfo.RemoveAt(index);
                if (index - 1 >= 0)
                {
                    project.worldinfo.Insert(index - 1, item);
                }
                else
                {
                    project.worldinfo.Insert(index, item);
                }

                refreshUI();
            }

        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;

            if (index != -1)
            {
                KoboldAIWorldInfo item = project.worldinfo[index];
                project.worldinfo.RemoveAt(index);
                if (index + 1 <= listBox1.Items.Count - 1)
                {
                    project.worldinfo.Insert(index + 1, item);
                }
                else
                {
                    project.worldinfo.Insert(index, item);
                }

                refreshUI();
            }


        }
    }
}
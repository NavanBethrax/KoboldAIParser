namespace KoboldAPIConverter
{
    public partial class FormConverter : Form
    {
        public FormConverter()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "HOLO File | *.holo";
            open.DefaultExt = "holo";

            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = open.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "JSON File | *.json";
            save.DefaultExt = "json";
            save.InitialDirectory = Application.StartupPath + "Prompts";

            if (save.ShowDialog() == DialogResult.OK)
            {
                Parser.WriteKoboldAIData(Parser.ReadHoloData(textBox1.Text), save.FileName);
            }


        }
    }
}
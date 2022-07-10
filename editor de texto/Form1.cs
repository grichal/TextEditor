using System.IO;

namespace editor_de_texto
{
    public partial class Form1 : Form
    {
        string archivo;

        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog OpenFile = new OpenFileDialog();

            OpenFile.Filter = "Texto| *.txt";
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                archivo = OpenFile.FileName;

                using (StreamReader sr = new StreamReader(archivo))
                {
                    richTextBox2.Text = sr.ReadToEnd();
                }
                

            }Form1.ActiveForm.Text = archivo + "|NOTES";
            
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Texto|*.txt";

            if (archivo != null)
            {
                using(StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.Write(richTextBox2.Text);
                }
            }
            else
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    archivo = saveFile.FileName;
                    using (StreamWriter sw = new StreamWriter(saveFile.FileName))
                    {
                        sw.Write(richTextBox2.Text);
                    }
                }
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            archivo = null;
            Form1.ActiveForm.Text = archivo + "NOTES";
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
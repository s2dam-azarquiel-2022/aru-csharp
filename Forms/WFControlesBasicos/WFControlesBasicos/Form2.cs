using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFControlesBasicos
{
    public partial class Form2 : Form
    {
        private List<Coche> Coches = new List<Coche>();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("Rojo");
            listBox1.Items.Add("Amarillo");
            comboBox1.Items.Add("Otoño");

            Coches.Add(new Coche() { Nombre = "407", Marca = "peugeot" });
            listBox1.DataSource = Coches;
            listBox1.DisplayMember = "Marca";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Load("C:\\Users\\Tu madre\\Downloads\\minabo2.png");
        }
    }
}

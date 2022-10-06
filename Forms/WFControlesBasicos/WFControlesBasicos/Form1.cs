namespace WFControlesBasicos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCambioTexto(object sender, EventArgs e)
        {
            lblMensaje.Text = "Estamos probando Windows Forms";

        }

        private void btnCambioColor(object sender, EventArgs e)
        {
            btnAceptar.BackColor = Color.Yellow;
        }

        private void btnAceptar_MouseLeave(object sender, EventArgs e)
        {
            btnAceptar.BackColor = Color.PowderBlue;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            TextBox Caja=(TextBox)sender;
            MessageBox.Show(Caja.Name);
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A)
            {
                lblMensaje.Text = "Adios";

                e.SuppressKeyPress = true;
            }
        }

        private void btnNuevaVentana_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }
    }
}

namespace WFControlesPersonalizados
{
    internal class BotonPersonalizado : Button
    {
        public BotonPersonalizado()
        {
            this.MouseEnter += BotonPersonalizado_MouseEnter;
            this.MouseLeave += BotonPersonalizado_MouseLeave;
        }
        private void BotonPersonalizado_MouseEnter(object? sender, EventArgs e)
        {
            this.BackColor = Color.DarkViolet;
            this.ForeColor = Color.Yellow;
        }
        private void BotonPersonalizado_MouseLeave(object? sender, EventArgs e)
        {
            this.BackColor = Color.Red;
            this.ForeColor = Color.White;
        }

    }
}

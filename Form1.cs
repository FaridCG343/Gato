namespace Gato
{
    public partial class frmcgfGato : Form
    {
        private string turno = "O";
        private int contador = 0;
        private readonly List<List<PictureBox>> pbList;
        public frmcgfGato()
        {
            InitializeComponent();
            pbList = new List<List<PictureBox>>
            {
                new List<PictureBox>
                {
                    pbcgfC1, pbcgfC2, pbcgfC3
                },
                new List<PictureBox>
                {
                    pbcgfC4, pbcgfC5, pbcgfC6                
                    
                },
                new List<PictureBox>
                {
                    pbcgfC7, pbcgfC8, pbcgfC9
                }
            };
            clear();
        }

        private void pbcgfC_Click(object sender, EventArgs e)
        {
            PictureBox pbcgfC = (PictureBox)sender;
            pbcgfC.Image = (turno == "X") ? Properties.Resources.X : Properties.Resources.Circulo;
            pbcgfTurno.Image = (turno == "X") ? Properties.Resources.Circulo : Properties.Resources.X;
            pbcgfC.Enabled = false;
            pbcgfC.Tag = turno;
            contador++;
            if (is_winner())
            {
                MessageBox.Show("El ganador es " + turno);
                clear();
                return;
            }
            else if (contador == 9)
                {
                MessageBox.Show("Empate");
                clear();
                return;
            }
            turno = (turno == "X") ? "O" : "X";
        }

        private void clear()
        {
            foreach (List<PictureBox> list in pbList)
            {
                foreach (PictureBox pbcgfCT in list)
                {
                    pbcgfCT.Image = null;
                    pbcgfCT.Enabled = true;
                    pbcgfCT.Tag = "";
                }
            }
            pbcgfTurno.Image = Properties.Resources.Circulo;
            turno = "O";
            contador = 0;
        }


        private bool is_winner()
        {
            bool cond1, cond2, cond3, cond4, cond5, cond6, cond7, cond8, winner = false;
            cond1 = pbList[0][0].Tag.ToString() == pbList[0][1].Tag.ToString() && 
                pbList[0][1].Tag.ToString() == pbList[0][2].Tag.ToString() &&
                pbList[0][0].Tag.ToString() != "";
            cond2 = pbList[0][0].Tag.ToString() == pbList[1][0].Tag.ToString() &&
                pbList[1][0].Tag.ToString() == pbList[2][0].Tag.ToString() &&
                pbList[0][0].Tag.ToString() != "";
            cond3 = pbList[1][0].Tag.ToString() == pbList[1][1].Tag.ToString() &&
                pbList[1][1].Tag.ToString() == pbList[1][2].Tag.ToString() &&
                pbList[1][1].Tag.ToString() != "";
            cond4 = pbList[0][1].Tag.ToString() == pbList[1][1].Tag.ToString() &&
                pbList[1][1].Tag.ToString() == pbList[2][1].Tag.ToString() &&
                pbList[1][1].Tag.ToString() != "";
            cond5 = pbList[0][2].Tag.ToString() == pbList[1][2].Tag.ToString() &&
                pbList[1][2].Tag.ToString() == pbList[2][2].Tag.ToString() &&
                pbList[2][2].Tag.ToString() != "";
            cond6 = pbList[2][0].Tag.ToString() == pbList[2][1].Tag.ToString() &&
                pbList[2][1].Tag.ToString() == pbList[2][2].Tag.ToString() &&
                pbList[2][2].Tag.ToString() != ""; ;
            cond7 = pbList[0][2].Tag.ToString() == pbList[1][1].Tag.ToString() &&
                pbList[1][1].Tag.ToString() == pbList[2][0].Tag.ToString() &&
                pbList[1][1].Tag.ToString() != ""; ;
            cond8 = pbList[0][0].Tag.ToString() == pbList[1][1].Tag.ToString() &&
                pbList[1][1].Tag.ToString() == pbList[2][2].Tag.ToString() &&
                pbList[2][2].Tag.ToString() != "";
            return (cond1 || cond2 || cond3 || cond4 || cond5 || cond6 || cond7 || cond8);
        }

        private void btncgfReiniciar_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btncgfSalir_Click(object sender, EventArgs e)
        {
            String resp = MessageBox.Show("Deseas salir?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (resp == "Yes")
                Application.Exit();
            else
                MessageBox.Show("Gracias por quedarte");
        }
    }
}
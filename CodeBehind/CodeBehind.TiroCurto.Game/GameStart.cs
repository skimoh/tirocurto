using System;
using System.Windows.Forms;

namespace CodeBehind.TiroCurto.Voador
{
    public partial class frmGameStart : Form
    {
        int velocidade = 8;
        int gravidade = 15;
        int score = 0;

        public frmGameStart()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ocorre quando uma tecla é pressionada enquanto o controle está em foco.
        /// </summary>        
        private void frmGameStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravidade = -15;
            }
        }

        /// <summary>
        /// Ocorre quando uma tecla é liberada e o controle tem o foco.
        /// </summary>        
        private void frmGameStart_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravidade = 15;
            }
        }


        /// <summary>
        /// Encostou no chão ou bateu no tronco
        /// </summary>
        private void GameOver()
        {
            gameTimer.Stop();
            scoreText.Text += " Game over!!!";
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {

            picMenino.Top += gravidade;
            picCoronaBase.Left -= velocidade;
            picCoronaTopo.Left -= velocidade;
            scoreText.Text = "Score: " + score;

            //ajuste no deslocamento
            if (picCoronaBase.Left < -150)
            {
                picCoronaBase.Left = 800;
                score++;
            }
            if (picCoronaTopo.Left < -180)
            {
                picCoronaTopo.Left = 950;
                score++;
            }

            //encontro
            if (picMenino.Bounds.IntersectsWith(picCoronaBase.Bounds) ||
                picMenino.Bounds.IntersectsWith(picCoronaTopo.Bounds) ||
                picMenino.Bounds.IntersectsWith(picGrama.Bounds) || picMenino.Top < -25
                )
            {
                GameOver();
            }

            //nivel normal
            if (score > 5)
            {
                velocidade = 15;
            }

            //nivel hard
            if (score > 10)
            {
                velocidade = 25;
            }
        }       
    }

}

using System.Media;
using System.Windows.Forms;

namespace CodeBehind.TiroCurto.UrnaEletronica
{
    public partial class frmUrna : Form
    {
        private Dictionary<string, Candidato> _dicCanditado;

        public frmUrna()
        {
            InitializeComponent();
            _dicCanditado = new Dictionary<string, Candidato>();
            _dicCanditado.Add("51", new Candidato() { Id = 51, Nome = "Osmar Motta", Partido = "Aberto", Foto = Properties.Resources.feio });
            _dicCanditado.Add("52", new Candidato() { Id = 52, Nome = "Alan Brado", Partido = "Fechado", Foto = Properties.Resources.CHURRY });
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            RegistrarDigito("1");
        }
        
        private void btn2_Click(object sender, EventArgs e)
        {
            RegistrarDigito("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            RegistrarDigito("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            RegistrarDigito("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            RegistrarDigito("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            RegistrarDigito("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            RegistrarDigito("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            RegistrarDigito("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            RegistrarDigito("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            RegistrarDigito("0");
        }

        private void btnBranco_Click(object sender, EventArgs e)
        {
            pnFim.Visible = true;
            Limpar();

            SoundPlayer s = new SoundPlayer(Properties.Resources.urna1);
            s.Play();

            relogio.Tick += new EventHandler(AcaoFinal);
            relogio.Interval = 3000;
            relogio.Enabled = true;
            relogio.Start();
        }

        private void btnCorrige_Click(object sender, EventArgs e)
        {
            Limpar();
            relogio.Stop();
            relogio.Enabled = false;
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPresidente1.Text))
            {
                MessageBox.Show("Favor informar o candidato.");
                    return;
            }

            pnFim.Visible = true;
            Limpar();
            SoundPlayer s = new SoundPlayer(Properties.Resources.urna1);
            s.Play();

            relogio.Tick += new EventHandler(AcaoFinal);
            relogio.Interval = 3000;
            relogio.Enabled = true;
            relogio.Start();

        }
        
        private void AcaoFinal(Object myObject, EventArgs myEventArgs)
        {
            relogio.Stop();
            relogio.Enabled = false;
            pnFim.Visible = false;
        }
        
        private void RegistrarDigito(string digito)
        {
            if (string.IsNullOrEmpty(txtPresidente1.Text))
                txtPresidente1.Text = digito;
            else
            {
                txtPresidente2.Text = digito;
                PreencherCandidato(txtPresidente1.Text, txtPresidente2.Text);
            }

            SoundPlayer s = new SoundPlayer(Properties.Resources.clique);
            s.Play();
        }
        
        private void PreencherCandidato(string d1, string d2)
        {
            if (_dicCanditado.ContainsKey(d1 + d2))
            {
                lblNome.Text = _dicCanditado[d1 + d2].Nome;
                lblPartido.Text = _dicCanditado[d1 + d2].Partido;
                picFoto.Image = _dicCanditado[d1 + d2].Foto;
            }
            else
            {
                MessageBox.Show("Candidato não encontrado!");
            }
        }
        
        private void Limpar()
        {
            txtPresidente1.Text = "";
            txtPresidente2.Text = "";
            lblNome.Text = String.Empty;
            lblPartido.Text = String.Empty;
            picFoto.Image = null;
        }
    }

    public class Candidato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Partido { get; set; }
        public Image Foto { get; set; }
    }
}
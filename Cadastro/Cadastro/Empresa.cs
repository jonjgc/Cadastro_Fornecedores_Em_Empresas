using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro
{
    public partial class Cadastro : Form
    {

        List<CadEmpresa> empresas;

        public Cadastro()
        {
            InitializeComponent();

            empresas = new List<CadEmpresa>();

            txtUF.Items.Add("AC");
            txtUF.Items.Add("AL");
            txtUF.Items.Add("AP");
            txtUF.Items.Add("AM");
            txtUF.Items.Add("BA");
            txtUF.Items.Add("CE");
            txtUF.Items.Add("DF");
            txtUF.Items.Add("ES");
            txtUF.Items.Add("GO");
            txtUF.Items.Add("MA");
            txtUF.Items.Add("MT");
            txtUF.Items.Add("MS");
            txtUF.Items.Add("MG");
            txtUF.Items.Add("PA");
            txtUF.Items.Add("PB");
            txtUF.Items.Add("PR");
            txtUF.Items.Add("PE");
            txtUF.Items.Add("PI");
            txtUF.Items.Add("RJ");
            txtUF.Items.Add("RN");
            txtUF.Items.Add("RS");
            txtUF.Items.Add("RO");
            txtUF.Items.Add("RR");
            txtUF.Items.Add("SC");
            txtUF.Items.Add("SP");
            txtUF.Items.Add("SE");
            txtUF.Items.Add("TO");

            txtUF.SelectedIndex = 0;
        }

       

        private void Cadastro_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCad_Click(object sender, EventArgs e)
        {
            int index = -1;

            foreach(CadEmpresa c in empresas)
            {
                if (c.Nome == txtNome.Text)
                {
                    index = empresas.IndexOf(c);
                }
            }

            if (txtNome.Text == "")
            {
                MessageBox.Show("Preencha o campo nome!");
                txtNome.Focus();
                return;
            }

            if (txtCEP.Text == "")
            {
                MessageBox.Show("Preencha o campo CEP!");
                txtCEP.Focus();
                return;
            }

            if (txtCNPJ.Text == "")
            {
                MessageBox.Show("Preencha o campo CNPJ!");
                txtCNPJ.Focus();
                return;
            }

            if (txtUF.Text == "")
            {
                MessageBox.Show("Preencha o campo UF!");
                txtUF.Focus();
                return;
            }

            if (txtLocal.Text == "")
            {
                MessageBox.Show("Preencha o campo local!");
                txtLocal.Focus();
                return;
            }

            if (txtLogra.Text == "")
            {
                MessageBox.Show("Preencha o campo logradouro!");
                txtLogra.Focus();
                return;
            }

            CadEmpresa p = new CadEmpresa();

            p.Nome = txtNome.Text;
            p.Cep = txtCEP.Text;
            p.Cnpj = txtCNPJ.Text;
            p.Uf = txtUF.Text;
            p.Localidade = txtLocal.Text;
            p.Logradouro = txtLogra.Text;

            if (index < 0)
            {
                empresas.Add(p);
            }
            else
            {
                empresas[index] = p; 
            }

            btnLimpar_Click(btnLimpar, EventArgs.Empty);

            Listar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int indice = lista.SelectedIndex;
            empresas.RemoveAt(indice);
            Listar();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtCNPJ.Text = "";
            txtCEP.Text = "";
            txtUF.SelectedIndex = 0;
            txtLocal.Text = "";
            txtLogra.Text = "";

            txtNome.Focus(); 
        }

        private void Listar()
        {
            lista.Items.Clear();

            foreach ( CadEmpresa p in empresas)
            {
                lista.Items.Add(p.Nome);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastroFornecedor segundaTela = new CadastroFornecedor();
            segundaTela.ShowDialog();
        }

        private void lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int indice = lista.SelectedIndex;
            CadEmpresa p = empresas[indice];

            txtNome.Text = p.Nome;
            txtCNPJ.Text = p.Cnpj;
            txtCEP.Text = p.Cep;
            txtUF.Text = p.Cep;
            txtLocal.Text = p.Localidade;
            txtLogra.Text = p.Logradouro;
        }
    }
}

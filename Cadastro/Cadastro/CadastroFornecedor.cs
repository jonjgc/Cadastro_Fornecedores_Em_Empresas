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
    public partial class CadastroFornecedor : Form
    {
        List<CadFornecedor> fornecedor;
        public CadastroFornecedor()
        {
            InitializeComponent();

            fornecedor = new List<CadFornecedor>();



        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CadastroFornecedor_Load(object sender, EventArgs e)
        {

        }

        private void btnCadF_Click(object sender, EventArgs e)
        {
            int index = -1;

            foreach (CadFornecedor c in fornecedor)
            {
                if (c.Empresa == txtNomEmpresa.Text)
                {
                    index = fornecedor.IndexOf(c);
                }
            }

            if (txtNomEmpresa.Text == "")
            {
                MessageBox.Show("Preencha o campo Empresa!");
                txtNomEmpresa.Focus();
                return;
            }

            if (txtNome1.Text == "")
            {
                MessageBox.Show("Preencha o campo Nome!");
                txtNome1.Focus();
                return;
            }

            if (txtCNPJ.Text == "  ,   ,   /    -" && txtCPF.Text == "         -") 
            {
                MessageBox.Show("Preencha somente o campo CNPJ ou o campo CPF!");
                txtCNPJ.Focus();
                return;
            }


            if (txtTel.Text == "(  )     -")
            {
                MessageBox.Show("Preencha o campo Telefone!");
                txtTel.Focus();
                return;
            }

            if (txtDataCad.Text == "")
            {
                MessageBox.Show("Preencha o campo Data do Cadastro!");
                txtDataCad.Focus();
                return;
            }

            CadFornecedor p = new CadFornecedor();

            p.Empresa = txtNomEmpresa.Text;
            p.NomeF = txtNome1.Text;
            p.Cpf_cnpj = txtCNPJ.Text;
            p.Rg = txtRG.Text;
            p.DataNasc = txtDateNasc.Text;
            p.DataCad = txtDataCad.Text;
            p.Telefone = txtTel.Text;

            if (index < 0)
            {
                fornecedor.Add(p);
            } else
            {
                fornecedor[index] = p;
            }

            btnLimparF_Click(btnLimparF, EventArgs.Empty);

            listaForn_SelectedIndexChanged(listaForn, EventArgs.Empty);

        }

        private void btnExcluirF_Click(object sender, EventArgs e)
        {
            int indice = listaForn.SelectedIndex;
            fornecedor.RemoveAt(indice);
            listaForn_SelectedIndexChanged(listaForn, EventArgs.Empty);

        }

        private void btnLimparF_Click(object sender, EventArgs e)
        {
            txtNomEmpresa.Text = "";
            txtNome1.Text = "";
            txtCNPJ.Text = "";
            txtRG.Text = "";
            txtTel.Text = "";
            txtDateNasc.Text = "";
            txtDataCad.Text = "";

            txtNomEmpresa.Focus();

        }

        private void listaForn_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaForn.Items.Clear();

            foreach (CadFornecedor p in fornecedor)
            {
                listaForn.Items.Add(p.Empresa);
            }
        }

        private void listaForn_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int indice = listaForn.SelectedIndex;
            CadFornecedor p = fornecedor[indice];

            txtNomEmpresa.Text = p.Empresa;
            txtNome1.Text = p.NomeF;
            txtCNPJ.Text = p.Cpf_cnpj;
            txtCPF.Text = p.Cpf_cnpj;
            txtRG.Text = p.Rg;
            txtTel.Text = p.Telefone;
            txtDateNasc.Text = p.DataNasc;
            txtDataCad.Text = p.DataCad;
        }
    }
}

using System;
using System.Windows.Forms;

namespace projeto_calculadora
{
    public partial class FrmPrincipal : Form
    {

        private double _NumeroUm;
        private double _NumeroDois;
        private string _Operacao;
        private bool _PressionouIgual;
        private double _Resultado;

        public FrmPrincipal()
        {
            InitializeComponent();
        }
        private void LimparTxtResultado()
        {
            TxtResultado.Clear();
        }
        private void LimparCampos()
        {
            LimparTxtResultado();
            _NumeroUm = 0;
            _NumeroDois = 0;
            _Operacao = string.Empty;
            _PressionouIgual = false;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private bool VerificaSeIgualZero()
        {
            if (TxtResultado.Text.Trim().Equals("0")) return true;
            else return false;
        }

        private bool VerificaSeVazio()
        {
            if (TxtResultado.Text.Trim().Equals(string.Empty)) return true;
            else return false;
        }

        private bool VeriricaSeIgualPressionado()
        {
            if (_PressionouIgual) return true;
            else return false;
        }

        private bool VerificaSeTemPonto()
        {
            if (TxtResultado.Text.Trim().Contains(".")) return true;
            else return false;
        }

        private void CalcularResultado()
        {
            switch (_Operacao)
            {
                case "/":
                if (_NumeroDois == 0)
                {
                    MessageBox.Show("Não é permitido divisão por 0", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                else
                    _Resultado = _NumeroUm / _NumeroDois;
                break;

                case "*":
                _Resultado = _NumeroUm * _NumeroDois;
                break;

                case "-":
                _Resultado = _NumeroUm - _NumeroDois;
                break;

                case "+":
                _Resultado = _NumeroUm + _NumeroDois;
                break;

                case "^":
                _Resultado = CalcularPotencia(_NumeroUm, _NumeroDois);
                break;

            }
            TxtResultado.Text = _Resultado.ToString().Replace(",", ".");
        }

        private void InserirValor(string valor)
        {
            if (VeriricaSeIgualPressionado())
            {
                LimparTxtResultado();
                _PressionouIgual = false;
            }
            if (VerificaSeIgualZero()) TxtResultado.Text = valor;
            else TxtResultado.Text += valor;
        }

        private void AdicionarOperacao(string operacao)
        {
            if (!VerificaSeVazio())
            {
                if (VerificaSeTemPonto()) _NumeroUm = Convert.ToDouble(TxtResultado.Text.Trim().Replace(".", ","));
                else _NumeroUm = Convert.ToDouble(TxtResultado.Text.Trim());
                _Operacao = operacao;
                LimparTxtResultado();
            }
            else
            {
                MessageBox.Show("Precisar ser inserido algum valor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public double CalcularPotencia(double valorBase, double valorExpoente)
        {
            return Math.Pow(valorBase, valorExpoente);

        }

        private void BtnZero_Click(object sender, EventArgs e)
        {
            if (!VerificaSeIgualZero()) TxtResultado.Text = TxtResultado.Text + "0";
        }

        private void BtnUm_Click(object sender, EventArgs e)
        {
            InserirValor("1");
        }

        private void BtnDois_Click(object sender, EventArgs e)
        {
            InserirValor("2");
        }

        private void BtnTres_Click(object sender, EventArgs e)
        {
            InserirValor("3");
        }

        private void BtnQuatro_Click(object sender, EventArgs e)
        {
            InserirValor("4");
        }

        private void BtnCinco_Click(object sender, EventArgs e)
        {
            InserirValor("5");
        }

        private void BtnSeis_Click(object sender, EventArgs e)
        {
            InserirValor("6");
        }

        private void BtnSete_Click(object sender, EventArgs e)
        {
            InserirValor("7");
        }

        private void BtnOito_Click(object sender, EventArgs e)
        {
            InserirValor("8");
        }

        private void BtnNove_Click(object sender, EventArgs e)
        {
            InserirValor("9");
        }

        private void BtnDividir_Click(object sender, EventArgs e)
        {
            AdicionarOperacao("/");
        }

        private void BtnMultiplicar_Click(object sender, EventArgs e)
        {
            AdicionarOperacao("*");
        }

        private void BtnSubtrair_Click(object sender, EventArgs e)
        {
            AdicionarOperacao("-");
        }

        private void BtnSomar_Click(object sender, EventArgs e)
        {
            AdicionarOperacao("+");
        }

        private void BtnIgual_Click(object sender, EventArgs e)
        {
            if (_PressionouIgual)
            {
                LimparTxtResultado();
                _PressionouIgual = false;
                return;
            }
            if (!VerificaSeVazio())
            {

                if (VerificaSeTemPonto()) _NumeroDois = Convert.ToDouble(TxtResultado.Text.Trim().Replace(".", ","));
                else _NumeroDois = Convert.ToDouble(TxtResultado.Text.Trim());
                CalcularResultado();
                _PressionouIgual = true;
            }
        }

        private void BtnPonto_Click(object sender, EventArgs e)
        {
            if (_PressionouIgual)
            {
                TxtResultado.Text = "0.";
                _PressionouIgual = false;
                return;
            }
            if (VerificaSeVazio()) TxtResultado.Text = "0.";
            if (VerificaSeTemPonto()) return;
            TxtResultado.Text += ".";
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void BtnLimpaUltimoValor_Click(object sender, EventArgs e)
        {
            if (_Operacao.Equals(string.Empty) || _PressionouIgual) LimparCampos();
            else LimparTxtResultado();
        }

        private void BtnTrocaSinal_Click(object sender, EventArgs e)
        {
            if (!VerificaSeVazio()) TxtResultado.Text = (Convert.ToDouble(TxtResultado.Text.Trim().Replace(".", ",")) * (-1)).ToString().Replace(",", ".");
        }

        private void BtnRemoveUltimo_Click(object sender, EventArgs e)
        {
            int Tamanho = TxtResultado.Text.Trim().Length;
            string Texto = TxtResultado.Text.Trim();
            LimparTxtResultado();
            for (int i = 0; i < Tamanho - 1; i++) TxtResultado.Text += Texto[i];
        }

        private void BtnElevadoQuadrado_Click(object sender, EventArgs e)
        {
            if (!VerificaSeVazio())
            {
                double ValorBase = Convert.ToDouble(TxtResultado.Text.Trim().Replace(".", "."));
                double Resultado = CalcularPotencia(ValorBase, 2);
                TxtResultado.Text = Resultado.ToString().Replace(",", ".");
                _PressionouIgual = true;
            }
        }

        private void BtnPotencia_Click(object sender, EventArgs e)
        {
            AdicionarOperacao("^");
        }

        private void BtnRaiz_Click(object sender, EventArgs e)
        {
            if (!VerificaSeVazio())
            {
                double ValorBase = Convert.ToDouble(TxtResultado.Text.Trim().Replace(".", "."));
                double Resultado = Math.Sqrt(ValorBase);
                TxtResultado.Text = Resultado.ToString().Replace(",", ".");
                _PressionouIgual = true;
            }
        }

        private void btn1x_Click(object sender, EventArgs e)
        {
            if (!VerificaSeVazio())
            {
                double ValorBase = Convert.ToDouble(TxtResultado.Text.Trim().Replace(".", "."));
                if (ValorBase == 0)
                {
                    MessageBox.Show("Erro divisão por zero", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double Resultado = 1 / ValorBase;
                TxtResultado.Text = Resultado.ToString().Replace(",", ".");
                _PressionouIgual = true;
            }
        }
    }
}

using System;
using System.Windows.Forms;

namespace projeto_calculadora.Controller
{
    class ControllerPrincipal
    {

        private TextBox Txt { get; set; }
        private Panel Pnl { get; set; }
        internal double _NumeroUm { get; set; }
        internal double _NumeroDois { get; set; }
        internal string _Operacao { get; set; }
        internal bool _PressionouIgual { get; set; }
        internal double _Resultado { get; set; }

        public ControllerPrincipal(TextBox txt, Panel pnlFundo)
        {
            Txt = txt;
            Pnl = pnlFundo;
        }

        // Limpa todos os campos
        private void LimparCampos()
        {
            _NumeroUm = 0;
            _NumeroDois = 0;
            Txt.Text = string.Empty;
            _Operacao = string.Empty;
            _PressionouIgual = false;
            Pnl.Focus();
        }

        // Limpa o TxtResultado
        private void LimparTxtResultado()
        {
            Txt.Clear();
            Pnl.Focus();
        }

        // Limpa tudo
        internal void LimparTudo()
        {
            LimparCampos();
            LimparTxtResultado();
        }

        // Verifica se Txt é igual a zer
        private bool VerificaSeIgualZero()
        {
            return Txt.Text.Trim().Equals("0") ? true : false;
        }

        // Verifica se Txt está vázio
        private bool VerificaSeVazio()
        {
            return Txt.Text.Trim().Equals(string.Empty) ? true : false;
        }

        // Verifica se tem ponto no Txt
        private bool VerificaSeTemPonto()
        {
            return Txt.Text.Trim().Contains(".") ? true : false;
        }

        // Verifica se o igual foi pressionado
        private bool VerificaSeIgualPressionado()
        {
            return _PressionouIgual ? true : false;
        }

        // Verifica se contém as operações
        private bool VerificaSeContemOperacoes(string txt)
        {
            return (txt.Contains("/") || txt.Contains("*") || txt.Contains("+") || txt.Contains("-") || txt.Contains("^")) ? true : false;
        }

        // Remove a operação do Txt na hora da soma
        private string RemoveOperacaoTxt(string txt)
        {
            if (VerificaSeContemOperacoes(txt))
            {
                int nmrUm = _NumeroUm.ToString().Trim().Length + 1;
                int nmrDois = txt.Trim().Length;
                return txt.Substring(nmrUm, nmrDois - nmrUm);
            }
            else return txt;
        }

        // Limpa o último número digitado após a operação
        private string LimpaAposOperacao(string txt)
        {
            if (VerificaSeContemOperacoes(txt))
            {
                int nmrUm = _NumeroUm.ToString().Trim().Length + 1;
                return txt.Substring(0, nmrUm);
            }
            else return txt;
        }

        // Calcula o Resultado
        internal void CalcularResultado(string operacao)
        {
            switch (operacao)
            {
                case "/":
                if (_NumeroDois == 0)
                {
                    MessageBox.Show("Não é permitido divisão por 0", "Calculadora", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            LimparTxtResultado();
            Txt.Text = _Resultado.ToString().Replace(",", ".");
            Pnl.Focus();
        }

        // Insere o valor
        internal void InserirValor(string valor)
        {
            if (VerificaSeIgualPressionado())
            {
                _PressionouIgual = false;
            }
            Txt.Text += valor;
            Pnl.Focus();
        }

        // Adiciona a operação
        internal void AdicionarOperacao(string operacao)
        {
            if (!VerificaSeVazio())
            {
                if (VerificaSeTemPonto()) _NumeroUm = Convert.ToDouble(Txt.Text.Trim().Replace(".", ","));
                else _NumeroUm = Convert.ToDouble(Txt.Text.Trim());

                _Operacao = operacao;
                Txt.Text += _Operacao;
            }
            else
            {
                MessageBox.Show("Precisar ser inserido algum valor", "Calculadora", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Pnl.Focus();
        }

        // Calcula a potência
        private double CalcularPotencia(double valorBase, double valorExpoente)
        {
            return Math.Pow(valorBase, valorExpoente);
        }

        // Ação quando o botão zero é pressionado
        internal void ActionZero()
        {
            if (!VerificaSeIgualZero()) Txt.Text += "0";
        }

        // Ação quando o botão igual é pressionado
        internal void ActionIgual()
        {
            if (VerificaSeIgualPressionado())
            {
                LimparTxtResultado();
                _PressionouIgual = false;
                return;
            }
            if (!VerificaSeVazio())
            {
                if (VerificaSeTemPonto())
                {
                    _NumeroDois = Convert.ToDouble(RemoveOperacaoTxt(Txt.Text.Trim().ToString().Replace(".", ",")));
                }
                else _NumeroDois = Convert.ToDouble(RemoveOperacaoTxt(Txt.Text.Trim().ToString().Replace(".", ",")));
                CalcularResultado(_Operacao);
                _PressionouIgual = true;
            }
            Pnl.Focus();
        }

        // Ação qundo o botão . é pressionado
        internal void ActionPonto()
        {

            string antesOperacao = LimpaAposOperacao(Txt.Text.Trim());
            string depoisOperacao = RemoveOperacaoTxt(Txt.Text.Trim());

            if (!antesOperacao.Contains("."))
            {
                if (antesOperacao.Equals("") || antesOperacao[0].Equals("0") || VerificaSeContemOperacoes(antesOperacao))
                {
                    Txt.Text += "0";
                }
                Txt.Text += ".";

            }
            else if (!depoisOperacao.Contains("."))
            {
                if (depoisOperacao.Equals("") || depoisOperacao[0].Equals("0"))
                {
                    Txt.Text += "0";
                }
                Txt.Text += ".";
            }

            Pnl.Focus();
        }

        // Ação quando o botão <-- é pressionado
        internal void ActionLimpaUltimoValor()
        {
            if (_Operacao.Equals(string.Empty) || VerificaSeIgualPressionado()) LimparCampos();
            else Txt.Text = LimpaAposOperacao(Txt.Text);
            Pnl.Focus();
        }

        // Ação quando o botão TrocaSinal é pressionado
        internal void ActionTrocaSinal()
        {
            if (!VerificaSeVazio()) Txt.Text = (Convert.ToDouble(Txt.Text.Trim().Replace(".", ",")) * (-1)).ToString().Replace(",", ".");
            Pnl.Focus();
        }

        // Ação quando o botão LimpaUltimo é pressionado
        internal void ActionRemoveUltimo()
        {
            string Texto = Txt.Text.Trim();
            int tamanho = Texto.Trim().Length;
            LimparTxtResultado();
            for (int i = 0; i < tamanho - 1; i++) Txt.Text += Texto[i];
            Pnl.Focus();
        }

        // Ação quando o botão ElevadoQuadrado é pressionado
        internal void ActionElevaQuadrado()
        {
            if (!VerificaSeVazio())
            {
                double ValorBase = Convert.ToDouble(Txt.Text.Trim().Replace(".", "."));
                double Resultado = CalcularPotencia(ValorBase, 2);
                Txt.Text = Resultado.ToString().Replace(",", ".");
                _PressionouIgual = true;
            }
            Pnl.Focus();
        }

        // Ação quando o botão Raiz é pressionado
        internal void ActionRaiz()
        {
            if (!VerificaSeVazio())
            {
                double ValorBase = Convert.ToDouble(Txt.Text.Trim().Replace(".", "."));
                double Resultado = Math.Sqrt(ValorBase);
                Txt.Text = Resultado.ToString().Replace(",", ".");
                _PressionouIgual = true;
            }
            Pnl.Focus();
        }

        // Ação quando o botão 1x é pressionado
        internal void Action1x()
        {
            if (!VerificaSeVazio())
            {
                double ValorBase = Convert.ToDouble(Txt.Text.Trim().Replace(".", "."));
                if (ValorBase == 0)
                {
                    MessageBox.Show("Erro divisão por zero", "Calculadora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double Resultado = 1 / ValorBase;
                Txt.Text = Resultado.ToString().Replace(",", ".");
                _PressionouIgual = true;
            }
            Pnl.Focus();
        }
    }
}

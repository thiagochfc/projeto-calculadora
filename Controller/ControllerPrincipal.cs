using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_calculadora.Controller
{
    class ControllerPrincipal
    {

        internal double _NumeroUm { get; set; }
        internal double _NumeroDois { get; set; }
        internal string _Operacao { get; set; }
        internal bool _PressionouIgual { get; set; }
        internal double _Resultado { get; set; }

        // Limpa todos os campos
        internal void LimparCampos()
        {
            _NumeroUm = 0;
            _NumeroDois = 0;
            _Operacao = string.Empty;
            _PressionouIgual = false;
        }

        // Limpa o TxtResultado
        internal void LimparTxtResultado(TextBox txt)
        {
            txt.Clear();
        }

        // Verifica se Txt é igual a zer
        internal bool VerificaSeIgualZero(TextBox txt)
        {
            if (txt.Text.Trim().Equals("0")) return true;
            else return false;
        }

        // Verifica se Txt está vázio
        internal bool VerificaSeVazio(TextBox txt)
        {
            if (txt.Text.Trim().Equals(string.Empty)) return true;
            else return false;
        }

        // Verifica se tem . no Txt
        internal bool VerificaSeTemPonto(TextBox txt)
        {
            if (txt.Text.Trim().Contains(".")) return true;
            else return false;
        }

        // Verifica se o igual foi pressionado
        internal bool VeriricaSeIgualPressionado(bool pressionouIgual)
        {
            if (pressionouIgual) return true;
            else return false;
        }

        // Calcula o Resultado
        internal void CalcularResultado(string operacao, TextBox txt)
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
            txt.Text = _Resultado.ToString().Replace(",", ".");
        }

        // Insere o valor
        internal void InserirValor(string valor, TextBox txt)
        {
            if (VeriricaSeIgualPressionado(_PressionouIgual))
            {
                LimparTxtResultado(txt);
                _PressionouIgual = false;
            }
            if (VerificaSeIgualZero(txt)) txt.Text += valor;
            else txt.Text += valor;
        }

        // Adiciona a operação
        internal void AdicionarOperacao(string operacao, TextBox txt)
        {
            if (!VerificaSeVazio(txt))
            {
                if (VerificaSeTemPonto(txt)) _NumeroUm = Convert.ToDouble(txt.Text.Trim().Replace(".", ","));
                else _NumeroUm = Convert.ToDouble(txt.Text.Trim());
                _Operacao = operacao;
                LimparTxtResultado(txt);
            }
            else
            {
                MessageBox.Show("Precisar ser inserido algum valor", "Calculadora", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Calcula a potência
        private double CalcularPotencia(double valorBase, double valorExpoente)
        {
            return Math.Pow(valorBase, valorExpoente);

        }

        // Ação quando o botão igual é pressionado
        internal void ActionIgual(TextBox txt)
        {
            if (_PressionouIgual)
            {
                LimparTxtResultado(txt);
                _PressionouIgual = false;
                return;
            }
            if (!VerificaSeVazio(txt))
            {

                if (VerificaSeTemPonto(txt)) _NumeroDois = Convert.ToDouble(txt.Text.Trim().Replace(".", ","));
                else _NumeroDois = Convert.ToDouble(txt.Text.Trim());
                CalcularResultado(_Operacao, txt);
                _PressionouIgual = true;
            }
        }

        // Ação qundo o botão . é pressionado
        internal void ActionPonto(TextBox txt)
        {
            if (_PressionouIgual)
            {
                txt.Text = "0.";
                _PressionouIgual = false;
                return;
            }
            if (VerificaSeVazio(txt)) txt.Text = "0.";
            if (VerificaSeTemPonto(txt)) return;
            txt.Text += ".";
        }

        // Ação quando o botão <-- é pressionado
        internal void ActionLimpaUltimoValor(TextBox txt)
        {
            if (_Operacao.Equals(string.Empty) || _PressionouIgual) LimparCampos();
            else LimparTxtResultado(txt);

        }

        // Ação quando o botão TrocaSinal é pressionado
        internal void ActionTrocaSinal(TextBox txt)
        {
            if (!VerificaSeVazio(txt)) txt.Text = (Convert.ToDouble(txt.Text.Trim().Replace(".", ",")) * (-1)).ToString().Replace(",", ".");
        }

        // Ação quando o botão LimpaUltimo é pressionado
        internal void ActionRemoveUltimo(int tamanho, TextBox txt)
        {
            string Texto = txt.Text.Trim();
            LimparTxtResultado(txt);
            for (int i = 0; i < tamanho - 1; i++) txt.Text += Texto[i];
        }

        // Ação quando o botão ElevadoQuadrado é pressionado
        internal void ActionElevaQuadrado(TextBox txt)
        {
            if (!VerificaSeVazio(txt))
            {
                double ValorBase = Convert.ToDouble(txt.Text.Trim().Replace(".", "."));
                double Resultado = CalcularPotencia(ValorBase, 2);
                txt.Text = Resultado.ToString().Replace(",", ".");
                _PressionouIgual = true;
            }
        }

        // Ação quando o botão Raiz é pressionado
        internal void ActionRaiz(TextBox txt)
        {
            if (!VerificaSeVazio(txt))
            {
                double ValorBase = Convert.ToDouble(txt.Text.Trim().Replace(".", "."));
                double Resultado = Math.Sqrt(ValorBase);
                txt.Text = Resultado.ToString().Replace(",", ".");
                _PressionouIgual = true;
            }
        }

        // Ação quando o botão 1x é pressionado
        internal void Action1x(TextBox txt)
        {
            if (!VerificaSeVazio(txt))
            {
                double ValorBase = Convert.ToDouble(txt.Text.Trim().Replace(".", "."));
                if (ValorBase == 0)
                {
                    MessageBox.Show("Erro divisão por zero", "Calculadora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double Resultado = 1 / ValorBase;
                txt.Text = Resultado.ToString().Replace(",", ".");
                _PressionouIgual = true;
            }
        }
    }
}

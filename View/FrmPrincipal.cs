﻿using System;
using System.Windows.Forms;
using projeto_calculadora.Controller;

namespace projeto_calculadora.View
{
    public partial class FrmPrincipal : Form
    {

        ControllerPrincipal controller = new ControllerPrincipal();

        public FrmPrincipal()
        {
            InitializeComponent();
            PnlFundo.Focus();
        }

        private void LimparTxtResultado() => controller.LimparTxtResultado(TxtResultado);

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            LimparTxtResultado();
            controller.LimparCampos();
            PnlFundo.Focus();
        }

        private void BtnZero_Click(object sender, EventArgs e)
        {
            if (!controller.VerificaSeIgualZero(TxtResultado)) TxtResultado.Text += "0";
        }

        private void BtnUm_Click(object sender, EventArgs e) => controller.InserirValor("1", TxtResultado);

        private void BtnDois_Click(object sender, EventArgs e) => controller.InserirValor("2", TxtResultado);

        private void BtnTres_Click(object sender, EventArgs e) => controller.InserirValor("3", TxtResultado);

        private void BtnQuatro_Click(object sender, EventArgs e) => controller.InserirValor("4", TxtResultado);
        
        private void BtnCinco_Click(object sender, EventArgs e) => controller.InserirValor("5", TxtResultado);

        private void BtnSeis_Click(object sender, EventArgs e) => controller.InserirValor("6", TxtResultado);

        private void BtnSete_Click(object sender, EventArgs e) => controller.InserirValor("7", TxtResultado);

        private void BtnOito_Click(object sender, EventArgs e) => controller.InserirValor("8", TxtResultado);

        private void BtnNove_Click(object sender, EventArgs e) => controller.InserirValor("9", TxtResultado);

        private void BtnDividir_Click(object sender, EventArgs e) => controller.AdicionarOperacao("/", TxtResultado);

        private void BtnMultiplicar_Click(object sender, EventArgs e) => controller.AdicionarOperacao("*", TxtResultado);

        private void BtnSubtrair_Click(object sender, EventArgs e) => controller.AdicionarOperacao("-", TxtResultado);

        private void BtnSomar_Click(object sender, EventArgs e) => controller.AdicionarOperacao("+", TxtResultado);

        private void BtnIgual_Click(object sender, EventArgs e)
        {
            controller.ActionIgual(TxtResultado);
            PnlFundo.Focus();
        }

        private void BtnPonto_Click(object sender, EventArgs e)
        {
            controller.ActionPonto(TxtResultado);
            PnlFundo.Focus();
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            controller.LimparCampos();
            LimparTxtResultado();
            PnlFundo.Focus();
        }

        private void BtnLimpaUltimoValor_Click(object sender, EventArgs e)
        {
            controller.ActionLimpaUltimoValor(TxtResultado);
            PnlFundo.Focus();
        }

        private void BtnTrocaSinal_Click(object sender, EventArgs e)
        {
            controller.ActionTrocaSinal(TxtResultado);
            PnlFundo.Focus();
        }

        private void BtnRemoveUltimo_Click(object sender, EventArgs e)
        {
            int Tamanho = TxtResultado.Text.Trim().Length;
            controller.ActionRemoveUltimo(Tamanho, TxtResultado);
            PnlFundo.Focus();
        }

        private void BtnElevadoQuadrado_Click(object sender, EventArgs e)
        {
            controller.ActionElevaQuadrado(TxtResultado);
            PnlFundo.Focus();
        }

        private void BtnPotencia_Click(object sender, EventArgs e) => controller.AdicionarOperacao("^", TxtResultado);

        private void BtnRaiz_Click(object sender, EventArgs e)
        {
            controller.ActionRaiz(TxtResultado);
            PnlFundo.Focus();
        }

        private void Btn1x_Click(object sender, EventArgs e)
        {
            controller.Action1x(TxtResultado);
            PnlFundo.Focus();
        }

        private void PnlFundo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) BtnLimpar_Click(BtnLimpar, new EventArgs());
            if (e.KeyCode == Keys.Enter) BtnIgual_Click(BtnIgual, new EventArgs());
            if (e.KeyCode == Keys.Back) BtnRemoveUltimo_Click(BtnRemoveUltimo, new EventArgs());
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0) BtnZero_Click(BtnZero, new EventArgs());
            if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1) BtnUm_Click(BtnUm, new EventArgs());
            if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2) BtnDois_Click(BtnDois, new EventArgs());
            if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3) BtnTres_Click(BtnTres, new EventArgs());
            if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4) BtnQuatro_Click(BtnQuatro, new EventArgs());
            if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5) BtnCinco_Click(BtnCinco, new EventArgs());
            if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6) BtnSeis_Click(BtnSeis, new EventArgs());
            if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7) BtnSete_Click(BtnSete, new EventArgs());
            if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8) BtnOito_Click(BtnOito, new EventArgs());
            if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9) BtnNove_Click(BtnNove, new EventArgs());
            if (e.KeyCode == Keys.Divide) BtnDividir_Click(BtnDividir, new EventArgs());
            if (e.KeyCode == Keys.Multiply) BtnMultiplicar_Click(BtnMultiplicar, new EventArgs());
            if (e.KeyCode == Keys.Add) BtnSomar_Click(BtnSomar, new EventArgs());

        }
    }
}
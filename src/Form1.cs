// This file is part of the Pendu project
// Copyright 2021 Maël Coulmance

#nullable  enable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pendu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            mot = new Mot();
            this.outputText.Font = new Font("Arial", 20, FontStyle.Bold);
            this.outputText.TextAlign = ContentAlignment.MiddleCenter;
            this.outputText.Text = mot.GetMot();
            
            SetButtonsVisible(true);
            SetButtonsEnabled(true);
            rejouerButton.Visible = false;
            quitterButton.Visible = false;
            
            KeyPress += OnKeyPress;
        }

        private void OnKeyPress(object? sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'a':
                    aButton_Click(aButton, EventArgs.Empty);
                    break;
                case 'b':
                    bButton_Click(bButton, EventArgs.Empty);
                    break;
                case 'c':
                    cButton_Click(cButton, EventArgs.Empty);
                    break;
                case 'd':
                    dButton_Click(dButton, EventArgs.Empty);
                    break;
                case 'e':
                    eButton_Click(eButton, EventArgs.Empty);
                    break;
                case 'f':
                    fButton_Click(fButton, EventArgs.Empty);
                    break;
                case 'g':
                    gButton_Click(gButton, EventArgs.Empty);
                    break;
                case 'h':
                    hButton_Click(hButton, EventArgs.Empty);
                    break;
                case 'i':
                    iButton_Click(iButton, EventArgs.Empty);
                    break;
                case 'j':
                    jButton_Click(jButton, EventArgs.Empty);
                    break;
                case 'k':
                    kButton_Click(kButton, EventArgs.Empty);
                    break;
                case 'l':
                    lButton_Click(lButton, EventArgs.Empty);
                    break;
                case 'm':
                    mButton_Click(mButton, EventArgs.Empty);
                    break;
                case 'n':
                    nButton_Click(nButton, EventArgs.Empty);
                    break;
                case 'o':
                    oButton_Click(oButton, EventArgs.Empty);
                    break;
                case 'p':
                    pButton_Click(pButton, EventArgs.Empty);
                    break;
                case 'q':
                    qButton_Click(qButton, EventArgs.Empty);
                    break;
                case 'r':
                    rButton_Click(rButton, EventArgs.Empty);
                    break;
                case 's':
                    sButton_Click(sButton, EventArgs.Empty);
                    break;
                case 't':
                    tButton_Click(tButton, EventArgs.Empty);
                    break;
                case 'u':
                    uButton_Click(uButton, EventArgs.Empty);
                    break;
                case 'v':
                    vButton_Click(vButton, EventArgs.Empty);
                    break;
                case 'w':
                    wButton_Click(wButton, EventArgs.Empty);
                    break;
                case 'x':
                    xButton_Click(xButton, EventArgs.Empty);
                    break;
                case 'y':
                    yButton_Click(yButton, EventArgs.Empty);
                    break;
                case 'z':
                    zButton_Click(zButton, EventArgs.Empty);
                    break;
                default:
                    break;
            }
        }


        private readonly Bitmap PerduBmp = new Bitmap("./assets/perdu.bmp");
        private readonly Bitmap WinBmp = new Bitmap("./assets/gagne.bmp");
        private readonly Bitmap[] StepBmp = new Bitmap[10]
        {
            new Bitmap("./assets/step1.bmp"),
            new Bitmap("./assets/step2.bmp"),
            new Bitmap("./assets/step3.bmp"),
            new Bitmap("./assets/step4.bmp"),
            new Bitmap("./assets/step5.bmp"),
            new Bitmap("./assets/step6.bmp"),
            new Bitmap("./assets/step7.bmp"),
            new Bitmap("./assets/step8.bmp"),
            new Bitmap("./assets/step9.bmp"),
            new Bitmap("./assets/step10.bmp")
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void UpdateEnv()
        {
            if (mot.IsWin())
            {
                SetButtonsVisible(false);
                this.pictureBox.Image = this.WinBmp;
                this.outputText.Text = mot.GetFullMot();
                rejouerButton.Visible = true;
                quitterButton.Visible = true;
            } else if (mot.GetVie() <= 0)
            {
                SetButtonsVisible(false);
                this.pictureBox.Image = this.PerduBmp;
                this.outputText.Text = mot.GetFullMot();
                rejouerButton.Visible = true;
                quitterButton.Visible = true;
            }
            else
            {
                int step = 10 - mot.GetVie();
                this.pictureBox.Image = this.StepBmp[step];
                this.outputText.Text = mot.GetMot();
            }
        }

        private void SetButtonsEnabled(bool arg)
        {
            this.aButton.Enabled = arg;
            this.bButton.Enabled = arg;
            this.cButton.Enabled = arg;
            this.dButton.Enabled = arg;
            this.eButton.Enabled = arg;
            this.fButton.Enabled = arg;
            this.gButton.Enabled = arg;
            this.hButton.Enabled = arg;
            this.iButton.Enabled = arg;
            this.jButton.Enabled = arg;
            this.kButton.Enabled = arg;
            this.lButton.Enabled = arg;
            this.mButton.Enabled = arg;
            this.nButton.Enabled = arg;
            this.oButton.Enabled = arg;
            this.pButton.Enabled = arg;
            this.qButton.Enabled = arg;
            this.rButton.Enabled = arg;
            this.sButton.Enabled = arg;
            this.tButton.Enabled = arg;
            this.uButton.Enabled = arg;
            this.vButton.Enabled = arg;
            this.wButton.Enabled = arg;
            this.xButton.Enabled = arg;
            this.yButton.Enabled = arg;
            this.zButton.Enabled = arg;
        }

        private void SetButtonsVisible(bool arg)
        {
            this.aButton.Visible = arg;
            this.bButton.Visible = arg;
            this.cButton.Visible = arg;
            this.dButton.Visible = arg;
            this.eButton.Visible = arg;
            this.fButton.Visible = arg;
            this.gButton.Visible = arg;
            this.hButton.Visible = arg;
            this.iButton.Visible = arg;
            this.jButton.Visible = arg;
            this.kButton.Visible = arg;
            this.lButton.Visible = arg;
            this.mButton.Visible = arg;
            this.nButton.Visible = arg;
            this.oButton.Visible = arg;
            this.pButton.Visible = arg;
            this.qButton.Visible = arg;
            this.rButton.Visible = arg;
            this.sButton.Visible = arg;
            this.tButton.Visible = arg;
            this.uButton.Visible = arg;
            this.vButton.Visible = arg;
            this.wButton.Visible = arg;
            this.xButton.Visible = arg;
            this.yButton.Visible = arg;
            this.zButton.Visible = arg;
        }
        

        private void bButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("b");
            bButton.Enabled = false;
            UpdateEnv();
        }

        private void cButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("c");
            cButton.Enabled = false;
            UpdateEnv();
        }

        private void dButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("d");
            dButton.Enabled = false;
            UpdateEnv();
        }

        private void eButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("e");
            eButton.Enabled = false;
            UpdateEnv();
        }

        private void fButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("f");
            fButton.Enabled = false;
            UpdateEnv();
        }

        private void gButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("g");
            gButton.Enabled = false;
            UpdateEnv();
        }

        private void hButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("h");
            hButton.Enabled = false;
            UpdateEnv();
        }

        private void iButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("i");
            iButton.Enabled = false;
            UpdateEnv();
        }

        private void jButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("j");
            jButton.Enabled = false;
            UpdateEnv();
        }

        private void kButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("k");
            kButton.Enabled = false;
            UpdateEnv();
        }

        private void lButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("l");
            lButton.Enabled = false;
            UpdateEnv();
        }

        private void mButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("m");
            mButton.Enabled = false;
            UpdateEnv();
        }

        private void nButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("n");
            nButton.Enabled = false;
            UpdateEnv();
        }

        private void oButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("o");
            oButton.Enabled = false;
            UpdateEnv();
        }

        private void pButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("p");
            pButton.Enabled = false;
            UpdateEnv();
        }

        private void qButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("q");
            qButton.Enabled = false;
            UpdateEnv();
        }

        private void rButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("r");
            rButton.Enabled = false;
            UpdateEnv();
        }

        private void sButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("s");
            sButton.Enabled = false;
            UpdateEnv();
        }

        private void tButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("t");
            tButton.Enabled = false;
            UpdateEnv();
        }

        private void uButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("u");
            uButton.Enabled = false;
            UpdateEnv();
        }

        private void vButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("v");
            vButton.Enabled = false;
            UpdateEnv();
        }

        private void wButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("w");
            wButton.Enabled = false;
            UpdateEnv();
        }

        private void xButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("x");
            xButton.Enabled = false;
            UpdateEnv();
        }

        private void yButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("y");
            yButton.Enabled = false;
            UpdateEnv();
        }

        private void zButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("z");
            zButton.Enabled = false;
            UpdateEnv();
        }
        

        private void aButton_Click(object sender, EventArgs e)
        {
            mot.IsLettre("a");
            aButton.Enabled = false;
            UpdateEnv();
        }

        private void rejouerButton_Click(object sender, EventArgs e)
        {
            mot.NewMot();
            SetButtonsEnabled(true);
            SetButtonsVisible(true);
            this.pictureBox.Image = this.StepBmp[0];
            rejouerButton.Visible = false;
            quitterButton.Visible = false;
            UpdateEnv();
        }

        private void quitterButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
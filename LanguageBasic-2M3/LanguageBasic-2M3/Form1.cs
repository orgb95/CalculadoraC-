using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageBasic_2M3
{
    public partial class Form1 : Form
    {
        private bool isOperationAdded;
        private string operation;
        private double result = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text.Equals("0") || isOperationAdded)
            {
                lblResultado.Text = "";
            }
            isOperationAdded = false;
            Button btn = (Button)sender;
            if (btn.Text.Equals(".", StringComparison.CurrentCultureIgnoreCase))
            {
                if (lblResultado.Text.Contains("."))
                {
                    return;
                }
            }
            lblResultado.Text += btn.Text;
        }

        private void BtnMas_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (result == 0)
            {
                result = Double.Parse(lblResultado.Text);
                lblOperaciones.Text = lblResultado.Text + " " + btn.Text;
                operation = btn.Text;
                isOperationAdded = true;
                
            }
            else
            {
                
                operation = btn.Text;
                isOperationAdded = true;
                PerformOperation(operation);
                lblOperaciones.Text = lblResultado.Text + " " + btn.Text;
            }
            
        }

        private void PerformOperation(string operation) {
            
            switch (operation)
            {
                case "+":
                    result += Double.Parse(lblResultado.Text);
                    break;

                case "─":
                    result -= Double.Parse(lblResultado.Text);
                    break;

                case "X":
                    result *= Double.Parse(lblResultado.Text);
                    break;

                case "÷":
                    double temp = Double.Parse(lblResultado.Text);
                    if (result == 0 && temp == 0)
                    {
                        lblResultado.Text = "Undefined";
                    }
                    else if (temp == 0)
                    {
                        lblResultado.Text = "Error";
                    }
                    else
                    {
                        result /= temp;
                    }
                    break;

                default:
                    break;
            }
            lblResultado.Text = result.ToString();
            operation = "";
            
        }
    }
}

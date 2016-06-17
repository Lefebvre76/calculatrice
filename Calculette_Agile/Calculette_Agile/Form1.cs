using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculette_Agile
{
    public partial class Calculator : Form
    {

        enum customOperator
        {
            addition,
            soustraction,
            multiplication,
            division,
            equals
        }

        customOperator selectedOperator = customOperator.addition;
        string operand1 = "0";
        string operand2 = "0";
        string result = "0";
        string lastResultValue = "0";
        bool lastIsOperand = false;
        Calculate calcul = new Calculate();


        public Calculator()
        {
            InitializeComponent();
        }

        private void OnNumericButtonClick(object sender, EventArgs e)
        {
            string myNumber = ((Button)sender).Tag.ToString();
            if (lastIsOperand)
            {
                DisplayTextBox.Text = myNumber;
                if (selectedOperator.Equals(customOperator.equals))
                {
                    result = DisplayTextBox.Text.ToString();
                }
            }
            else
            {
                if (DisplayTextBox.Text.Length < 10)
                {
                    DisplayTextBox.Text += myNumber.ToString();
                }
            }
            lastIsOperand = false;
        }

       
        private void OnOperationButtonClick(object sender, EventArgs e)
        {
            string tagValue = ((Button)sender).Tag.ToString();
            string displayValue = DisplayTextBox.Text;
            DisplayTextBox.Text = "";
            lastIsOperand = true;
            
            switch (selectedOperator)
	        {
                case customOperator.addition:
                    result = calcul.Addition(result, displayValue);
                    break;
                case customOperator.soustraction:
                    result = calcul.Soustraction(result, displayValue);
                    break;
                case customOperator.multiplication:
                    break;
                case customOperator.division:
                    break;
                default:
                    break;
	        }
            DisplayTextBox.Text = result;
            lastOperand(tagValue);
        }

        private void OnEqualButtonClick(object sender, EventArgs e)
        {
            string displayValue = DisplayTextBox.Text;
            DisplayTextBox.Text = "";
            lastIsOperand = true;

            switch (selectedOperator)
            {
                case customOperator.addition:
                    result = calcul.Addition(result, displayValue);
                    break;
                case customOperator.soustraction:
                    result = calcul.Soustraction(result, displayValue);
                    break;
                case customOperator.multiplication:
                    break;
                case customOperator.division:
                    break;
                case customOperator.equals:
                    result = "0";
                    operand1 = "0";
                    break;
                default:
                    break;
            }
            DisplayTextBox.Text = result;
            lastOperand("=");
        }

        public void lastOperand (string tag)
        {
            switch (tag)
            {
                case "+":
                    selectedOperator = customOperator.addition;
                    break;
                case "-":
                    selectedOperator = customOperator.soustraction;
                    break;
                case "=":
                    selectedOperator = customOperator.equals;

                    break;
                default:
                    break;
            }
        }
    }

    
}

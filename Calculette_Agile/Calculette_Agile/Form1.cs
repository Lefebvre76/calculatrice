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
                    // Clear all left zeros
                DisplayTextBox.Text = DisplayTextBox.Text.TrimStart('0');
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
            SignTextBox.Text = tagValue;
            if (displayValue == "0" || displayValue == "")
            {
                DisplayTextBox.Text += "-";
                lastIsOperand = false;
            }
            else
            {
                switch (selectedOperator)
                {
                    case customOperator.addition:
                        result = calcul.Addition(result, displayValue);
                        break;
                    case customOperator.soustraction:
                        result = calcul.Soustraction(result, displayValue);
                        break;
                    case customOperator.multiplication:
                        result = calcul.Multiplication(result, displayValue);
                        break;
                    case customOperator.division:
                        result = calcul.Division(result, displayValue);
                        break;
                    default:
                        break;
                }
                DisplayTextBox.Text = result;
                lastOperand(tagValue);
            }
        }

        private void OnEqualButtonClick(object sender, EventArgs e)
        {
            string displayValue = DisplayTextBox.Text;
            DisplayTextBox.Text = "";
            lastIsOperand = true;
            SignTextBox.Text = "=";
            switch (selectedOperator)
            {
                case customOperator.addition:
                    result = calcul.Addition(result, displayValue);
                    break;
                case customOperator.soustraction:
                    result = calcul.Soustraction(result, displayValue);
                    break;
                case customOperator.multiplication:
                    result = calcul.Multiplication(result, displayValue);
                    break;
                case customOperator.division:
                    result = calcul.Division(result, displayValue);
                    break;
                case customOperator.equals:
                    // result = "0";
                    // operand1 = "0";
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
                case "x":
                    selectedOperator = customOperator.multiplication;
                    break;
                case "/":
                    selectedOperator = customOperator.division;
                    break;
                default:
                    break;
            }
        }

        private void OnClearButtonClick(object sender, EventArgs e)
        {
            string tagValue = ((Button)sender).Tag.ToString();
            switch (tagValue)
            {
                case "CA":
                    result = calcul.ClearAll();
                    DisplayTextBox.Text = result;
                    SignTextBox.Text = "";
                    break;

                case "Back":
                    if (!lastIsOperand)
                    {
                        DisplayTextBox.Text = calcul.ClearLastDigit(DisplayTextBox.Text);
                    }
                    break;

                case "CE":
                    DisplayTextBox.Text = "0";
                    break;

                default:
                    break;
            }
        }

    }
    
}

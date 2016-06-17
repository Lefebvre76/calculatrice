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
        string operand1;
        string operand2;
        string result;
        Calculate calcul = new Calculate();


        public Calculator()
        {
            InitializeComponent();
        }

        private void OnNumericButtonClick(object sender, EventArgs e)
        {
            string myNumber = ((Button)sender).Tag.ToString();
 
            if (DisplayTextBox.Text.Length < 10)
            {
                // Clear all left zeros
                DisplayTextBox.Text = DisplayTextBox.Text.TrimStart('0');
                DisplayTextBox.Text += myNumber.ToString();
            }
           
        }

       
        private void OnOperationButtonClick(object sender, EventArgs e)
        {
            string tagValue = ((Button)sender).Tag.ToString();
            string displayValue = DisplayTextBox.Text;
            DisplayTextBox.Text = "";
            switch (tagValue)
            {
                case "+": 
                    operand1 = displayValue;
                    // DisplayTextBox.Text = operand1.ToString();
                    selectedOperator = customOperator.addition;
                    SignTextBox.Text = "+";
                    break;
                
                case "=":
                    if (selectedOperator == customOperator.addition)
                    {
                        result = calcul.Addition(operand1, displayValue);
                        selectedOperator = customOperator.equals;
                        SignTextBox.Text = "=";
                    }
                    
                    DisplayTextBox.Text = result;
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
                    DisplayTextBox.Text = calcul.ClearLastDigit(DisplayTextBox.Text);
                    break;

                default:
                    break;
            }
        }


    }
}

﻿using System;
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
            var myNumber = ((Button)sender).Tag;
            if (DisplayTextBox.Text.Length < 10)
            {
                DisplayTextBox.Text += myNumber.ToString();
            }
           
        }

        // TODO : déplacer le code métier dans la classe Calculator
        private void OnOperationButtonClick(object sender, EventArgs e)
        {
            string tagValue = ((Button)sender).Tag.ToString();
            string displayValue = DisplayTextBox.Text;
            DisplayTextBox.Text = "";
            switch (tagValue)
            {
                case "+":


                    // TODO : replace code and integrate new Calculate class
                    operand1 = displayValue;

                    // DisplayTextBox.Text = operand1.ToString();
                    selectedOperator = customOperator.addition;
                    break;
                case "=":
                    if (selectedOperator == customOperator.addition)
                    {
                        result = calcul.Addition(operand1, displayValue);
                        selectedOperator = customOperator.equals;
                    }
                    
                    DisplayTextBox.Text = result;
                    
                    break;
                default:
                    break;
            }

            //
            
        }


    }
}

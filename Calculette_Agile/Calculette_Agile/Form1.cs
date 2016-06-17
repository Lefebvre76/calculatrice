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
    /// <summary>
    /// Calculette_Agile
    /// Authors: Elise + Loic + Igor
    /// Creation date: 2016/06/16
    /// Last modified: 2016/06/17
    /// -------------------------
    /// Default form: interacts with user's actions
    /// </summary>
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



        /// <summary>
        /// Constructor
        /// </summary>
        public Calculator()
        {
            InitializeComponent();
            setOperatorsEnabled(false);
            EqualButton.Enabled = false;
        }

        /// <summary>
        /// OnNumericButtonClick
        /// ----------------------------
        /// Reacts to numeric buttons push events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNumericButtonClick(object sender, EventArgs e)
        {
            setOperatorsEnabled(true);
            EqualButton.Enabled = true;
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

       /// <summary>
       /// OnOperationButtonClick
       /// ----------------------------
       /// Reacts to operation buttons push events
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void OnOperationButtonClick(object sender, EventArgs e)
        {
            setOperatorsEnabled(false);

            EqualButton.Enabled = false;
            string tagValue = ((Button)sender).Tag.ToString();
            string displayValue = DisplayTextBox.Text;
            DisplayTextBox.Text = "";
            lastIsOperand = true;
            SignTextBox.Text = tagValue;

            if (result.Equals("Err /0"))
            {
                result = displayValue;
                selectedOperator = customOperator.equals;
                DisplayTextBox.Text = displayValue;
                lastOperator(tagValue);
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
                lastOperator(tagValue);
                if (result.Equals("Err /0"))
                {
                    setOperatorsEnabled(false);
                }
            }
        }

        /// <summary>
        /// OnEqualButtonClick
        /// ----------------------------
        /// Reacts to = button push event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEqualButtonClick(object sender, EventArgs e)
        {
            string displayValue = DisplayTextBox.Text;
            DisplayTextBox.Text = "";
            lastIsOperand = true;
            SignTextBox.Text = "=";
            if (result.Equals("Err /0"))
            {
                result = displayValue;
                selectedOperator = customOperator.equals;
                lastOperator("=");
                DisplayTextBox.Text = displayValue;
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
                    case customOperator.equals:
                        // result = "0";
                        // operand1 = "0";
                        break;

                    default:
                        break;
                }
            
                DisplayTextBox.Text = result;
                lastOperator("=");
                EqualButton.Enabled = false;
                if (result.Equals("Err /0"))
                {
                    setOperatorsEnabled(false);
                }
            }
        }

        /// <summary>
        /// lastOperator
        /// ----------------------------
        /// Defines last operator entered by user
        /// </summary>
        /// <param name="tag"></param>
        public void lastOperator (string tag)
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

        /// <summary>
        /// OnClearButtonClick
        /// ----------------------------
        /// Reacts to clear and back buttons push events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClearButtonClick(object sender, EventArgs e)
        {
            string tagValue = ((Button)sender).Tag.ToString();
            switch (tagValue)
            {
                case "CA":
                    selectedOperator = customOperator.addition;
                    result = calcul.ClearAll();
                    DisplayTextBox.Text = result;
                    SignTextBox.Text = "";
                    setOperatorsEnabled(true);
                    break;

                case "Back":
                    if (!lastIsOperand)
                    {
                        DisplayTextBox.Text = calcul.ClearLastDigit(DisplayTextBox.Text);
                    }
                    break;

                case "CE":
                    DisplayTextBox.Text = "0";
                    setOperatorsEnabled(false);
                    EqualButton.Enabled = false;
                    setOperatorsEnabled(true);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// OnChangeSignButtonClick
        /// ----------------------------
        /// Reacts to +/- button push event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChangeSignButtonClick(object sender, EventArgs e)
        {
            if (lastIsOperand)
            {
                DisplayTextBox.Text = "-";
            }
            else
            {
                string displayValue = DisplayTextBox.Text;

                if (displayValue.Contains('-'))
                {
                    DisplayTextBox.Text = displayValue.Replace("-", string.Empty);
                }
                else
                {
                    DisplayTextBox.Text = "-" + displayValue;
                }
            }
            lastIsOperand = false;
            
        }

        /// <summary>
        /// setOperatorsEnabled
        /// ----------------------------
        /// Enables/disables operators buttons
        /// </summary>
        /// <param name="isEnabled"></param>
        private void setOperatorsEnabled(bool isEnabled)
        {
            DivideButton.Enabled = isEnabled;
            TimesButton.Enabled = isEnabled;
            PlusButton.Enabled = isEnabled;
            MinusButton.Enabled = isEnabled;
        }

    }
    
}

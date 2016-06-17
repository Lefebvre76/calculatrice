﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculette_Agile
{
    /// <summary>
    /// Calculate
    /// Authors: Elise + Loic + Igor
    /// Creation date: 2016/06/16
    /// Last modified: 2016/06/17
    /// -------------------------
    /// Offers basic calculation methods
    /// </summary>
    public class Calculate
    {
        string result = "";

        public Calculate()
        {

        }

        public string Addition(string ope1, string ope2)
        {
            float operande1 = float.Parse(ope1.Replace('.', ','));
            float operande2 = float.Parse(ope2.Replace('.', ','));
            result = (operande1 + operande2).ToString().Replace('.', ',');
            return result;
        }


        public string Soustraction(string ope1, string ope2)
        {
            result = (float.Parse(ope1.Replace('.', ',')) - (float.Parse(ope2.Replace('.', ',')))).ToString().Replace('.', ',');
            return result;
        }


        public string Multiplication(string ope1, string ope2)
        {
            result = (float.Parse(ope1.Replace('.', ',')) * (float.Parse(ope2.Replace('.', ',')))).ToString().Replace('.', ',');
            return result;
        }


        public string Division(string ope1, string ope2)
        {
            float ope2Float = float.Parse(ope2);
            if (ope2Float == 0)
            {
                result = "Err /0";
            }
            else
            {
                result = (float.Parse(ope1.Replace('.', ',')) / (float.Parse(ope2.Replace('.', ',')))).ToString().Replace('.', ',');
            }
            return result;
        }


        public string ClearAll()
        {
            result = "0";
            return result;
        }

        public string ClearLastDigit(string displayDigits)
        {
            if (displayDigits.Length > 1)
            {
                displayDigits = displayDigits.Substring(0, displayDigits.Length - 1);
            }
            else
            {
                displayDigits = "0";
            }
            
            return displayDigits;
        }
    }
}

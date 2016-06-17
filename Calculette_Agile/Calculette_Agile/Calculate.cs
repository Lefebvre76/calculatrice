using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculette_Agile
{
    public class Calculate
    {
        string result = "";

        public Calculate()
        {

        }

        public string Addition(string ope1, string ope2)
        {
            result = (float.Parse(ope1) + (float.Parse(ope2))).ToString().Replace('.',',');
            return result;
        }

        public string Soustraction(string ope1, string ope2)
        {
            result = (float.Parse(ope1) - (float.Parse(ope2))).ToString().Replace('.', ',');
            return result;
        }
    }
}

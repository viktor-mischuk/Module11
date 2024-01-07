using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityBoy.Utilities
{
    public static class TextConverter
    {
        public static string CountSymbolSum(string txt)
        {
            string[] strings = txt.Split(' ');
            int sum = 0;
            foreach (string str in strings)
            {
                
                bool result = int.TryParse(str, out var number);
                if (result == true) sum += number;

                else sum = -1000;
            }
            if (sum == -1000) return "не подсчитана. Введены не цифры";
            return sum.ToString();
        }
    }
}

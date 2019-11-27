using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DibawinWebsite.ClassLibraries.GenerateCode
{
    public static class GenerateCode
    {
        public static string NumericCode()
        {
            Random rnd = new Random();
            int r = rnd.Next(1, 99999999);
            string finalResult = r.ToString();
            if (finalResult.Length < 8)
            {
                for (int i = 0; i < (8 - finalResult.Length); i++)
                {
                    finalResult = "0" + finalResult;
                }
            }
            return finalResult;
        }
        public static string SystemCode(string prefix = "",int type = 1)
        {
            string numCode;
            if (type == 1)
            {
                numCode = DateCode();
            }
            else
            {
                numCode = NumericCode();
            }
            string finalResult = "";
            switch (prefix.ToLower())
            {
                case "client":
                    finalResult = "DWC-" + numCode;
                    break;
                case "customer":
                    finalResult = "DWC-" + numCode;
                    break;
                case "product":
                    finalResult = "DWP-" + numCode;
                    break;
                case "project":
                    finalResult = "DWPJ-" + numCode;
                    break;
                default:
                    finalResult = "DW-" + numCode;
                    break;
            }
                
            return finalResult;
        }
        public static string DateCode()
        {
            var p = CustomizeCalendar.GToPDateTime(DateTime.Now);
            Random rnd = new Random();
            int r = rnd.Next(1, 999);
            string combinedText = $"{p.Ticks.ToString().Substring(0,11)}{r}";
            //string combinedText = $"{p.Year.ToString().Substring(2,2)}{p.Month}{p.DayOfYear}{p.Hour}{p.Minute}{p.Second}";
            if (combinedText.Length < 14)
            {
                for (int i = 0; i < 14 - combinedText.Length; i++)
                {
                    combinedText = combinedText + "0";
                }
            }
            return combinedText;
        }
    }
}

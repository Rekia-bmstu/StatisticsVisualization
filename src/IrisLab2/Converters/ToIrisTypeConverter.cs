using IrisLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisLab2.Converters
{
    public static class ToIrisTypeConverter
    {
        public static IrisType Convert(string irisType)
        {
            IrisType result = IrisType.None;
            switch (irisType)
            {
                case "setosa":
                    result = IrisType.Setosa;
                    break;
                case "virginica":
                    result = IrisType.Virginica;
                    break;
                case "versicolor":
                    result = IrisType.Versicolor;
                    break;
                default:
                    result = IrisType.None;
                    break;
            }

            return result;
        }

        public static string ConvertBack(IrisType irisType)
        {
            string result = "";
            switch (irisType)
            {
                case IrisType.Setosa:
                    result = "setosa";
                    break;
                case IrisType.Versicolor:
                    result = "versicolor";
                    break;
                case IrisType.Virginica:
                    result = "virginica";
                    break;
                case IrisType.None:
                    result = "None";
                    break;
            }
            return result;
        }
    }
}

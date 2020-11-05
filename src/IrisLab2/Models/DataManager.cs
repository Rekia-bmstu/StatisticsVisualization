using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorCollection;
using IrisLab2.Converters;
using System.Globalization;

namespace IrisLab2.Models
{
    public static class DataManager
    {
        /// <summary>
        /// Returns headers from raw data
        /// </summary>
        public static List<string> GetHeaders(List<string> data)
        {
            return data[0].Split(',').ToList();
        }

        /// <summary>
        /// Returns graphics values from raw data
        /// </summary>
        public static List<MathVector> GetGraphicsValues(List<string> data)
        {
            var dataArray = GetAverageData(GetData(data, has_headers: true));
            var result = GetListOfBarsValues(dataArray);
            result.Add(GetPieValues(dataArray));

            return result;
        }

        /// <summary>
        /// Return iris names from raw data
        /// </summary>
        public static List<string> GetIrisNames(List<string> data)
        {
            HashSet<string> irisNames = new HashSet<string>();
            int last = -1;
            for (int i = 1; i < data.Count; i++)
            {
                var temp = data[i].Split(',').ToList();
                if (last == -1)
                {
                    last = temp.Count - 1;
                }

                irisNames.Add(temp[last]);
            }

            return irisNames.ToList();
        }

        private static Dictionary<IrisType, List<MathVector>> GetData(List<string> data, bool has_headers = false)
        {
            var result = new Dictionary<IrisType, List<MathVector>>(3);

            for (int i = has_headers ? 1 : 0; i < data.Count; i++)
            {
                var temp = data[i].Split(',').ToList();
                var last = temp.Count - 1;
                IrisType currentIrisType = ToIrisTypeConverter.Convert(temp[last]);

                if (!result.ContainsKey(currentIrisType))
                {
                    result.Add(currentIrisType, new List<MathVector>()); //Adding new iris type to collection
                }

                AddListOfValues(result[currentIrisType], temp); //Adding new vector to concrete iris type
            }

            return result;
        }

        private static void AddListOfValues(List<MathVector> list, List<string> values)
        {
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo() { NumberDecimalSeparator = "." };
            values.Remove(values.Last());
            list.Add(new MathVector(values.Select(o => Convert.ToDouble(o, numberFormatInfo)).ToList()));
        }

        private static List<MathVector> GetAverageData(Dictionary<IrisType, List<MathVector>> data)
        {
            var result = new List<MathVector>();

            foreach (var key in data.Keys)
            {
                result.Add(GetAverageVector(data[key]));
            }

            return result;
        }

        private static MathVector GetAverageVector(List<MathVector> list)
        {
            var result = new MathVector();

            for (int i = 0; i < list[0].Dimensions; i++)
            {
                double sum = 0.0;
                int count = 0;

                for (int j = 0; j < list.Count; j++)
                {
                    sum += list[j][i];
                    count++;
                }

                result.Add(sum / count);
            }

            return result;
        }

        private static List<MathVector> GetListOfBarsValues(List<MathVector> dataArray)
        {
            var result = new List<MathVector>();

            for (int i = 0; i < dataArray[0].Dimensions; i++)
            {
                result.Add(new MathVector());
                for (int j = 0; j < dataArray.Count; j++)
                {
                    result[i].Add(dataArray[j][i]);
                }
            }

            return result;
        }

        private static MathVector GetPieValues(List<MathVector> data)
        {
            return new MathVector(data[0].GetDistance(data[1]),
                                  data[0].GetDistance(data[2]),
                                  data[1].GetDistance(data[2]));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisLab2.Models
{
    public static class DataManger
    {
        public static List<string> GetHeaders(List<string> data)
        {
            return data[0].Split(',').ToList();
        }
        
    }
}

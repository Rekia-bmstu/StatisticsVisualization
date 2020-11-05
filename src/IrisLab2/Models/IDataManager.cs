using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorCollection;

namespace IrisLab2.Models
{
    public interface IDataManager
    {
        List<string> GetHeaders(List<string> data);
        List<MathVector> GetGraphicsValues(List<string> data);
        List<string> GetIrisNames(List<string> data);
    }
}

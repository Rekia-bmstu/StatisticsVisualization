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
        IEnumerable<string> GetHeaders(List<string> data);
        IEnumerable<MathVector> GetGraphicsValues(List<string> data);
        IEnumerable<string> GetIrisNames(List<string> data);
    }
}

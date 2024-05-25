using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcucator.Model
{
    public class MainPageModel
    {
        public MainPageModel()
        {
            
        }
        public double Solve(string expression)
        {
            
            double result = 0.0;
            result = Convert.ToDouble(new DataTable().Compute(expression, null));
            return result;
        }
    }
}

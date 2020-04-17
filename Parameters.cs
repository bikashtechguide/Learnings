using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    public class Parameters
    {
        public void ReferenceParameter(ref int input)
        {
            input = 10;
        }

        public void NormalParameter(Employee input)
        {
            input.EmployeeId = 10;
        }
    }
}

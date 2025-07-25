using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Models
{
    public class TestCaseDataModel
    {
        public string CaseId { get; set; }
        public string Method { get; set; }
        public int[] Input { get; set; }
        public double Expected { get; set; }
    }
}

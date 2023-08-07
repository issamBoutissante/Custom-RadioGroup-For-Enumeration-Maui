using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_RadioGroup_For_Enumeration.Enums
{
    internal enum SmokerStateEnum
    {
        [Description("Ex Smoker")]
        ExSmoker,
        NonSmoker,
        Smoker
    }
}

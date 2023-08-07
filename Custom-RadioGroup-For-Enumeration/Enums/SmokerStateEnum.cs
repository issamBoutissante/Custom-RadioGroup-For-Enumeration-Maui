using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Custom_RadioGroup_For_Enumeration.Enums
{
    public enum SmokerStateEnum
    {
        [EnumMember(Value = "Ex Smoker")]
        ExSmoker,
        [EnumMember(Value = "Non Smoker")]
        NonSmoker,
        [EnumMember(Value = "Smoker")]
        Smoker
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Custom_RadioGroup_For_Enumeration.Enums
{
    internal enum MedicationType
    {
        [EnumMember(Value = "Heart Disease")]
        HeartDisease,
        [EnumMember(Value = "Heart Disease")]
        HeartDisease1,
        [EnumMember(Value = "Heart Disease")]
        HeartDisease2,
        [EnumMember(Value = "Heart Disease")]
        HeartDisease3,
        [EnumMember(Value = "Heart Disease")]
        HeartDisease4,

    }
}

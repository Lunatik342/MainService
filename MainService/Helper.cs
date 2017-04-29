using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MainService
{
    public static class Helper
    {
        public static CheckStatus CheckParam(string value, int length,bool isNullAllowed)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                if (isNullAllowed)
                {
                    return CheckStatus.Success;
                }
                else
                {
                    return CheckStatus.ArgumentIsNull;
                }
            }
            if(value.Length <= length)
                return CheckStatus.Success;
            return CheckStatus.LenghtIsIncorrect;
        }

        
    }

    [DataContract]
    public enum CheckStatus
    {
        [EnumMember]
        Success,
        [EnumMember]
        ArgumentIsNull,
        [EnumMember]
        LenghtIsIncorrect,
        [EnumMember]
        IdDoesNotExist,
        [EnumMember]
        ArgumentDoesNotMatchFormat,
        [EnumMember]
        ArgumentIsNotUnique,
        [EnumMember]
        IncorrectParametr
    }
}

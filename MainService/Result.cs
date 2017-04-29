using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MainService
{

    [DataContract]
    public class DbRequestResult<T> : ResultBase
    {
        [DataMember]
        public T CreatedObject { get; set; }
    }
    

    [DataContract]
    public class CrResult<T> : Result
    {
        [DataMember]
        public T CreatedObject { get; set; }
    }


    [DataContract]
    public class Result :ResultBase
    {
        [DataMember]
        public List<Error> Errors { get;set; } = new List<Error>();
        
        public void AddError(Error error)
        {
            if (ActionResult != ActionResult.Success && ActionResult != ActionResult.IncorrectParameter)
                throw new InvalidOperationException("Action result is already set");
            ActionResult = ActionResult.IncorrectParameter;
            Errors.Add(error);
        }

    }

    [DataContract]
    public class ResultBase
    {
        [DataMember]
        public ActionResult ActionResult { get; set; } = ActionResult.Success;
    }


    [DataContract]
    public class Error
    {
        [DataMember]
        public CheckStatus CheckStatus { get; private set; }
        [DataMember]
        public string Variable { get; private set; }

        public Error(CheckStatus checkStatus, string variable = null)
        {
            CheckStatus = checkStatus;
            Variable = variable;
        }
    }


    [DataContract]
    public enum ActionResult
    {
        [EnumMember]
        Success,
        [EnumMember]
        PermissionDenied,
        [EnumMember]
        DatabaseError,
        [EnumMember]
        IncorrectParameter,
    }
}


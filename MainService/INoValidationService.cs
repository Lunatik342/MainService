using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MainService
{
    [ServiceContract]
    public interface INoValidationService
    {
        [OperationContract]
        CrResult<UserDto> Register(UserCrDto user);

        [OperationContract]
        List<CityDto> GetCities();

        [OperationContract]
        List<UniversityDto> GetUnivercities(string value);

        [OperationContract]
        List<ImportanceDto> GetImportanceScale();

        [OperationContract]
        List<RolePermitions> GetRolePermitions();
    }

}

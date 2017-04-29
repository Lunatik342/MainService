using System.Collections.Generic;
using System.Text.RegularExpressions;
using MainService.DtoManagers;

namespace MainService
{
    
    public class NoValidationService : INoValidationService
    {

        public CrResult<UserDto> Register(UserCrDto userCrDto)
        {
            return new UsersManager().Create(userCrDto);
        }

        public List<CityDto> GetCities()
        {
            return new DataBaseInformationManager().ReturnCities();
        }

        public List<UniversityDto> GetUnivercities(string value)
        {
            return new DataBaseInformationManager().ReturnUnivercities(value);
        }
        
        public List<RolePermitions> GetRolePermitions()
        {
            return new DataBaseInformationManager().ReturnRolePermitions();
        }

        public List<ImportanceDto> GetImportanceScale()
        {
            return new DataBaseInformationManager().ReturnImportanceScale();
        }
    }
}

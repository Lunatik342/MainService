using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainService.DtoManagers
{
    class DataBaseInformationManager
    {

        private readonly SchedulerContext _context = new SchedulerContext();

        public List<CityDto> ReturnCities()
        {
            return _context.City.Select(Converter.ConvertToCityDto).ToList();

        }

        public List<UniversityDto> ReturnUnivercities(string str)
        {
            return _context.University.Where(u=>u.short_name.StartsWith(str)).Select(Converter.ConvertToUniversityDto).ToList();
        }

        public List<ImportanceDto> ReturnImportanceScale()
        {

            return _context.Importance.Select(Converter.ConvertToImportanceDto).ToList();
        }

        public List<RolePermitions> ReturnRolePermitions()
        {
            return _context.Role.Select(Converter.ConvertToRoleDto).ToList();
        }

        public bool IsCityExist(long id)
        {
            return _context.City.Find(id) != null;
        }

        public bool IsUnivercityExist(long id)
        {
            return _context.University.Find(id) != null;
        }
    }
}

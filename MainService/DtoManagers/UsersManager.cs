using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text.RegularExpressions;

namespace MainService.DtoManagers
{
    public class UsersManager
    {
        private readonly SchedulerContext _context = new SchedulerContext();

        private readonly int _nicknameLength = 15;
        private readonly int _maxPasswordLength = 15;
        private readonly int _minPasswordLength = 0;
        private readonly int _nameLength = 70;
        private readonly int _surnameLength = 70;
        private readonly int _emailLength = 254;
        private readonly int _phoneLength = 15;
        private readonly int _groupLength = 20;
        private readonly int _descriptionLength = 70;

        public User GetUserByNickname(string nickname)
        {
            return _context.User.FirstOrDefault(u => u.nickname == nickname);
        }

        public CrResult<UserDto> Create(UserCrDto userCrDto)
        {
            var crResult = new CrResult<UserDto>();
            CheckRegisterData(userCrDto, crResult, true, true);
            if (crResult.ActionResult == ActionResult.Success)
            {
                var user = Converter.ConvertToUser(userCrDto);
                var encryption = new HashEncryption();
                encryption.HashPassword(user);
                try
                {
                    var createdUser = _context.User.Add(user);
                    _context.SaveChanges();
                    crResult.CreatedObject = Converter.ConvertToUserDto(createdUser);
                }
                catch (DbUpdateException)
                {
                    crResult.ActionResult = ActionResult.DatabaseError;
                }
            }
            return crResult;
        }

        public CrResult<UserDto> Edit(UserCrDto userCrDto, User user)
        {
            var crResult = new CrResult<UserDto>();
            if (user != null)
            {
                bool nicknameChanged = userCrDto.Nickname != user.nickname;
                bool passwordChanged = String.IsNullOrEmpty(userCrDto.Password) && !new CustomUserNameValidator().IsPasswordMatch(userCrDto.Password, user);
                CheckRegisterData(userCrDto, crResult, nicknameChanged, passwordChanged);
                if (crResult.ActionResult == ActionResult.Success)
                {
                    Copy(userCrDto, user, nicknameChanged, passwordChanged);
                    try
                    {
                        _context.SaveChanges();
                        crResult.CreatedObject = Converter.ConvertToUserDto(user);
                    }
                    catch (DbUpdateException)
                    {
                        crResult.ActionResult = ActionResult.DatabaseError;
                    }
                }
            }
            else
            {
                crResult.AddError(new Error(CheckStatus.IdDoesNotExist, nameof(user.user_id)));
            }
            return crResult;
        }

        private void CheckRegisterData(UserCrDto userCrDto, Result r, bool checkNickname, bool checkPawssword)
        {
            if (checkNickname)
                CheckNickname(userCrDto, r);
            if (checkPawssword)
                CheckPassword(userCrDto, r);
            CheckEmail(userCrDto, r);
            CheckPhone(userCrDto, r);
            CheckStringData(userCrDto, r);
        }

        private void CheckNickname(UserBaseDto userCrDto, Result r)
        {

            if (userCrDto.Nickname == null)
            {
                r.AddError(new Error(CheckStatus.ArgumentIsNull, nameof(userCrDto.Nickname)));
                return;
            }
            if (GetUserByNickname(userCrDto.Nickname) != null)
            {
                r.AddError(new Error(CheckStatus.ArgumentIsNotUnique, nameof(userCrDto.Nickname)));
                return;
            }
            var checkStatus = Helper.CheckParam(userCrDto.Nickname, _nicknameLength, false);
            if (checkStatus != CheckStatus.Success)
            {
                r.AddError(new Error(checkStatus, nameof(userCrDto.Nickname)));
                return;
            }
            var myRegex = new Regex("^[a-zA-Z][a-zA-Z0-9]");
            if (!myRegex.IsMatch(userCrDto.Nickname))
                r.AddError(new Error(CheckStatus.ArgumentDoesNotMatchFormat, nameof(userCrDto.Nickname)));
        }

        private void CheckPassword(UserCrDto userCrDto, Result r)
        {
            var checkStatus = Helper.CheckParam(userCrDto.Password, _maxPasswordLength, false);
            if (checkStatus != CheckStatus.Success)
            {
                r.AddError(new Error(checkStatus, nameof(userCrDto.Password)));
                return;
            }
            if (!ValidatePassword(userCrDto.Password))
            {
                r.AddError(new Error(CheckStatus.ArgumentDoesNotMatchFormat, nameof(userCrDto.Password)));
            }
        }

        private bool ValidatePassword(string password)
        {
            if (password == null)
                throw new ArgumentNullException();

            var meetsLengthRequirements = password.Length >= _minPasswordLength && password.Length <= _maxPasswordLength;

            var hasUpperCaseLetter = false;
            var hasLowerCaseLetter = false;
            var hasDecimalDigit = false;
            var hasSpaceSymbol = false;

            if (meetsLengthRequirements)
            {
                foreach (var c in password)
                {
                    if (char.IsUpper(c))
                        hasUpperCaseLetter = true;
                    else if (char.IsLower(c))
                        hasLowerCaseLetter = true;
                    else if (char.IsDigit(c))
                        hasDecimalDigit = true;
                    else if (char.IsSeparator(c))
                        hasSpaceSymbol = true;
                }
            }

            bool isValid = meetsLengthRequirements
                        && hasUpperCaseLetter
                        && hasLowerCaseLetter
                        && hasDecimalDigit
                        && !hasSpaceSymbol;
            return isValid;
        }

        private void CheckEmail(UserBaseDto userCrDto, Result r)
        {
            var paramName = nameof(userCrDto.Email);
            var checkStatus = Helper.CheckParam(userCrDto.Email, _emailLength, true);
            if (checkStatus != CheckStatus.Success)
            {
                r.AddError(new Error(checkStatus, paramName));
            }
            if (string.IsNullOrEmpty(userCrDto.Email)) return;
            var match = Regex.IsMatch(userCrDto.Email,
                @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            if (!match)
            {
                r.AddError(new Error(CheckStatus.ArgumentDoesNotMatchFormat, paramName));
            }

        }

        private void CheckPhone(UserCrDto userCrDto, Result r)
        {
            var paramName = nameof(userCrDto.Phone);
            var checkStatus = Helper.CheckParam(userCrDto.Phone, _phoneLength, true);
            if (checkStatus != CheckStatus.Success)
            {
                r.AddError(new Error(checkStatus, paramName));
            }
            else
            {
                if (string.IsNullOrEmpty(userCrDto.Phone)) return;
                var match = Regex.IsMatch(userCrDto.Phone, @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
                if (!match)
                {
                    r.AddError(new Error(CheckStatus.ArgumentDoesNotMatchFormat, paramName));
                }
            }
        }

        private void CheckStringData(UserCrDto userCrDto, Result r)
        {
            var checkStatus = Helper.CheckParam(userCrDto.Description, _descriptionLength, true);
            if (checkStatus != CheckStatus.Success)
            {
                r.AddError(new Error(checkStatus, nameof(userCrDto.Description)));
            }

            checkStatus = Helper.CheckParam(userCrDto.Group, _groupLength, true);
            if (checkStatus != CheckStatus.Success)
            {
                r.AddError(new Error(checkStatus, nameof(userCrDto.Group)));
            }

            checkStatus = Helper.CheckParam(userCrDto.Name, _nameLength, true);
            if (checkStatus != CheckStatus.Success)
            {
                r.AddError(new Error(checkStatus, nameof(userCrDto.Name)));
            }

            checkStatus = Helper.CheckParam(userCrDto.Surname, _surnameLength, true);
            if (checkStatus != CheckStatus.Success)
            {
                r.AddError(new Error(checkStatus, nameof(userCrDto.Surname)));
            }

            if (userCrDto.CityId != null 
                && !new DataBaseInformationManager().IsCityExist((long)userCrDto.CityId))
                r.AddError(new Error(CheckStatus.IdDoesNotExist, nameof(userCrDto.CityId)));
            if (userCrDto.UniversityId != null 
                && !new DataBaseInformationManager().IsUnivercityExist((long)userCrDto.UniversityId))
                r.AddError(new Error(CheckStatus.IdDoesNotExist, nameof(userCrDto.UniversityId)));
        }

        private void Copy(UserCrDto userCrDto, User user, bool copyNickname, bool copyPassword)
        {
            user.city_id = userCrDto.CityId;
            user.university_id = userCrDto.UniversityId;
            user.description = userCrDto.Description;
            user.email = userCrDto.Email;
            user.group = userCrDto.Group;
            user.name = userCrDto.Name;
            user.phone = userCrDto.Phone;
            user.surname = userCrDto.Surname;
            if (copyNickname)
                user.nickname = userCrDto.Nickname;
            if (copyPassword)
            {
                var encryption = new HashEncryption();
                encryption.HashPassword(user);
            }
        }
    }
}
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace MainService.DtoManagers
{
    public class ChannelManager
    {
        private readonly SchedulerContext _context = new SchedulerContext();

        private readonly int _nameLength = 20;
        private readonly int _descriptionLength = 70;

        private readonly bool _nameNullAllowed = false;
        private readonly bool _descriptionNullAllowed = true;

        private readonly int _adminId = 0;

        private readonly int _watchMemberPermitionId = 10;
        private readonly int _deleteChannelPermitionId = 1;

        public CrResult<ChannelRoleDto> CreateChannel(ChannelCrDto channelDto, long userId)
        {
            var result = new CrResult<ChannelRoleDto>();
            CheckData(result,channelDto);
            if (result.ActionResult == ActionResult.Success)
            {
                try
                {
                    var c = _context.Channel.Add(Converter.ConvertToChannel(channelDto));
                    var userRole = UserRolesManager.AddUserRole(c.channel_id, userId, _adminId,_context);
                    _context.SaveChanges();
                    userRole.Role = new Role
                    {
                        role_id = 0,
                        role_name = "Admin"
                    };
                    result.CreatedObject = Converter.ConvertToChannelRoleDto(userRole);
                }
                catch (DbUpdateException)
                {
                    result.ActionResult = ActionResult.DatabaseError;
                }
            }
            return result;
        }

        public DbRequestResult<List<ChannelRoleDto>> GetChannels(long userId)
        {
            var res = new DbRequestResult<List<ChannelRoleDto>>();
            var userRoles = _context.UserRole.Where(userRole => userRole.user_id == userId);
            res.CreatedObject = userRoles.Select(Converter.ConvertToChannelRoleDto).ToList();
            return res;
        }


        public DbRequestResult<List<UserDto>> GetChannelsUsers(long userId, long channelId)
        {
            var res = new DbRequestResult<List<UserDto>>();
            var isActionAllowed = new UserRolesManager().CheckPermition(userId, channelId, _watchMemberPermitionId);
            if (isActionAllowed)
            {
                var channelRoles = _context.UserRole.Where(uRole => uRole.channel_id == channelId).
                    Select(c=> Converter.ConvertToUserDto(c.User)).ToList();
                res.CreatedObject = channelRoles;
            }
            else
            {
                res.ActionResult = ActionResult.PermissionDenied;
            }
            return res;
        }

        public ResultBase DeleteChannel(long channelId, long userId)
        {
            var res = new ResultBase();
            if (new UserRolesManager().CheckPermition(userId, channelId, _deleteChannelPermitionId))
            {
                try
                {
                    var channel = _context.Channel.Find(channelId);
                    if (channel != null)
                    {
                        _context.Channel.Remove(channel);
                        _context.SaveChanges();
                    }
                    else
                    {
                        res.ActionResult = ActionResult.DatabaseError;
                    }
                }
                catch (DbUpdateException)
                {
                    res.ActionResult = ActionResult.DatabaseError;
                }
            }
            else
            {
                res.ActionResult = ActionResult.PermissionDenied;
            }
            return res;
        }

        private void CheckData(Result r,ChannelCrDto channelCrDto)
        {
            if (channelCrDto == null)
            {
                r.AddError(new Error(CheckStatus.ArgumentIsNull, nameof(channelCrDto)));
                return;
            }
            var checkStatus = Helper.CheckParam(channelCrDto.Description, _descriptionLength, _descriptionNullAllowed);
            if (checkStatus != CheckStatus.Success)
            {
                r.AddError(new Error(checkStatus, nameof(channelCrDto.Description)));
            }

            checkStatus = Helper.CheckParam(channelCrDto.Name, _nameLength,_nameNullAllowed);
            if (checkStatus != CheckStatus.Success)
            {
                r.AddError(new Error(checkStatus, nameof(channelCrDto.Name)));
            }
        }
    }
}
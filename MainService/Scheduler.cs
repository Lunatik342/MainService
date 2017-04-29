using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using MainService.DtoManagers;

namespace MainService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Scheduler : IScheduler
    {
        public ResultBase LeaveChannel(long channelId)
        {
            return new UserRolesManager().LeaveChannel(GetUser().user_id, channelId);
        }

        public DbRequestResult<UserDto> GetUserInformation()
        {
            return new DbRequestResult<UserDto> { CreatedObject = Converter.ConvertToUserDto(GetUser())};

        }

        public CrResult<UserDto> EditUser(UserCrDto user)
        {
            return new UsersManager().Edit(user, GetUser());
        }

        public CrResult<ChannelRoleDto> CreateChannel(ChannelCrDto channelDto)
        {
            return new ChannelManager().CreateChannel(channelDto, GetUser().user_id);
        }

        public DbRequestResult<List<ChannelRoleDto>> GetChannels()
        {
            return new ChannelManager().GetChannels(GetUser().user_id);
        }

        public DbRequestResult<List<UserDto>> GetChannelsUsers(long channelId)
        {
            return  new ChannelManager().GetChannelsUsers(GetUser().user_id,channelId);
        }

        public Result InviteUser(string userId,long channelId)
        {
            return new UserRolesManager().InviteUser(GetUser().user_id, userId, channelId);
        }

        public ResultBase AcceptInvite(long channelId)
        {
            return new UserRolesManager().AcceptInvite(GetUser().user_id, channelId);
        }

        public ResultBase DeleteChannel(long channelId)
        {
            return new ChannelManager().DeleteChannel(channelId, GetUser().user_id);
        }

        public ResultBase DeleteUserFromChannel(long channelId, long targetUserId)
        {
            return new UserRolesManager().DeleteUserRole(GetUser().user_id, targetUserId, channelId);
        }

        public Result ChangeUsersRole(long channelId, long targetUserId,long roleId)
        {
            return new UserRolesManager().ChangeUserRole(GetUser().user_id, channelId, targetUserId,roleId);
        }

        public CrResult<EventDto> CreateEvent(EventCrDto ev)
        {
            return new EventManager().CreateEvent(GetUser().user_id, ev);
        }

        public Result DeleteEvent(long evId)
        {
            return new EventManager().DeleteEvent(GetUser().user_id, evId);
        }

        public CrResult<EventDto> EditEvent(EventDto ev)
        {
            return new EventManager().EditEvent(GetUser().user_id, ev);
        }

        public DbRequestResult<List<EventDto>> GetEvents(int count, int offset, DateTime dateTime,long channelId)
        {
            return new EventManager().GetEvents(GetUser().user_id, count, offset, dateTime, channelId);
        }


        private User GetUser()
        {
            return new UsersManager().GetUserByNickname(OperationContext.Current.ServiceSecurityContext.PrimaryIdentity.Name);
        }
    }
}

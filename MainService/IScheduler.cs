using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace MainService
{
    [ServiceContract]
    public interface IScheduler
    {
        [OperationContract]
        ResultBase LeaveChannel(long channelId);
        [OperationContract]
        DbRequestResult<UserDto> GetUserInformation();

        [OperationContract]
        CrResult<UserDto> EditUser(UserCrDto user);

        [OperationContract]
        CrResult<ChannelRoleDto> CreateChannel(ChannelCrDto channel);

        [OperationContract]
        DbRequestResult<List<ChannelRoleDto>> GetChannels();

        [OperationContract]
        DbRequestResult<List<UserDto>> GetChannelsUsers(long channelId);

        [OperationContract]
        Result InviteUser(string nickname, long channelId);

        [OperationContract]
        ResultBase AcceptInvite(long channelId);

        [OperationContract]
        ResultBase DeleteChannel(long channelId);

        [OperationContract]
        ResultBase DeleteUserFromChannel(long channelId,long targetUserId);

        [OperationContract]
        Result ChangeUsersRole(long channelId, long targetUserId, long roleId);

        [OperationContract]
        CrResult<EventDto> CreateEvent(EventCrDto ev);

        [OperationContract]
        Result DeleteEvent(long evId);

        [OperationContract]
        CrResult<EventDto> EditEvent(EventDto ev);

        [OperationContract]
        DbRequestResult<List<EventDto>> GetEvents(int count,int offset,DateTime dateTime,long channelId);
        
    }
}

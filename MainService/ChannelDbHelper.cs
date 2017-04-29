using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Linq;
using MainService;

namespace MainService1
{
    public class ChannelDbHelper
    {
        private readonly SchedulerContext _context = new SchedulerContext();

        public bool CreateChannel(ChannelDto channelDto, long userId)
        {
            try
            {
                var c = _context.Channel.Add(new Channel
                {
                    channe_description = channelDto.Description,
                    channel_name = channelDto.Name
                });
                _context.SaveChanges();
                if (!AddUserRole(c.channel_id, userId, 0))
                    return false;
            }
            catch (DbUpdateException)
            {
                return false;
            }
            return true;
        }

        public List<ChannelRoleDto> GetChannels(User user)
        {
            var userRoles = _context.UserRole.Where(userRole => userRole.user_id == user.user_id);
            var result = new List<ChannelRoleDto>();
            foreach (var userRole in userRoles)
            {
                result.Add(new ChannelRoleDto
                {
                    ChannelId = userRole.channel_id,
                    RoleId = userRole.Role.role_id,
                    RoleName = userRole.Role.role_name,
                    Name = userRole.Channel.channel_name,
                    Description = userRole.Channel.channe_description
                }
                );
            }
            return result;
        }


        public List<UserDto> GetChannelsUsers(User user, long channelId)
        {
            List<UserDto> result = new List<UserDto>();
            var isActionAllowed = CheckPermition(user.user_id, channelId, "See members");
            if (isActionAllowed)
            {
                var channelRoles = _context.UserRole.Where(uRole => uRole.channel_id == channelId);
                foreach (var channelRole in channelRoles)
                {
                     var channelUser = _context.User.Find(channelRole.user_id);
                     result.Add(Converter.ConvertToUserDto(channelUser));
                }
                return result;
            }
            return null;
        }


        public bool InviteUser(User user, long invitedUserId,long channelId)
        {
            if (user.user_id == invitedUserId)
                return false;
            if (IsUserInChannel(invitedUserId, channelId) != null)
                return false;
            if (CheckPermition(user.user_id, channelId, "Add user"))
            {
                return AddUserRole(channelId, invitedUserId, 6);
            }
            return false;

        }

        public bool AccepteInvite(long userId,long channelId)
        {
            if (IsUserInChannel(userId, channelId).role_id == 6)
            {
                return ChangeRole(userId, channelId, 5);
            }
            return false;
        }

        public bool DeleteChannel(long channelId,long userId)
        {
            if (CheckPermition(userId, channelId, "Delete channel"))
            {
                try
                {
                    _context.Channel.Remove(_context.Channel.Find(channelId));
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }


        public bool DeleteUserRole(long userId,long targetUserId,long channelId)
        {
            if (CheckPermition(userId, channelId, "Delete users"))
            {
                try
                {
                    _context.UserRole.Remove(IsUserInChannel(targetUserId,channelId));
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }

        public bool ChangeUsesrRole(long userId, long channelId,long targetUserId,long roleId)
        {
            if (CheckPermition(userId, channelId, "Change roles"))
            {
                try
                {
                    var userRole = IsUserInChannel(targetUserId, channelId);
                    userRole.role_id = roleId;
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }

        
        public bool CreateEvent(long userId, EventCrDto ev)
        {
            if (CheckPermition(userId, ev.ChannelId, "Add news"))
            {
                try
                {
                    _context.Event.Add(new Event
                    {
                        channel_id = ev.ChannelId,
                        improtance_id = ev.ImportanceId,
                        creation_time = DateTime.Now,
                        description = ev.Description,
                        title = ev.Title,
                        event_time = ev.EventTime

                    });
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }

        public bool DeleteEvent(long userId, long evId)
        {
            var ev = _context.Event.Find(evId);
            if (ev == null)
                return false;

            if (CheckPermition(userId, ev.channel_id, "Delete news"))
            {
                try
                {
                    _context.Event.Remove(ev);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }

        public CrResult<EventDto> EditEvent(long userId, EventDto ev)
        {
            var res = new CrResult<EventDto>();
            var targetEv = _context.Event.Find(ev.EventId);
            if (targetEv == null)
            {
                res.AddError(new Error(CheckStatus.IdDoesNotExist, nameof(ev.EventId)));
                return res;
            }
            if (targetEv.channel_id != ev.ChannelId)
            {
                res.AddError(new Error(CheckStatus.IdDoesNotExist, nameof(ev.ChannelId)));
                return res;
            }
            if (CheckPermition(userId, targetEv.channel_id, "Edit news"))
            {
                targetEv.improtance_id = ev.ImportanceId;
                targetEv.description = ev.Description;
                targetEv.event_time = ev.EventTime;
                targetEv.title = ev.Title;
                try
                {
                    _context.SaveChanges();
                    res.CreatedObject = ev;
                    return res;
                }
                catch (Exception)
                {
                    res.ActionResult = ActionResult.DatabaseError;
                    return res;
                }

            }
            else
            {
                res.ActionResult = ActionResult.PermissionDenied;
                return res;
            }
        }


        public List<EventDto> GetEvents(long userId,int count, int offset, DateTime dateTime,long channelId)
        {

            if (CheckPermition(userId, channelId, "Edit news"))
            {
                
                var events =
                    _context.Event.Where(t => SqlFunctions.DateDiff("day",t.event_time , dateTime)< 0)
                        .OrderByDescending(t => SqlFunctions.DateDiff("day", t.event_time, dateTime))
                        .Take(count);
                return EventCrDto.ConvertList(events.ToList());

            }
            else
            {
                return null;
            }
        }

        private bool AddUserRole(long channelId,long userId,long userRole)
        {
            _context.UserRole.Add(new UserRole { channel_id = channelId, user_id = userId, role_id = userRole });
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //return false;
                throw;
            }
        }

        private bool ChangeRole(long userId,long channelId,long roleId)
        {
            var role = _context.UserRole.First(uRole => uRole.channel_id == channelId && uRole.user_id == userId);
            role.role_id = roleId;
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool CheckPermition(long userId, long channelId, string permitionName)
        {
            var userRole = IsUserInChannel(userId, channelId);
            if (userRole?.Role.Permition.FirstOrDefault(per => per.permition_name == permitionName) != null)
                return true;
            return false;
        }

        private UserRole IsUserInChannel(long userId, long channelId)
        {
             return  _context.UserRole.FirstOrDefault(u => u.user_id == userId && u.channel_id == channelId);
        }

    }
    

}
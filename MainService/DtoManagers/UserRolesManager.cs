using System;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace MainService.DtoManagers
{
    public class UserRolesManager
    {

        private readonly SchedulerContext _context = new SchedulerContext();

        private readonly int _invitedUserRoleId = 6;

        private readonly int _addUserPermitionId = 2;
        private readonly int _deleteUsersPermitionId = 4;
        private readonly int _changeRolesPermitionId = 6;
        public Result InviteUser(long userId, string invitedUserNickname, long channelId)
        {
            var user = _context.User.FirstOrDefault(u => u.nickname == invitedUserNickname);
            var res = new Result();
            if (user == null)
            {
                res.AddError(new Error(CheckStatus.IdDoesNotExist,nameof(invitedUserNickname)));
                return res;
            }
            var invitedUserId = user.user_id;
            if (userId == invitedUserId || IsUserInChannel(invitedUserId, channelId) != null)
            {
                res.AddError(new Error(CheckStatus.ArgumentIsNotUnique,nameof(userId)));
                return res;
                
            }
            if (CheckPermition(userId, channelId, _addUserPermitionId))
            {
                AddUserRole(channelId, invitedUserId, _invitedUserRoleId,_context);
                try
                {
                    _context.SaveChanges();
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

        public ResultBase AcceptInvite(long userId, long channelId)
        {
            var res = new ResultBase();
            if (IsUserInChannel(userId, channelId).role_id == _invitedUserRoleId)
            {
                ChangeRole(userId, channelId, 5,res);
            }
            else
            {
                res.ActionResult = ActionResult.PermissionDenied;
            }
            return res;
        }

        public ResultBase LeaveChannel(long userId, long channelId)
        {
            var res = new ResultBase();
            var userRole = IsUserInChannel(userId, channelId);
            if (userRole!=null)
            {
                _context.UserRole.Remove(userRole);
                try
                {
                    _context.SaveChanges();
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

        public ResultBase DeleteUserRole(long userId, long targetUserId, long channelId)
        {
            var res = new ResultBase();
            if (CheckPermition(userId, channelId, _deleteUsersPermitionId))
            {
                try
                {
                    _context.UserRole.Remove(IsUserInChannel(targetUserId, channelId));
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    res.ActionResult =ActionResult.DatabaseError;
                }
            }
            else
            {
                res.ActionResult = ActionResult.PermissionDenied;
            }
            return res;
        }

        public Result ChangeUserRole(long userId, long channelId, long targetUserId, long roleId)
        {
            var res = new Result();
            if (CheckPermition(userId, channelId, _changeRolesPermitionId))
            {
                
                try
                {
                    var userRole = IsUserInChannel(targetUserId, channelId);
                    if(userRole!=null)
                        ChangeRole(userRole,roleId,res);
                    else
                    {
                        res.ActionResult = ActionResult.IncorrectParameter;
                        res.AddError(new Error(CheckStatus.IncorrectParametr,nameof(targetUserId)));
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

        public void ChangeRole(long userId, long channelId, long roleId, ResultBase res)
        {
            var role = _context.UserRole.First(uRole => uRole.channel_id == channelId && uRole.user_id == userId);
            role.role_id = roleId;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                res.ActionResult = ActionResult.DatabaseError;
            }
        }

        public void ChangeRole(UserRole userRole,long roleId, ResultBase res)
        {
            try
            {
                userRole.role_id = roleId;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                res.ActionResult = ActionResult.DatabaseError;
            }
        }

        public static UserRole AddUserRole(long channelId, long userId, long userRole, SchedulerContext context )
        {
            return context.UserRole.Add(new UserRole { channel_id = channelId, user_id = userId, role_id = userRole });
        }

        public bool CheckPermition(long userId, long channelId, long permitionId)
        {
            var userRole = IsUserInChannel(userId, channelId);
            if (userRole?.Role.Permition.FirstOrDefault(per => per.permition_id == permitionId) != null)
                return true;
            return false;
        }

        public UserRole IsUserInChannel(long userId, long channelId)
        {
            return _context.UserRole.FirstOrDefault(u => u.user_id == userId && u.channel_id == channelId);
        }
    }
}
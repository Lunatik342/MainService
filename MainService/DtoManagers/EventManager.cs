using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace MainService.DtoManagers
{
    public class EventManager
    {
        private readonly SchedulerContext _context = new SchedulerContext();

        private readonly int _addNewsPermitionId = 3;
        private readonly int _deleteNewsPermitionId = 5;
        private readonly int _editNewsPermitionId = 7;
        private readonly int _readNewsPermitionId = 8;

        private readonly int _descriptionLenght = 70;
        private readonly int _titleLenght = 20;

        private readonly bool _descriptionNullAllowed = true;
        private readonly bool _titleNullAllowed = false;

        public CrResult<EventDto> CreateEvent(long userId, EventCrDto ev)
        {
            var res = new CrResult<EventDto>();
            CheckEvent(ev, res);
            if (res.ActionResult == ActionResult.Success)
            {
                if (new UserRolesManager().CheckPermition(userId, ev.ChannelId, _addNewsPermitionId))
                {
                    try
                    {
                        var createdEv = _context.Event.Add(Converter.ConvertToEvent(ev));
                        _context.SaveChanges();
                        res.CreatedObject = Converter.ConvertToEventDto(createdEv);
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
            }
            return res;
        }

        public Result DeleteEvent(long userId, long evId)
        {
            var res = new Result();
            var ev = _context.Event.Find(evId);
            if (ev != null)
            {
                if (new UserRolesManager().CheckPermition(userId, ev.channel_id, _deleteNewsPermitionId))
                {
                    try
                    {
                        _context.Event.Remove(ev);
                        _context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        res.ActionResult = ActionResult.DatabaseError;
                    }
                }
                else
                {
                    res.ActionResult = ActionResult.PermissionDenied;
                }
            }
            else
            {
                res.AddError(new Error(CheckStatus.IdDoesNotExist,nameof(evId)));
            }
            return res;
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
            if (new UserRolesManager().CheckPermition(userId, targetEv.channel_id, _editNewsPermitionId))
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
        
        public DbRequestResult<List<EventDto>> GetEvents(long userId, int count, int offset, DateTime dateTime, long channelId)
        {
            var res = new DbRequestResult<List<EventDto>>();
            if (new UserRolesManager().CheckPermition(userId, channelId, _readNewsPermitionId))
            {
                var str =
                    _context.Event.Where(
                        t => t.channel_id == channelId && SqlFunctions.DateDiff("day", t.event_time, dateTime) < offset+1);
                var events =
                    str.OrderByDescending(t => SqlFunctions.DateDiff("minute", t.event_time, dateTime))
                        .Take(count).Select(Converter.ConvertToEventDto).ToList();
                res.CreatedObject = events;

            }
            else
            {
                res.ActionResult = ActionResult.PermissionDenied;
            }
            return res;
        }

        public void CheckEvent(EventCrDto ev, Result res)
        {

            var checkStatus = Helper.CheckParam(ev.Description, _descriptionLenght, _descriptionNullAllowed);
            if (checkStatus != CheckStatus.Success)
            {
                res.AddError(new Error(checkStatus, nameof(ev.Description)));
            }
            checkStatus = Helper.CheckParam(ev.Title, _titleLenght, _titleNullAllowed);
            if (checkStatus != CheckStatus.Success)
            {
                res.AddError(new Error(checkStatus, nameof(ev.Title)));
            }
            if (ev.EventTime == DateTime.MinValue)
            {
                res.AddError(new Error(CheckStatus.ArgumentIsNull, nameof(ev.EventTime)));
            }
            if (ev.ImportanceId != null && !IsImportanceExist(ev.ImportanceId))
            {
                res.AddError(new Error(CheckStatus.IdDoesNotExist, nameof(ev.ImportanceId)));
            }
        }

        private bool IsImportanceExist(long? importanceId)
        {
            return _context.Importance.Find(importanceId) != null;
        }
    }
}
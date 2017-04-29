using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace MainService
{
    [DataContract]
    public class UserBaseDto
    {
        [DataMember]
        public string Nickname;
        [DataMember]
        public string Name;
        [DataMember]
        public string Surname;
        [DataMember]
        public string Email;
        [DataMember]
        public string Phone;
        [DataMember]
        public string Group;
        [DataMember]
        public string Description;
        [DataMember]
        public long? CityId;
        [DataMember]
        public long? UniversityId;
    }

    [DataContract]
    public class UserCrDto: UserBaseDto
    {
        [DataMember]
        public string Password;
    }

    [DataContract]
    public class UserDto : UserBaseDto
    {
        [DataMember]
        public long Id;
    }



    [DataContract]
    public class UniversityDto
    {
        [DataMember]
        public long Id;
        [DataMember]
        public string ShortName;
    }

    [DataContract]
    public class CityDto
    {
        [DataMember]
        public long Id;
        [DataMember]
        public string Name;
    }

    [DataContract]
    public class ChannelCrDto
    {
        [DataMember]
        public string Name;
        [DataMember]
        public string Description;
    }


    [DataContract]
    public class ChannelDto:ChannelCrDto
    {
        [DataMember]
        public long ChannelId;
    }

    [DataContract]
    public class RoleDto
    {
        [DataMember]
        public long RoleId;
        [DataMember]
        public string RoleName;
        [DataMember]
        public string RoleDescription;
    }

    [DataContract]
    public class ChannelRoleDto:ChannelDto
    {
        [DataMember]
        public long RoleId;
        [DataMember]
        public string RoleName;
    }

    [DataContract]
    public class PermitionDto 
    {
        [DataMember]
        public long RermitionId;
        [DataMember]
        public string RermitionName;
    }

    [DataContract]
    public class RolePermitions: RoleDto
    {
        [DataMember]
        public List<PermitionDto> Permitions;
    }
    

    [DataContract]
    public class EventCrDto 
    {
        [DataMember]
        public long ChannelId;
        [DataMember]
        public string Title;
        [DataMember]
        public string Description;
        [DataMember]
        public DateTime EventTime;
        [DataMember]
        public long? ImportanceId;

        public static EventDto ConvertToEventDto(Event ev)
        {
            return new EventDto
            {
                ChannelId = ev.channel_id,
                EventId = ev.event_id,
                Description = ev.description,
                Title = ev.title,
                ImportanceId = ev.improtance_id,
                EventTime = ev.event_time
            };
        }

        public static List<EventDto> ConvertList(IEnumerable<Event> events)
        {
            return events.Select(ConvertToEventDto).ToList();
        }
    }

    [DataContract]
    public class EventDto: EventCrDto
    {
        [DataMember]
        public long EventId;

        [DataMember]
        public DateTime CreationTime;
    }

    [DataContract]
    public class ImportanceDto
    {
        [DataMember]
        public long ImportanceId;
        [DataMember]
        public string ImportanceDescription;
    }

    public class UserRoleDto
    {
        [DataMember]
        public long ChannelId;
        [DataMember]
        public long UserId;
        [DataMember]
        public long RoleId;
    }
}

using System;
using System.Linq;

namespace MainService
{
    public class Converter
    {
        public static RolePermitions ConvertToRoleDto(Role r)
        {
            return new RolePermitions
            {
                RoleId = r.role_id,
                RoleDescription = r.role_description,
                RoleName = r.role_name,
                Permitions = r.Permition.Select(per => new PermitionDto
                {
                    RermitionId = per.permition_id,
                    RermitionName = per.permition_name
                }).ToList()

            };
        }

        public static ImportanceDto ConvertToImportanceDto(Importance importance)
        {
            return new ImportanceDto
            {
                ImportanceId = importance.importance_id,
                ImportanceDescription = importance.title,
            };
        }

        public static UniversityDto ConvertToUniversityDto(University u)
        {
            return new UniversityDto { Id = u.university_id, ShortName = u.short_name };
        }


        public static CityDto ConvertToCityDto(City city)
        {
            return new CityDto { Id = city.city_id, Name = city.city_name };
        }

        public static User ConvertToUser(UserCrDto userCrDto)
        {

            return new User
            {
                nickname = userCrDto.Nickname,
                description = userCrDto.Description,
                email = userCrDto.Email,
                group = userCrDto.Group,
                name = userCrDto.Name,
                password = userCrDto.Password,
                phone = userCrDto.Phone,
                surname = userCrDto.Surname,
                university_id = userCrDto.UniversityId,
                city_id = userCrDto.CityId,
                creation_time = DateTime.Now
            };
        }

        public static UserDto ConvertToUserDto(User user)
        {

            return new UserDto
            {
                Id = user.user_id,
                Nickname = user.nickname,
                Description = user.description,
                Email = user.email,
                Group = user.group,
                Name = user.name,
                Phone = user.phone,
                Surname = user.surname,
                UniversityId = user.university_id,
                CityId = user.city_id,
            };
        }

        public static Channel ConvertToChannel(ChannelCrDto channelDto)
        {
            return new Channel
            {
                channe_description = channelDto.Description,
                channel_name = channelDto.Name
            };
        }

        public static ChannelDto ConvertToChannelDto(Channel channel)
        {
            return new ChannelDto
            {
                Description = channel.channe_description,
                ChannelId = channel.channel_id,
                Name = channel.channel_name
            };
        }

        public static UserRole ConvertToUserRole(UserRoleDto userRoleDto)
        {
            return new UserRole
            {
                channel_id = userRoleDto.ChannelId,
                user_id = userRoleDto.UserId,
                role_id = userRoleDto.RoleId
            };
        }

        public static ChannelRoleDto ConvertToChannelRoleDto(UserRole userRole)
        {
            return new ChannelRoleDto
            {
                ChannelId = userRole.channel_id,
                RoleId = userRole.Role.role_id,
                RoleName = userRole.Role.role_name,
                Name = userRole.Channel.channel_name,
                Description = userRole.Channel.channe_description
            };
        }

        public static Event ConvertToEvent(EventCrDto ev)
        {
            return new Event
            {
                channel_id = ev.ChannelId,
                improtance_id = ev.ImportanceId,
                creation_time = DateTime.Now,
                description = ev.Description,
                title = ev.Title,
                event_time = ev.EventTime
            };
        }

        public static EventDto ConvertToEventDto(Event ev)
        {
            return new EventDto
            {
                ImportanceId = ev.improtance_id,
                EventId = ev.event_id,
                ChannelId = ev.channel_id,
                Description = ev.description,
                Title = ev.title,
                EventTime = ev.event_time,
                CreationTime = ev.creation_time
            };
        }


    }
}
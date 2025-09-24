using SmartMeetingSystem.API.DTOs;
using SmartMeetingSystem.Domain.Entities;

namespace SmartMeetingSystem.API.Mappers
{
    public static class MomMappings
    {
        public static Mom ToEntity(this MomUpsertDto dto) =>
            new Mom
            {
                BookingId = dto.BookingId,
                MeetingTitle = dto.MeetingTitle,
                DiscussionPoints = dto.DiscussionPoints,
                Decisions = dto.Decisions,
                FileSummary = dto.FileSummary
            };

        public static void UpdateEntity(this MomUpsertDto dto, Mom entity)
        {
            entity.BookingId = dto.BookingId;
            entity.MeetingTitle = dto.MeetingTitle;
            entity.DiscussionPoints = dto.DiscussionPoints;
            entity.Decisions = dto.Decisions;
            entity.FileSummary = dto.FileSummary;
        }

        public static MomReadDto ToReadDto(this Mom entity) =>
            new MomReadDto
            {
                Id = entity.Id,
                BookingId = entity.BookingId,
                MeetingTitle = entity.MeetingTitle,
                DiscussionPoints = entity.DiscussionPoints,
                Decisions = entity.Decisions,
                FileSummary = entity.FileSummary
            };
    }
}

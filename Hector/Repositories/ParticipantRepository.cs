using Hector.Data;
using Hector.Models.DTOs;

namespace Hector.Repositories
{
    public class ParticipantRepository
    {
        private readonly HectorDbContext _participantDbContext;

        public ParticipantRepository(HectorDbContext participantDbContext)
        {
            _participantDbContext = participantDbContext;
        }


        public List<ParticipantDTO> GetAllParticipants() => _participantDbContext.Participants.ToList();

        public ParticipantDTO GetParticipant(int id) => _participantDbContext.Participants.FirstOrDefault(i => i.Id == id);

        public ParticipantDTO CreateParticipant(ParticipantDTO participant)
        {
            _participantDbContext.Participants.Add(participant);
            _participantDbContext.SaveChanges();
            return participant;
        }

        public ParticipantDTO UpdateParticipant(int id, ParticipantDTO participant)
         {
            var existingParticipant = _participantDbContext.Participants.FirstOrDefault(i => i.Id == id);
            if (existingParticipant != null)
            {
                existingParticipant.Name = participant.Name;
                existingParticipant.Description = participant.Description;
            }
            _participantDbContext.SaveChanges();
            return existingParticipant;
        }

        public bool DeleteParticipant(int id)
        {
            var participant = _participantDbContext.Participants.FirstOrDefault(i => i.Id == id);
            if (participant != null)
            {
                _participantDbContext.Participants.Remove(participant);
                _participantDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

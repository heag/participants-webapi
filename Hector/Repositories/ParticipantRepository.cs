using Hector.Data;
using Hector.Models;
using System.Collections.Generic;
using System.Linq;

namespace Hector.Repositories
{
    public class ParticipantRepository
    {
        private readonly ParticipantDbContext _participantDbContext;

        public ParticipantRepository(ParticipantDbContext participantDbContext)
        {
            _participantDbContext = participantDbContext;
        }


        public List<Participant> GetAllParticipants() => _participantDbContext.Participants.ToList();

        public Participant GetParticipant(int id) => _participantDbContext.Participants.FirstOrDefault(i => i.Id == id);

        public Participant CreateParticipant(Participant participant)
        {
            //participant.Id = _participantDbContext.Participants.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            _participantDbContext.Participants.Add(participant);
            _participantDbContext.SaveChanges();
            return participant;
        }

        public Participant UpdateParticipant(int id, Participant participant)
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

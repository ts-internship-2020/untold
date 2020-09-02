using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class AttendeeButtonsRepository : IAttendeeButtonsRepository
    {
        public readonly untoldContext _untoldContext;

        public AttendeeButtonsRepository (untoldContext untoldContext)
        {
            _untoldContext = untoldContext;
        }

        public void Attend(string email, string barcode, int confId)
        {
            int statusId = 1;
            var newMemberToInsert = _untoldContext.Attendee.Where(x => x.StatusId == statusId && x.AttendeeEmail == email && x.EmailCode == barcode && x.ConferenceId == confId).FirstOrDefault();
            _untoldContext.Attendee.AddAsync(newMemberToInsert);
           // _untoldContext.Attendee.AddAsync(x => x.StatusId =)
        }

        public void WithdrawnCommand(string email, int statusId)
        {
            var statusToUpdate = _untoldContext.Attendee.Where(x => x.StatusId == statusId && x.AttendeeEmail == email).FirstOrDefault();
            statusToUpdate.StatusId = 3;
            _untoldContext.SaveChanges();
        }

        public void JoinCommand(string email, int statusId)
        {
            throw new NotImplementedException();
        }
    }
}

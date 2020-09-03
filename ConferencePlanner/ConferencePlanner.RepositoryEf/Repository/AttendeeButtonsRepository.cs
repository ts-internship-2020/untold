using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class AttendeeButtonsRepository : IButtons
    {
        public readonly untoldContext _untoldContext;


        public AttendeeButtonsRepository (untoldContext untoldContext)
        {
            _untoldContext = untoldContext;
        }

        public void Attend(ButtonModel buttonModel)
        {
            int statusId = 1;
            
            var newMemberToInsert =new Attendee();
            newMemberToInsert.ConferenceId = buttonModel.confId;
            newMemberToInsert.AttendeeEmail = buttonModel.email;
            newMemberToInsert.StatusId = statusId;
            newMemberToInsert.EmailCode = buttonModel.barcode;

            _untoldContext.Attendee.Add(newMemberToInsert);
            _untoldContext.SaveChanges();
        }

        public void WithdrawnCommand(ButtonModel buttonModel)
        {
            var statusToUpdate = _untoldContext.Attendee.Where(x => x.StatusId == buttonModel.statusId && x.AttendeeEmail == buttonModel.email).FirstOrDefault();
            statusToUpdate.StatusId = 3;
            _untoldContext.SaveChanges();
        }

        public void JoinCommand(ButtonModel buttonModel)
        {
            throw new NotImplementedException();
        }

        //public void WithdrawnCommand(string email, int statusId)
        //{
        //    var statusToUpdate = _untoldContext.Attendee.Where(x => x.StatusId == statusId && x.AttendeeEmail == email).FirstOrDefault();
        //    statusToUpdate.StatusId = 3;
        //    _untoldContext.SaveChanges();
        //}

        //public void JoinCommand(string email, int statusId)
        //{
        //    var statusToUpdate = _untoldContext.Attendee.Where(x => x.StatusId == statusId && x.AttendeeEmail == email).FirstOrDefault();
        //    statusToUpdate.StatusId = 2;
        //    _untoldContext.SaveChanges();
        //}
    }
}

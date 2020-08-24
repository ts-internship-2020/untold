using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IAttendeeButtonsRepository
    {
        void Attend(string email, string barcode);
        void WithdrawnCommand(string email, int statusId);

        void JoinCommand(string email, int statusId);
    }
}

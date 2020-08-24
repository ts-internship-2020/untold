using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IAttendeeButtonsRepository
    {
        void AddEmail(string email, string barcode);
        void WithdrawnCommand(string email, int a);

        void JoinCommand();
    }
}

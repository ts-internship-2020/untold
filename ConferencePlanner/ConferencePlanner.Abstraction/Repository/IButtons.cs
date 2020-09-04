using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IButtons
    { 
        void Attend(ButtonModel buttonModel);
        void WithdrawnCommand(ButtonModel buttonModel);

        void JoinCommand(ButtonModel buttonModel);
    }
}

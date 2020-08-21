using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IAttendeeRepository
    {
        List<AttendeeModel> AttendeeConferences(String name);
    }
}
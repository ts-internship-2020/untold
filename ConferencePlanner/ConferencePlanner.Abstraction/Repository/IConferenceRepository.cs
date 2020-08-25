using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IConferenceRepository
    {
        List<ConferenceModel> GetConferencesByOrganizer(string email);
        List<ConferenceModel> AttendeeConferences(String name);

        List<ConferenceModel> FilterConferencesByDate(String email, string sDate, string eDate);

        List<ConferenceModel> FilterConfAttendeeByDate(String email, string sDate, string eDate);

        List<ConferenceModel> GetConferencesByPage(string email, int startIndex, int endIndex);
        ConferenceModel GetConferenceById(int id);

    }
}

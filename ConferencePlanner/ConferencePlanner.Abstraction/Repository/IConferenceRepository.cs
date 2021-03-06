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
        List<ConferenceModel> AttendeeConferences(String name,int pageSize,int currentPage);
        List<ConferenceModel> FilterConferencesByDate(String email, string sDate, string eDate);
        int GetAtendeesCount(string email, string sDate, string eDate);
        List<ConferenceModel> FilterConfAttendeeByDate(string email, string sDate, string eDate);
        List<ConferenceModel> GetConferencesByPage(string email, int startIndex, int endIndex, string sDate, string eDate);
        List<ConferenceModel> GetAttendeesByPage(string email, int startIndex, int endIndex, string sDate, string eDate);
        ConferenceModelWithEmail GetConferenceById(int id);

        ConferenceModel GetConferenceModelById(int id);
        void DeleteConferenceById(int id);
        void InsertConference(ConferenceModelWithEmail conference);

        void UpdateConference(ConferenceModelWithEmail conference);
        List<ConferenceModel> FilterAttendeesByDate(string email, string sDate, string eDate);
    }
}
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
        List<ConferenceModel> FilterAttendeesByDate(String email, string sDate, string eDate);
        List<ConferenceModel> FilterConfAttendeeByDate(String email, string sDate, string eDate);
        List<ConferenceModel> GetConferencesByPage(string email, int startIndex, int endIndex, string sDate, string eDate);
        List<ConferenceModel> GetAttendeesByPage(string email, int startIndex, int endIndex, string sDate, string eDate);
        ConferenceModelWithEmail GetConferenceById(int id);
        void DeleteConferenceById(int id);
        void InsertConference(ConferenceModelWithEmail conference);

        void UpdateConference(ConferenceModelWithEmail conference);


    }
}
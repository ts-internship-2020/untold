using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly untoldContext _untoldContext;

        public ConferenceRepository(untoldContext untoldContext)
        {

            _untoldContext = untoldContext;
        }

        public List<ConferenceModel> AttendeeConferences(string email, int pageSize, int currentPage)
        {
            IQueryable<Conference> conferences = _untoldContext.Conference
                .Include(x => x.MainSpeaker)
                .Include(x => x.Attendee)
                .Include(x => x.ConferenceCategory)
                .Include(x => x.ConferenceType)
                .Include(x => x.Location)
                .ThenInclude(x => x.City)
                .ThenInclude(x => x.County)
                .ThenInclude(x => x.Country)
                .Where(x => x.Attendee.Any(a => a.AttendeeEmail == email && a.StatusId != 3))
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize);


            List<ConferenceModel> conferenceModels = conferences.Select(c => new ConferenceModel()
            {
                ConferenceId = c.ConferenceId,
                ConferenceCategoryName = c.ConferenceCategory.ConferenceCategoryName,
                ConferenceTypeName = c.ConferenceType.ConferenceTypeName,
                Location = c.Location.City.County.Country.CountryName + ", " + c.Location.City.County.CountyName + ", " + c.Location.City.CityName,
                Speaker = c.MainSpeaker.FirstName + " " + c.MainSpeaker.LastName,
                Period = c.StartDate + " - " + c.EndDate,
                ConferenceName = c.ConferenceName,
                StatusId = c.Attendee.First().StatusId
            }).ToList();

           

            return conferenceModels.OrderByDescending(x => x.StatusId).ToList();

        }

        public void DeleteConferenceById(int id)
        {

            _untoldContext.Attendee.RemoveRange(_untoldContext.Attendee.Where(a => a.ConferenceId == id));
            var conference = _untoldContext.Conference.Where(c => c.ConferenceId == id).FirstOrDefault();
            _untoldContext.Conference.Remove(conference);
            _untoldContext.SaveChanges();
        }

        public List<ConferenceModel> FilterAttendeesByDate(string email, string sDate, string eDate)
        {
            List<Conference> conferences = _untoldContext.Conference.Where(c => c.StartDate >= DateTime.Parse(sDate) && c.EndDate <= DateTime.Parse(eDate))
                .Include(x => x.ConferenceCategory)
                .Include(x => x.ConferenceType)
                .Include(x => x.Location)
                .ThenInclude(x => x.City)
                .ThenInclude(x => x.County)
                .ThenInclude(x => x.Country)
                .Include(x => x.MainSpeaker)
                .ToList();
            List<Attendee> attendees = _untoldContext.Attendee.Where(c => c.AttendeeEmail == email).ToList();

            List<ConferenceModel> conferenceModels = conferences.Select(c => new ConferenceModel()
            {
                ConferenceId = c.ConferenceId,
                ConferenceCategoryName = c.ConferenceCategory.ConferenceCategoryName,
                ConferenceTypeName = c.ConferenceType.ConferenceTypeName,
                Location = c.Location.City.County.Country.CountryName + ", " + c.Location.City.County.CountyName + ", " + c.Location.City.CityName,
                Speaker = c.MainSpeaker.FirstName + " " + c.MainSpeaker.LastName,
                Period = c.StartDate + " - " + c.EndDate,
                ConferenceName = c.ConferenceName,
                StatusId = 0
            }).ToList();

            foreach (Attendee a in attendees)
            {
                if (a.StatusId == 3)
                {
                    conferenceModels.Remove(conferenceModels.Where(x => x.ConferenceId == a.ConferenceId).FirstOrDefault());
                }
                else
                {
                    conferenceModels.Where(x => x.ConferenceId == a.ConferenceId).FirstOrDefault().StatusId = a.StatusId;
                }
            }

            return conferenceModels.OrderByDescending(x => x.StatusId).ToList();
        }

        public List<ConferenceModel> FilterConfAttendeeByDate(string email, string sDate, string eDate)
        {
            List<Conference> conferences = _untoldContext.Conference.Where(c => c.StartDate >= DateTime.Parse(sDate) && c.EndDate <= DateTime.Parse(eDate))
                .Include(x => x.ConferenceCategory)
                .Include(x => x.ConferenceType)
                .Include(x => x.Location)
                .ThenInclude(x => x.City)
                .ThenInclude(x => x.County)
                .ThenInclude(x => x.Country)
                .Include(x => x.MainSpeaker)
                .ToList();

            List<Attendee> attendees = _untoldContext.Attendee.Where(c => c.StatusId != 3 && c.AttendeeEmail == email).ToList();


            List<ConferenceModel> conferenceModels = conferences.Select(c => new ConferenceModel()
            {
                ConferenceId = c.ConferenceId,
                ConferenceCategoryName = c.ConferenceCategory.ConferenceCategoryName,
                ConferenceTypeName = c.ConferenceType.ConferenceTypeName,
                Location = c.Location.City.County.Country.CountryName + ", " + c.Location.City.County.CountyName + ", " + c.Location.City.CityName,
                Speaker = c.MainSpeaker.FirstName + " " + c.MainSpeaker.LastName,
                Period = c.StartDate + " - " + c.EndDate,
                ConferenceName = c.ConferenceName,
                StatusId = 0
            }).ToList();

            for (int i = 0; i < conferenceModels.Count; i++)
            {
                conferenceModels[i].StatusId = attendees[i].StatusId;
            }

            return conferenceModels;
        }

        public List<ConferenceModel> FilterConferencesByDate(string email, string sDate, string eDate)
        {
            List<Conference> conferences = _untoldContext.Conference.Where(c => c.EmailOrganizer == email && c.StartDate >= DateTime.Parse(sDate) && c.EndDate <= DateTime.Parse(eDate))
                .Include(x => x.MainSpeaker)
                .Include(x => x.ConferenceType)
                .Include(x => x.ConferenceCategory)
                .Include(x => x.Location)
                .ThenInclude(x => x.City)
                .ThenInclude(x => x.County)
                .ThenInclude(x => x.Country)
                .ToList();

            List<ConferenceModel> conferenceModels = conferences.Select(c => new ConferenceModel()
            {
                ConferenceId = c.ConferenceId,
                ConferenceTypeName = c.ConferenceType.ConferenceTypeName,
                ConferenceCategoryName = c.ConferenceCategory.ConferenceCategoryName,
                ConferenceName = c.ConferenceName,
                Speaker = c.MainSpeaker.FirstName + " " + c.MainSpeaker.LastName,
                Period = c.StartDate + " - " + c.EndDate,
                Location = c.Location.City.County.Country.CountryName + ", " + c.Location.City.County.CountyName + ", " + c.Location.City.CityName
            }).ToList();

            return conferenceModels;

        }

        public List<ConferenceModel> GetAttendeesByPage(string email, int startIndex, int endIndex, string sDate, string eDate)
        {
            List<Conference> conferences = _untoldContext.Conference.Where(c => c.StartDate >= DateTime.Parse(sDate) && c.EndDate <= DateTime.Parse(eDate))
                .Include(x => x.ConferenceCategory)
                .Include(x => x.ConferenceType)
                .Include(x => x.Location)
                .ThenInclude(x => x.City)
                .ThenInclude(x => x.County)
                .ThenInclude(x => x.Country)
                .Include(x => x.MainSpeaker)
                .ToList();
            List<Attendee> attendees = _untoldContext.Attendee.Where(c => c.AttendeeEmail == email).ToList();

            List<ConferenceModel> conferenceModels = conferences.Select(c => new ConferenceModel()
            {
                ConferenceId = c.ConferenceId,
                ConferenceCategoryName = c.ConferenceCategory.ConferenceCategoryName,
                ConferenceTypeName = c.ConferenceType.ConferenceTypeName,
                Location = c.Location.City.County.Country.CountryName + ", " + c.Location.City.County.CountyName + ", " + c.Location.City.CityName,
                Speaker = c.MainSpeaker.FirstName + " " + c.MainSpeaker.LastName,
                Period = c.StartDate + " - " + c.EndDate,
                ConferenceName = c.ConferenceName,
                StatusId = 0
            }).ToList();

            foreach (Attendee a in attendees)
            {
                if (a.StatusId == 3)
                {
                    conferenceModels.Remove(conferenceModels.Where(x => x.ConferenceId == a.ConferenceId).FirstOrDefault());
                }
                else
                {
                    conferenceModels.Where(x => x.ConferenceId == a.ConferenceId).FirstOrDefault().StatusId = a.StatusId;
                }
            }
            List<ConferenceModel> orderedConferences = conferenceModels.OrderByDescending(x => x.StatusId).ToList();
            int aux = Math.Min(orderedConferences.Count, endIndex - 1);
            List<ConferenceModel> result = new List<ConferenceModel>();

            for (int i = startIndex - 1; i < aux; i++)
            {
                result.Add(orderedConferences[i]);
            }
            return result;
        }

        public ConferenceModel GetConferenceById(int id)
        {
            Conference conf = _untoldContext.Conference.Where(c => c.ConferenceId == id)
                .Include(x => x.Location)
                .ThenInclude(x => x.City)
                .ThenInclude(x => x.County)
                .ThenInclude(x => x.Country)
                .FirstOrDefault();

            ConferenceModel conferenceModel = new ConferenceModel()
            {
                ConferenceId = conf.ConferenceId,
                ConferenceName = conf.ConferenceName,
                Location = conf.Location.City.County.Country.CountryName + ", " + conf.Location.City.County.CountyName + ", " + conf.Location.City.CityName,
                Period = conf.StartDate + " - " + conf.EndDate
            };
            return conferenceModel;

        }



        public List<ConferenceModel> GetConferencesByOrganizer(string email)
        {
            List<Conference> conferences = _untoldContext.Conference.Where(c => c.EmailOrganizer == email)
               .Include(x => x.MainSpeaker)
               .Include(x => x.ConferenceType)
               .Include(x => x.ConferenceCategory)
               .Include(x => x.Location)
               .ThenInclude(x => x.City)
               .ThenInclude(x => x.County)
               .ThenInclude(x => x.Country)
               .ToList();

            List<ConferenceModel> conferenceModels = conferences.Select(c => new ConferenceModel()
            {
                ConferenceId = c.ConferenceId,
                ConferenceTypeName = c.ConferenceType.ConferenceTypeName,
                ConferenceCategoryName = c.ConferenceCategory.ConferenceCategoryName,
                ConferenceName = c.ConferenceName,
                Speaker = c.MainSpeaker.FirstName + " " + c.MainSpeaker.LastName,
                Period = c.StartDate + " - " + c.EndDate,
                Location = c.Location.City.County.Country.CountryName + ", " + c.Location.City.County.CountyName + ", " + c.Location.City.CityName
            }).ToList();

            return conferenceModels;
        }

        public List<ConferenceModel> GetConferencesByPage(string email, int startIndex, int endIndex, string sDate, string eDate)
        {
            List<Conference> conferences = _untoldContext.Conference.Where(c => c.EmailOrganizer == email && c.StartDate >= DateTime.Parse(sDate) && c.EndDate <= DateTime.Parse(eDate))
               .Include(x => x.MainSpeaker)
               .Include(x => x.ConferenceType)
               .Include(x => x.ConferenceCategory)
               .Include(x => x.Location)
               .ThenInclude(x => x.City)
               .ThenInclude(x => x.County)
               .ThenInclude(x => x.Country)
               .ToList();

            List<ConferenceModel> conferenceModels = conferences.Select(c => new ConferenceModel()
            {
                ConferenceId = c.ConferenceId,
                ConferenceTypeName = c.ConferenceType.ConferenceTypeName,
                ConferenceCategoryName = c.ConferenceCategory.ConferenceCategoryName,
                ConferenceName = c.ConferenceName,
                Speaker = c.MainSpeaker.FirstName + " " + c.MainSpeaker.LastName,
                Period = c.StartDate + " - " + c.EndDate,
                Location = c.Location.City.County.Country.CountryName + ", " + c.Location.City.County.CountyName + ", " + c.Location.City.CityName
            }).ToList();

            int aux = Math.Min(conferenceModels.Count, endIndex - 1);
            List<ConferenceModel> result = new List<ConferenceModel>();
            for (int i = startIndex - 1; i < aux; i++)
            {
                result.Add(conferenceModels[i]);
            }
            return result;

        }
        public void InsertConference(ConferenceModelWithEmail conferenceModel)
        {
            int locationId = 0;
            int cityId = conferenceModel.LocationId;

            try
            {
                locationId = _untoldContext.Location
                    .Where(l => l.CityId == cityId)
                    .Select(l => l.LocationId).First();
            }
            catch (Exception e)
            {
                Location location = new Location()
                {
                    CityId = cityId
                };
                _untoldContext.Location.Add(location);
                _untoldContext.SaveChanges();
                locationId = _untoldContext.Location.Where(l => l.CityId == cityId).Select(l => l.LocationId).First();
            }

            Conference newConference = new Conference()
                {
                    ConferenceName = conferenceModel.ConferenceName,
                    ConferenceCategoryId = conferenceModel.ConferenceCategoryId,
                    ConferenceTypeId = conferenceModel.ConferenceTypeId,
                    MainSpeakerId = conferenceModel.MainSpeakerId,
                    LocationId = locationId,
                    StartDate = conferenceModel.StartDate,
                    EndDate = conferenceModel.EndDate,
                    EmailOrganizer =conferenceModel.Email
                };
                _untoldContext.Conference.Add(newConference);
                _untoldContext.SaveChanges();
            
        }

        public void UpdateConference(ConferenceModelWithEmail conferenceModel)
        {
            Conference conferenceUpdate = _untoldContext.Conference.Find(conferenceModel.ConferenceId);
            conferenceUpdate.ConferenceName = conferenceModel.ConferenceName;
            conferenceUpdate.ConferenceCategoryId = conferenceModel.ConferenceCategoryId;
            conferenceUpdate.ConferenceTypeId = conferenceModel.ConferenceTypeId;
            conferenceUpdate.MainSpeakerId = conferenceModel.MainSpeakerId;
            conferenceUpdate.LocationId = conferenceModel.LocationId;
            conferenceUpdate.StartDate = conferenceModel.StartDate;
            conferenceUpdate.EndDate = conferenceModel.EndDate;

            _untoldContext.SaveChanges();
        }
    }


}

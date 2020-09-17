using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly untoldContext _untoldContext;

        public SpeakerRepository(untoldContext untoldContext)
        {
            _untoldContext = untoldContext;
        }

        public BindingList<SpeakerModel> GetAllSpeakers()
        {
            List<Speaker> speakers = _untoldContext.Speaker.Where(s => s.SpeakerId != 21).ToList();
            List<SpeakerModel> speakerModels = speakers.Select(a => new SpeakerModel() { 
                SpeakerId = a.SpeakerId, 
                FirstName = a.FirstName,
                LastName = a.LastName,
                Nationality = a.Nationality,
                ImagePath = a.ImagePath,
                Rating = (float)a.Rating
            }).ToList();

            BindingList<SpeakerModel> speakersBindingList = new BindingList<SpeakerModel>(speakerModels);

            return speakersBindingList;
        }
        public SpeakerModel GetSpeakerById(int id)
        {
            Speaker speaker = _untoldContext.Speaker.Where(s => s.SpeakerId == id).FirstOrDefault();
            SpeakerModel speakerModel = new SpeakerModel() {
                SpeakerId = speaker.SpeakerId,
                FirstName = speaker.FirstName,
                LastName = speaker.LastName,
                Nationality = speaker.Nationality,
                Rating = (float)speaker.Rating,
                ImagePath = speaker.ImagePath};
            return speakerModel;
        }
        public SpeakerModel GetSpeakerByConferenceId(int conferenceId)
        {
            Conference conference =  _untoldContext.Conference
                .Where(c => c.ConferenceId==conferenceId)
                .Include(x => x.MainSpeaker)
                .FirstOrDefault();

            SpeakerModel speakerModel = new SpeakerModel()
            {
                SpeakerId = conference.MainSpeaker.SpeakerId,
                FirstName = conference.MainSpeaker.FirstName,
                LastName = conference.MainSpeaker.LastName,
                Nationality = conference.MainSpeaker.Nationality,
                Rating = (float)conference.MainSpeaker.Rating,
                ImagePath = conference.MainSpeaker.ImagePath
            };
            return speakerModel;
        }
        public void InsertSpeaker(SpeakerModel speakerModel)
        {
            Speaker speaker = new Speaker()
            {
                FirstName = speakerModel.FirstName,
                LastName = speakerModel.LastName,
                Nationality = speakerModel.Nationality,
                Rating = speakerModel.Rating,
                ImagePath = speakerModel.ImagePath
            };
           
            _untoldContext.Speaker.Add(speaker);
            _untoldContext.SaveChanges();
        }
        public void UpdateSpeaker(SpeakerModel speakerModel)
        {
            Speaker speaker = _untoldContext.Speaker.Find(speakerModel.SpeakerId);
            speaker.FirstName = speakerModel.FirstName;
            speaker.LastName = speakerModel.LastName;
            speaker.Nationality = speakerModel.Nationality;
            speaker.Rating = speakerModel.Rating;
            _untoldContext.SaveChanges();
        }
        public void DeleteSpeaker(int id)
        { 
            Speaker speaker = _untoldContext.Speaker.Where(s => s.SpeakerId == id).FirstOrDefault();
            try
            {
                _untoldContext.Speaker.Remove(speaker);
            }
            catch (Exception e)
            {
                List<Conference> conferences = _untoldContext.Conference.Where(c => c.MainSpeakerId == id).ToList();
                conferences.ForEach(c => { c.MainSpeakerId = 21; });
                List<ConferenceXspeaker> conferenceXspeakers = _untoldContext.ConferenceXspeaker.Where(cxs => cxs.SpeakerId == id).ToList();
                conferenceXspeakers.ForEach(cxs => { cxs.SpeakerId = 21; });
                _untoldContext.Speaker.Remove(speaker);
            }

            _untoldContext.SaveChanges();
        }
    }

}

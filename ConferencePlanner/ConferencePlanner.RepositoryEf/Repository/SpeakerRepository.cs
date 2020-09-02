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
        //private readonly neverseaContext _dbContext;
        private readonly untoldContext _untoldContext;

        public SpeakerRepository(untoldContext untoldContext)
        {
            //_dbContext = dbContext;
            _untoldContext = untoldContext;
        }

        public BindingList<SpeakerModel> GetAllSpeakers()
        {
            List<Speaker> speakers = _untoldContext.Speaker.ToList();
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
        public SpeakerModel GetSpeakerByName(string[] names)
        {
            Speaker speaker = _untoldContext.Speaker.Where(s => s.FirstName.ToLower() == names[0].ToLower() && s.LastName.ToLower() == names[1].ToLower()).FirstOrDefault();

            SpeakerModel speakerModel = new SpeakerModel()
            {
                SpeakerId = speaker.SpeakerId,
                FirstName = speaker.FirstName,
                LastName = speaker.LastName,
                Nationality = speaker.Nationality,
                Rating = (float)speaker.Rating,
                ImagePath = speaker.ImagePath
            };
            return speakerModel;
        }
        public void InsertSpeaker(SpeakerModel speakerModel)
        {
            var speaker = new Speaker()
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
            var speaker = _untoldContext.Speaker.Find(speakerModel.SpeakerId);
            speaker.FirstName = speakerModel.FirstName;
            speaker.LastName = speakerModel.LastName;
            speaker.Nationality = speakerModel.Nationality;
            speaker.Rating = speakerModel.Rating;
            _untoldContext.SaveChanges();
        }
        public void DeleteSpeaker(int id)
        {
            var speaker = _untoldContext.Speaker.Where(s => s.SpeakerId == id).FirstOrDefault();
            _untoldContext.Speaker.Remove(speaker);
            _untoldContext.SaveChanges();
        }
    }

}

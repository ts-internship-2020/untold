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
            List<SpeakerModel> speakerModels = speakers.Select(a => new SpeakerModel() { SpeakerId = a.SpeakerId, FirstName = a.FirstName }).ToList();
            BindingList<SpeakerModel> speakersBindingList = new BindingList<SpeakerModel>(speakerModels);

            return speakersBindingList;
        }
        public SpeakerModel GetSpeakerById(int id)
        {
            Speaker speaker = _untoldContext.Speaker.Where(s => s.SpeakerId == id).FirstOrDefault();
            SpeakerModel speakerModel = new SpeakerModel();
            speakerModel.SpeakerId = speaker.SpeakerId;
            speakerModel.FirstName = speaker.FirstName;
            speakerModel.LastName = speaker.LastName;
            speakerModel.Nationality = speaker.Nationality;
            return speakerModel;
        }
        public SpeakerModel GetSpeakerByName(string[] names)
        {
            Speaker speaker = _untoldContext.Speaker.Where(s => s.FirstName == names[0]).Where(s => s.FirstName == names[1]).FirstOrDefault();
             
            SpeakerModel speakerModel = new SpeakerModel();

            return speakerModel;
        }
        public void InsertSpeaker(SpeakerModel speakerModel)
        {
            var speaker = new Speaker()
            {
                FirstName = speakerModel.FirstName,
                LastName = speakerModel.LastName,
                Nationality = speakerModel.Nationality,
            };
            //context.Students.Add(std);
            _untoldContext.Speaker.Add(speaker);


            //return speaker;
        }
        public void UpdateSpeaker(SpeakerModel speakerModel)
        {
            var speaker = _untoldContext.Speaker.Find(speakerModel.SpeakerId);
            speaker.FirstName = speakerModel.FirstName;
            _untoldContext.SaveChanges();
            //SpeakerModel speaker2 = _untoldContext.Speaker
            //    .Select(a => new Speaker() { SpeakerId = a.SpeakerId, Nationality = a.Nationality }).Where(a.FirstName = names[0], a.LastName = names[1]);

            //return speaker;
        }
        public void DeleteSpeaker(int id)
        {
            var speaker = _untoldContext.Speaker.Find(id);
            _untoldContext.Speaker.Remove(speaker);
            _untoldContext.SaveChanges();
        }
    }
    //alt test 
    //petrecere!!!
}

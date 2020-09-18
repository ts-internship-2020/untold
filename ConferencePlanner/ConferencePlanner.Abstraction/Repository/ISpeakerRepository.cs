using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface ISpeakerRepository
    {
        SpeakerModel GetSpeakerById(int id);
        SpeakerModel GetSpeakerByConferenceId(int id);
        BindingList<SpeakerModel> GetAllSpeakers();
        void UpdateSpeaker(SpeakerModel speaker);
        int InsertSpeaker(SpeakerModel speaker);

        void DeleteSpeaker(int id);
    }
}

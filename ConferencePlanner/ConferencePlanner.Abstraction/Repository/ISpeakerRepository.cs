using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface ISpeakerRepository
    {
        SpeakerModel GetSpeakerById(int id);
        SpeakerModel GetSpeakerByName(string[] names);

        List<SpeakerModel> GetAllSpeakers();

        

    }
}

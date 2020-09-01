using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class GetDemoRepository : IGetDemoRepository
    {
        //private readonly neverseaContext _dbContext;
        private readonly untoldContext _untoldContext;

        public GetDemoRepository(untoldContext untoldContext)
        {
            //_dbContext = dbContext;
            _untoldContext = untoldContext;
        }

        public List<DemoModel> GetDemo(string name)
        {
            //List<Demo> demos = _dbContext.Demo.ToList();
            List<Conference> conferences = _untoldContext.Conference.ToList();

            List<DemoModel> demoModels = conferences.Select(a => new DemoModel() { Id = a.ConferenceId, Name = a.ConferenceName }).ToList();

            return demoModels;
        }
    }
    //alt test 
    //petrecere!!!
}

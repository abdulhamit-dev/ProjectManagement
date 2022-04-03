using ProjectManagement.Business.Abstract;
using ProjectManagement.Business.Constant;
using ProjectManagement.Core.Utilities.Result;
using ProjectManagement.DataAccess.Abstract;
using ProjectManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Business.Concrete
{
    public class TeamManager : ITeamService
    {
        ITeamDal _teamDal;

        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public IResult Add(Team team)
        {
            _teamDal.Add(team);
            return new SuccessResult(MessageReurns.Add);
        }

        public IResult Delete(int id)
        {
            var team = _teamDal.Get(x => x.Id == id);
            if (team is null)
                return new ErrorResult(MessageReurns.NotFound);
            else
            {
                _teamDal.Delete(team);
                return new SuccessResult(MessageReurns.Delete);
            }
        }

        public IDataResult<List<Team>> GetAll()
        {
            return new SuccessDataResult<List<Team>>(_teamDal.GetAll());
        }

        public IDataResult<Team> GetById(int id)
        {
            var team = _teamDal.Get(x => x.Id == id);
            if (team is null)
                return new ErrorDataResult<Team>(null, MessageReurns.NotFound);

            return new SuccessDataResult<Team>(team);

        }

        public IResult Update(Team team)
        {
            _teamDal.Update(team);
            return new SuccessResult(MessageReurns.Update);
        }
    }
}

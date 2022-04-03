using ProjectManagement.Core.Utilities.Result;
using ProjectManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Business.Abstract
{
    public interface ITeamService
    {
        IDataResult<List<Team>> GetAll();
        IDataResult<Team> GetById(int id);
        IResult Add(Team team);
        IResult Update(Team team);
        IResult Delete(int id);
    }
}

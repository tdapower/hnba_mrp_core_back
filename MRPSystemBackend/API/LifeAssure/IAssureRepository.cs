using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.LifeAssure
{
    public interface IAssureRepository
    {
        IEnumerable<Assure> GetAssures();
        IEnumerable<Assure> SearchAssures(SearchAssure searchAssure);
        Assure GetAssureById(int assureId);

        int AddAssure(Assure assure);
        int AddAssureWithTransaction(Assure assure, IDbConnection connection);
        int UpdateAssure(Assure assure);



    }
}

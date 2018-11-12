using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.Common
{
    public interface ICommonRepository
    {

        IEnumerable<Nationality> GetAllNationalities();
        Nationality GetNationalityById(int nationalityID);




    }
}

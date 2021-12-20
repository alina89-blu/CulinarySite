using Database;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface ITelephoneService
    {
        void CreateTelephone(Telephone telephone);
        void UpdateTelephone(Telephone telephone);
        void DeleteTelephone(int id);
        IEnumerable<Telephone> GetTelephoneList();
        Telephone GetTelephone(int id);
    }
}

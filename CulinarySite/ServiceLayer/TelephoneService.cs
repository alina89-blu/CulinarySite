using Database;
using Repositories;
using System.Collections.Generic;

namespace ServiceLayer
{
    public class TelephoneService
    {
        private readonly IReadOnlyGenericRepository<Telephone> telephoneReadOnlyRepository;
        private readonly IWriteGenericRepository<Telephone> telephoneWriteRepository;

        public TelephoneService(
            IReadOnlyGenericRepository<Telephone> telephoneReadOnlyRepository,
            IWriteGenericRepository<Telephone> telephoneWriteRepository)
        {
            this.telephoneReadOnlyRepository = telephoneReadOnlyRepository;
            this.telephoneWriteRepository = telephoneWriteRepository;
        }
        public void CreateTelephone(Telephone telephone)
        {
            this.telephoneWriteRepository.Create(telephone);
            this.telephoneWriteRepository.Save();
        }
        public void UpdateTelephone(Telephone telephone)
        {
            this.telephoneWriteRepository.Update(telephone);
            this.telephoneWriteRepository.Save();
        }
        public void DeleteTelephone(int id)
        {
            this.telephoneWriteRepository.Delete(id);
            this.telephoneWriteRepository.Save();
        }
        public IEnumerable<Telephone> GetTelephoneList()
        {
            return this.telephoneReadOnlyRepository.GetItemList();
        }
        public Telephone GetTelephone(int id)
        {
            return this.telephoneReadOnlyRepository.GetItem(id);
        }
    }
}

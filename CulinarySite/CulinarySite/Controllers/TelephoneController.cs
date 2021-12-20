using System.Collections.Generic;
using Database;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace CulinarySite.Controllers
{
    public class TelephoneController : BaseController
    {
        private readonly ITelephoneService telephoneService;
        public TelephoneController(ITelephoneService telephoneService)
        {
            this.telephoneService = telephoneService;
        }

        [HttpGet]
        public IEnumerable<Telephone> GetTelephoneList()
        {
            return this.telephoneService.GetTelephoneList();
        }

        [HttpGet("{id}")]
        public Telephone GetTelephone(int id)
        {
            return this.telephoneService.GetTelephone(id);
        }

        [HttpPost]
        public void CreateTelephone(Telephone telephone)
        {
            this.telephoneService.CreateTelephone(telephone);
        }

        [HttpPut]
        public void UpdateTelephone(Telephone telephone)
        {
            this.telephoneService.UpdateTelephone(telephone);
        }

        [HttpDelete("{id}")]
        public void DeleteTelephone(int id)
        {
            this.telephoneService.DeleteTelephone(id);
        }
    }
}

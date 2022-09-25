﻿
using ServiceLayer.Dtos.Telephone;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface ITelephoneService
    {
        void CreateTelephone(CreateTelephoneDto createTelephoneDto);
        void UpdateTelephone(UpdateTelephoneDto updateTelephoneDto);
        void DeleteTelephone(int id);
        IEnumerable<TelephoneListDto> GetTelephoneList();
        TelephoneDetailDto GetTelephone(int id);
    }
}

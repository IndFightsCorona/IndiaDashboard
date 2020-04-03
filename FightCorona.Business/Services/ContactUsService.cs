using FightCorona.Data.Services;
using FightCorona.Models;
using FightCorona.UI.Models;
using System;

namespace FightCorona.Business.Services
{
    public class ContactUsService
    {
        private readonly IndiaDataService _indiaDataService;
        public ContactUsService()
        {
            _indiaDataService = new IndiaDataService();
        }

        #region Public Methods

        public Boolean InsertContactUs(ContactUsModel model)
        {
            model.CreatedDate = DateTime.Now;
            return _indiaDataService.InsertContactUs(model);
        }
        #endregion Public Methods
    }
}

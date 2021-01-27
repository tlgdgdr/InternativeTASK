using Internative.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Internative.Services.Abstract
{
    public interface ICarsService
    {
        List<Cars> Get();
        Cars Get(string id);
        List<Cars> GetByBrand(string brand);
        List<Cars> GetByModel(string model);
        Cars GetByLicensePlate(string licensePlate);
        List<Cars> GetByRegistrationDate(DateTime registrationDate);
        public List<Cars> GroupByModel(string model, DateTime date);
        Cars Create(Cars car);
        Cars Update(string id, Cars car);
        void Delete(string id);

    }
}

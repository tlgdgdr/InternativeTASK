using Internative.Entities;
using Internative.Services.Abstract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Internative.Services.Concrete
{
    public class CarsService : ICarsService
    {
        private readonly IMongoCollection<Cars> _cars;

        public CarsService(ICarsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _cars = database.GetCollection<Cars>(settings.CarsCollectionName);
        }
        public Cars Create(Cars car)
        {
            _cars.InsertOne(car);
            return car;
        }

        public void Delete(string id)
        {
            _cars.DeleteOne(car => car.Id == id);
        }

        public List<Cars> Get()
        {
            return _cars.Find(car => true).ToList();
        }

        public Cars Get(string id)
        {
            return _cars.Find(car => car.Id == id).FirstOrDefault();
        }

        public List<Cars> GetByBrand(string brand)
        {
            if (brand == null)
            {
                throw new Exception("Brand is null!");
            }
            return _cars.Find(car => car.Brand.ToLower().Equals(brand.ToLower())).ToList();
        }

        public Cars GetByLicensePlate(string licensePlate)
        {
            if (licensePlate == null)
            {
                throw new Exception("license plate is null!");
            }
            return _cars.Find(car => car.LicensePlate.ToLower().Equals(licensePlate.ToLower())).FirstOrDefault();
        }

        public List<Cars> GetByModel(string model)
        {
            if (model == null)
            {
                throw new Exception("model is null!");
            }
            return _cars.Find(car => car.Model.ToLower().Equals(model.ToLower())).ToList();
        }

        public List<Cars> GetByRegistrationDate(DateTime registrationDate)
        {
            if (registrationDate == null)
            {
                throw new Exception("registration Date is null!");
            }
            return _cars.Find(car => car.RegistrationDate.Equals(registrationDate)).ToList();
        }
        public List<Cars> GroupByModel(string model,DateTime date)
        {
            if(model==null || date == null)
            {
                throw new Exception("Can not be null!");
            }
            return _cars.Find(car => car.Model == model).SortBy(car => car.RegistrationDate.Month == date.Month).ToList();
        }

        public Cars Update(string id,Cars car)
        {
            _cars.ReplaceOne(update => update.Id== car.Id, car);
            return car;
        }
    }
}

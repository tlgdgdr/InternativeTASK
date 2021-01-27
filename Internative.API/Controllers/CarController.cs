using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internative.Services.Concrete;
using Internative.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Internative.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarsService _carsService;

        public CarController(CarsService carsService)
        {
            _carsService = carsService;
        }

        // GET: api/<CarController>
        [HttpGet]
        public ActionResult<List<Cars>> Get()
        {
            return _carsService.Get();  
        }
        // GET api/<CarController>/id
        [HttpGet("{id}")]
        public ActionResult<Cars> Get(string id)
        {
            var car = _carsService.Get(id);

            if (car == null)
            {
                return NotFound();
            }
            return car;
        }
        [HttpGet("{getByBrand}")]
        public ActionResult<List<Cars>> GetByBrand(string brand)
        {
            var car = _carsService.GetByBrand(brand);

            if (car == null)
            {
                return NotFound();
            }
            return car;
        }
        [HttpGet("{getByModel}")]
        public ActionResult<List<Cars>> GetByModel(string model)
        {
            var car = _carsService.GetByModel(model);

            if (car == null)
            {
                return NotFound();
            }
            return car;
        }
        [HttpGet("{getByLicensePlate}")]
        public ActionResult<Cars> GetByLicensePlate(string licensePlate)
        {
            var car = _carsService.GetByLicensePlate(licensePlate);

            if (car == null)
            {
                return NotFound();
            }
            return car;
        }
        [HttpGet("{getByRegistrationDate}")]
        public ActionResult<List<Cars>> GetByRegistrationDate(DateTime registrationDate)
        {
            var car = _carsService.GetByRegistrationDate(registrationDate);

            if (car == null)
            {
                return NotFound();
            }
            return car;
        }
        [HttpGet("{orderByModel}")]
        public ActionResult<List<Cars>> GroupByModel(string model, DateTime date)
        {
            return _carsService.GroupByModel(model, date);
        }

        // POST api/<CarController>
        [HttpPost]
        public ActionResult<Cars> Post([FromBody] Cars car)
        {
            return _carsService.Create(car);
        }

        // PUT api/<CarController>/id
        [HttpPut("{id}")]
        public ActionResult<Cars> Put(string id, [FromBody] Cars car)
        {
            var update = _carsService.Get(id);
            if(update == null)
            {
                return NotFound();
            }
            _carsService.Update(id, car);
            return NoContent();
        }

        // DELETE api/<CarController>/id
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var deleted = _carsService.Get(id);
            if(deleted == null)
            {
                throw new Exception(" It's not registered in database");
            }
            _carsService.Delete(id);

        }
    }
}

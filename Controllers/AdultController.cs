using System;
using System.Collections.Generic;
using FamilyData.Data;
using FamilyData.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace FamilyData.Controllers
{
    [ApiController]
    [Route("/adults")]
    public class AdultController : ControllerBase
    {
        private IAdultRepository _adultRepository;

        public AdultController(IAdultRepository adultRepository)
        {
            this._adultRepository = adultRepository;
        }

        [HttpGet]
        public List<Adult> getAllAdults()
        {
            return _adultRepository.GetAll();
        }

        [HttpGet("/{id}")]
        public Adult getAdult(int id)
        {
            return _adultRepository.GetAdult(id);
        }

        [HttpDelete("/{id}")]
        public void deleteAdult(int id)
        {
            _adultRepository.Delete(id);
        }

        [HttpGet("/search/{s}")]
        public List<Adult> findByNameContains(string s)
        {
            Console.WriteLine($"LOOKUP {s}: ");
            _adultRepository.FindByNameContains(s).ForEach(Console.WriteLine);
            return _adultRepository.FindByNameContains(s);
        }

        [HttpPost]
        public Adult CreateAdult([FromBody] Adult adult)
        {
            _adultRepository.Save(adult);
            return adult;
        }
    }
}
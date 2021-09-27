using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Booking_System.Controllers
{
    public class ResourcesController : BaseApiController
    {
        private readonly IResourcesRepository repository;

        public ResourcesController(IResourcesRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public List<Resource> getAll()
        {
            return this.repository.getAll();
        }
        [HttpGet("resources/{id}")]
        public Resource getById(int id)
        {
            return this.repository.getById(id);
        }
        [HttpPut("book")]
        public Resource bookResource(ResourceModel model)
        {
            //var mymodel = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            //mymodel[2] = Convert.ToDateTime(mymodel[2]).ToString();
            return this.repository.bookResource(model);

        }
        [HttpPost("add")]
        public Resource addResource(Resource model)
        {
           return this.repository.Add(model);
        }

    }
}

using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ResourcesRepository : IResourcesRepository
    {
        private readonly AppDbContext context;
        private readonly UserManager<AppUser> userManager;

        public ResourcesRepository(AppDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public List<Resource> getAll()
        {
            return this.context.Resources.ToList();
        }
        public Resource Add(Resource model)
        {
            var newModel = this.context.Resources.Add(model).Entity;
            this.context.SaveChanges();
            return newModel;
        }
        public Resource getById(int id)
        {
            return this.context.Resources.FirstOrDefault(x => x.Id == id);
        }
        public Resource bookResource(ResourceModel model)
        {
            try
            {
                var resource = this.context.Resources.FirstOrDefault(m => m.Id == model.resourceId);
                var user = this.userManager.Users.FirstOrDefault(m => m.Id == model.userId);
                resource.Available = model.available;
                resource.AppUser = user;
                context.Update(resource);
                context.SaveChanges();
                return resource;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}

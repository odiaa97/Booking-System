using DAL.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IResourcesRepository
    {
        List<Resource> getAll();
        Resource bookResource(ResourceModel model);
        Resource Add(Resource model);
        Resource getById(int id);


    }
}

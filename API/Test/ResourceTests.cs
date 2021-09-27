using Booking_System.Controllers;
using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace Test
{
    [ExcludeFromCodeCoverage]
    public class ResourceTests
    {
        private readonly ResourcesController controller;
        private readonly Mock<IResourcesRepository> repo = new Mock<IResourcesRepository>();
        public ResourceTests()
        {
            controller = new ResourcesController(repo.Object);
        }
        [Fact]
        public void testAddResource()
        {
            // Arrange
            var resourceId = 1;
            var resourceName = "book";
            var resource = new Resource()
            {
                Id = resourceId,
                Name = resourceName
            };
            repo.Setup(x => x.getById(resourceId)).Returns(resource);

            // Act
            var resourceModel = controller.getById(resourceId);

            // Assert
            Assert.Equal(resourceId, resourceModel.Id);
        }

        [Fact]
        public void testGetResources()
        {
            // Arrange
            var resourceId = 1;
            var resourceName = "book";
            var resources = new List<Resource>()
            {
                new Resource {Id = resourceId, Name = resourceName }
            };
            repo.Setup(x => x.getAll()).Returns(resources);

            // Act
            var resourcesModel = controller.getAll();

            // Assert
            Assert.Equal(resources, resourcesModel);
        }

        [Fact]
        public void testBookResources()
        {
            // Arrange
            var resourceId = 1;
            var resourceModel = new ResourceModel()
            {
                resourceId = resourceId,
                userId = 1,
                available = "2021-09-25"
            };
            var resource = new Resource()
            {
                Id = resourceId,
                Name = "book",
                Available = "2021-09-15"
            };

            // Act
            var addResourceController = controller.addResource(resource);

            var resourceController = controller.bookResource(resourceModel);
            var getResource = repo.Setup(x => x.getById(resourceId)).Returns(new Resource());

            // Assert
            Assert.NotEqual(resourceController, resource);
        }
    }
}

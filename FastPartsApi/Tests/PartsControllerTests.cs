using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FastPartsApi.Controllers;
using FastPartsApi.Data;
using FastPartsApi.Models;
using Xunit;

namespace FastPartsApi.Tests
{
    public class PartsControllerTests : IDisposable
    {
        private readonly AppDbContext _context;
        private readonly PartsController _controller;

        public PartsControllerTests()
        {
            // Настройка InMemory базы данных с уникальным именем
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new AppDbContext(options);
            _context.Database.EnsureCreated();

            _controller = new PartsController(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        // Вспомогательный метод для создания валидного объекта Part
        private Part CreateTestPart(int id, string name)
        {
            return new Part
            {
                IdPart = id,
                Name = name,
                Description = "Test Description",
                Weight = "1.5 kg",
                Volume = "0.005 m3",
                Amount = 10,
                IdMedia = 1,
                IdCategory = 1,
                IdOemNumber = 1,
                Price = 100
            };
        }

        private void SeedDatabase(IEnumerable<Part> parts)
        {
            _context.Parts.AddRange(parts);
            _context.SaveChanges();
        }

        #region GET: api/Parts

        [Fact]
        public async Task GetParts_ReturnsAllParts()
        {
            // Arrange
            var testParts = new List<Part>
            {
                CreateTestPart(1, "Part 1"),
                CreateTestPart(2, "Part 2")
            };
            SeedDatabase(testParts);

            // Act
            var result = await _controller.GetParts();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Part>>>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Part>>(actionResult.Value);
            Assert.Equal(2, model.Count());
        }

        #endregion

        #region GET: api/Parts/{id}

        [Fact]
        public async Task GetPart_WithValidId_ReturnsPart()
        {
            // Arrange
            var part = CreateTestPart(1, "Engine Part");
            SeedDatabase(new[] { part });

            // Act
            var result = await _controller.GetPart(1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Part>>(result);
            var returnedPart = Assert.IsType<Part>(actionResult.Value);
            Assert.Equal(1, returnedPart.IdPart);
            Assert.Equal("Engine Part", returnedPart.Name);
        }

        [Fact]
        public async Task GetPart_WithInvalidId_ReturnsNotFound()
        {
            // Act
            var result = await _controller.GetPart(99);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        #endregion

        #region POST: api/Parts

        [Fact]
        public async Task PostPart_ValidPart_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var newPart = CreateTestPart(3, "New Part");

            // Act
            var result = await _controller.PostPart(newPart);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Part>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);

            Assert.Equal("GetPart", createdAtActionResult.ActionName);
            Assert.Equal(3, createdAtActionResult.RouteValues["id"]);

            var returnedPart = Assert.IsType<Part>(createdAtActionResult.Value);
            Assert.Equal("New Part", returnedPart.Name);
            Assert.Equal("Test Description", returnedPart.Description);

            Assert.Equal(1, _context.Parts.Count());
        }

        #endregion

        #region PUT: api/Parts/{id}

        [Fact]
        public async Task PutPart_ValidData_ReturnsNoContent()
        {
            // Arrange
            var part = CreateTestPart(1, "Old Name");
            SeedDatabase(new[] { part });

            // Отсоединяем от трекера, чтобы избежать конфликта сущностей в InMemory DB
            _context.Entry(part).State = EntityState.Detached;

            var updatedPart = CreateTestPart(1, "Updated Name");

            // Act
            var result = await _controller.PutPart(1, updatedPart);

            // Assert
            Assert.IsType<NoContentResult>(result);

            var partInDb = await _context.Parts.FindAsync(1);
            Assert.NotNull(partInDb);
            Assert.Equal("Updated Name", partInDb.Name);
        }

        [Fact]
        public async Task PutPart_IdMismatch_ReturnsBadRequest()
        {
            // Arrange
            var updatedPart = CreateTestPart(2, "Mismatched Part");

            // Act
            var result = await _controller.PutPart(1, updatedPart);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        #endregion

        #region DELETE: api/Parts/{id}

        [Fact]
        public async Task DeletePart_ExistingId_ReturnsNoContent()
        {
            // Arrange
            var part = CreateTestPart(5, "To Be Deleted");
            SeedDatabase(new[] { part });

            // Act
            var result = await _controller.DeletePart(5);

            // Assert
            Assert.IsType<NoContentResult>(result);
            Assert.Null(await _context.Parts.FindAsync(5));
        }

        [Fact]
        public async Task DeletePart_NonExistingId_ReturnsNotFound()
        {
            // Act
            var result = await _controller.DeletePart(99);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        #endregion
    }
}
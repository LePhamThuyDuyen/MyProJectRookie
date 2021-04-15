
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyProject_Backend.Controllers;
using MyProject_Backend.Models;
using ShareModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Backend_Test
{
    public class CategoriesControllerTests 
    {

        [Fact]
        public async Task Get_List_Category()
        {
            var mockCategoryRepo = new Mock<ICategory>();

            List<Category> temp = new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Lipstick" },
                new Category { CategoryId = 2, CategoryName = "sKincare" },
                new Category { CategoryId = 3, CategoryName = "LipCare" },
            };

            mockCategoryRepo.Setup(mcp => mcp.GetAllAsync()).ReturnsAsync(temp.AsEnumerable());

            var controller = new CategoryController(mockCategoryRepo.Object);

            var results = await controller.Get();

            Assert.IsType<ActionResult<IEnumerable<CategoryShare>>>(results);
            Assert.NotNull(results);
            var actionResult = Assert.IsType<OkObjectResult>(results.Result);
            Assert.NotNull(actionResult);
            var listCategories = actionResult.Value as List<Category>;
            Assert.Equal(temp.Count, listCategories.Count);
            Assert.Equal(temp, listCategories);
        }

        [Fact]
        public async Task Update_Category()
        {
            var mockCategoryRepo = new Mock<ICategory>();

            Category category = new Category { CategoryId = 1, CategoryName = "Skin" };

            mockCategoryRepo.Setup(mcp => mcp.UpdateAsync(1, category)).ReturnsAsync(category);

            var controller = new CategoryController(mockCategoryRepo.Object);

            var result = await controller.PutCategory(1, category);

            Assert.NotNull(result);
            var actionResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(actionResult);
            var value = actionResult.Value as Category;
            Assert.True(category.CategoryId == value.CategoryId);
        }

        [Fact]
        public async Task Post_Category()
        {
            var mockCategoryRepo = new Mock<ICategory>();

            Category category = new Category { CategoryId = 6, CategoryName = "Lip" };

            mockCategoryRepo.Setup(mcp => mcp.CreateAsync(category)).ReturnsAsync(category);

            var controller = new CategoryController(mockCategoryRepo.Object);

            var result = await controller.PostCategory(category);

            Assert.IsType<ActionResult<CategoryShare>>(result);
            Assert.NotNull(result);
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.NotNull(actionResult);
            var value = actionResult.Value as Category;
            Assert.Equal(category, value);
        }


        [Fact]
        public async Task Delete_Category()
        {
            var mockCategoryRepo = new Mock<ICategory>();

            Category category = new Category { CategoryId = 2, CategoryName = "sKincare" };

            mockCategoryRepo.Setup(mcp => mcp.DeleteAsync(2)).ReturnsAsync(category);

            var controller = new CategoryController(mockCategoryRepo.Object);

            var result = await controller.DeleteCategory(2);

            Assert.NotNull(result);
            var actionResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(actionResult);
            var value = actionResult.Value as Category;
            Assert.True(category == value);
        }
    }
}

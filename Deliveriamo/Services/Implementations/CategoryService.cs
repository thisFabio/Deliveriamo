using Deliveriamo.DTOs.Category;
using Deliveriamo.Services.Interfaces;
using DeliveriamoRepository;

namespace Deliveriamo.Services.Implementations
{
    public class CategoryService : ICategoryService

    {
        private readonly IRepositoryService _repository;

        public CategoryService(IRepositoryService repository)
        {
            _repository = repository;
        }

        public async Task<DeleteCategoryResponseDto> DeleteCategory(DeleteCategoryRequestDto request)
        {

            var response = new DeleteCategoryResponseDto();

            // getting the category requested.
            var category =  await _repository.GetCategoryById(request.Id);

            if (request.Id <= 0 || category == null)
            {
                throw new Exception($"Category {request.Id} not valid.");

            }
            //let's save the whole product list.
            var products = await _repository.GetAllProducts();

            // to find if there are products assigned to the category to be deleted.
            var categoryProduct = products.Find(x => x.CategoryId == request.Id);

            if (categoryProduct == null)
            {
                await _repository.DeleteCategory(category);
                await _repository.SaveChanges();

               response.Category.Id = category.Id;

            }
            else
            {
                throw new Exception($"Category {request.Id} cannot be eliminated because there are dependencies on this object.");
            }

            return response;

        }

        public async Task<GetAllCategoryResponseDto> GetAllCategories(GetAllCategoryRequestDto request)
        {
            var response = new GetAllCategoryResponseDto();
            var result =  await _repository.GetCategories();
            var output = result.Select(x=> new CategoryDto()).ToList();
            response.Categories = output;

            return response;

        }
    }
}

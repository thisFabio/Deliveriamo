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

            var category =  await _repository.GetCategoryById(request.Id);
            await _repository.DeleteCategory(category);
            await _repository.SaveChanges();

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

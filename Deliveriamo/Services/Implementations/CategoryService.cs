using Deliveriamo.DTOs.Category;
using Deliveriamo.Services.Interfaces;
using DeliveriamoRepository.Entity;
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

        public async Task<AddCategoryResponseDto> AddCategory(AddCategoryRequestDto request)
        {
            AddCategoryResponseDto response = new();

            Category category = new()
            {
                Name = request.Name,
                Description = request.Description

            };

            if (category != null)
            {
                try
                {
                    await _repository.AddCategory(category);
                    await _repository.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            response.Id = category.Id;
            return response;
        }
        public async Task<UpdateCategoryResponseDto> UpdateCategory(UpdateCategoryRequestDto request)
        {
            var response = new UpdateCategoryResponseDto();
            Category category = await _repository.GetCategoryById(request.Id);

            if (request.Id <= 0 || category == null)
            {
                throw new Exception($"Category {request.Id} not valid.");
            }

            category.Name = request.Name;
            category.Description = request.Description;
            await _repository.UpdateCategory(category); 
            await _repository.SaveChanges();

            response.Name = category.Name;
            response.Description = category.Description;

            return response;
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


                await _repository.DeleteCategory(category);
                await _repository.SaveChanges();

            return response;

        }

        public async Task<GetAllCategoryResponseDto> GetAllCategories(GetAllCategoryRequestDto request)
        {
            var response = new GetAllCategoryResponseDto();
            var result =  await _repository.GetCategories();
            var output = result.Select(x=> new CategoryDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description

            }).ToList();
            response.Categories = output;

            return response;

        }

    }
}

using Deliveriamo.DTOs.Category;

namespace Deliveriamo.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<AddCategoryResponseDto> AddCategory(AddCategoryRequestDto request);
        Task<UpdateCategoryResponseDto> UpdateCategory(UpdateCategoryRequestDto request);

        Task<DeleteCategoryResponseDto> DeleteCategory(DeleteCategoryRequestDto request);

        Task<GetAllCategoryResponseDto> GetAllCategories(GetAllCategoryRequestDto request);
    }
}

using Deliveriamo.DTOs.Category;

namespace Deliveriamo.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<DeleteCategoryResponseDto> DeleteCategory(DeleteCategoryRequestDto request);

        Task<GetAllCategoryResponseDto> GetAllCategories(GetAllCategoryRequestDto request);
    }
}

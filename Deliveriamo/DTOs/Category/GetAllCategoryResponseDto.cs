namespace Deliveriamo.DTOs.Category
{
    public class GetAllCategoryResponseDto : BaseResponseDto
    {
        public List<CategoryDto> Categories { get; set; }
    }

}

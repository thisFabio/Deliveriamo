namespace Deliveriamo.DTOs.Product
{
    public class GetAllProductsResponseDto : BaseResponseDto
    {
        public List<ProductDto> Products { get; set; }
    }
}

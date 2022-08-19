using DeliveriamoRepository.Entity;
using System.ComponentModel.DataAnnotations;

namespace Deliveriamo.DTOs.Product
{
    public class GetProductByShopKeeperIdResponseDto : BaseResponseDto
    {
        public List<ProductDto> Products { get; set; }

    }
}

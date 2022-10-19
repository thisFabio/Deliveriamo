using Deliveriamo.DTOs.Order;
using Deliveriamo.Services.Interfaces;
using DeliveriamoRepository.Entity;
using Deliveriamo.Services.Exceptions;
using DeliveriamoRepository;
using Microsoft.EntityFrameworkCore;
using Deliveriamo.DTOs.Enums;

namespace Deliveriamo.Services.Implementations
{
    public class OrderService : IOrderService
    {

        private readonly IRepositoryService _repository;



        public OrderService(IRepositoryService repository)
        {
            _repository = repository;

        }

        public async Task<AddOrderResponseDto> AddOrder(AddOrderRequestDto request, string userId)
        {
            
            var response = new AddOrderResponseDto();
            if (Convert.ToInt32(userId) <= 0 || request.OrderTotalAmount < 0 || String.IsNullOrEmpty(request.PaymentMethod))
            {
                throw new Exception($"Impossible to add this order, invalid data entry");

            }

            Order order = new Order()
            {
                UserId = Convert.ToInt32(userId),
                PaymentMethod = request.PaymentMethod,
                OrderDescription = request.OrderDescription,
                OrderTotalAmount = request.OrderTotalAmount,
                OrderCreationDateTime = DateTime.Now,
                LastUpdateDateTime = DateTime.Now,
                DeliveryTime = 45,
                ShopKeeperId = request.ShopKeeperId
            };

            if (order != null)
            {
                try
                {
                    await _repository.AddOrder(order, userId);
                    await _repository.SaveChanges();
                    

                    List<int> productsId = new List<int>();

                    // loop to find products ID of all order products.
                    foreach (var productId in request.ProductIds)
                    {
                        productsId.Add(productId);
                    }
                    await _repository.AddOrderProduct(order, productsId);
                    await _repository.SaveChanges();

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            response.Id = order.Id;
            return response;

        }

        public async Task<DeleteOrderResponseDto> DeleteOrder(DeleteOrderRequestDto request)
        {
            var response = new DeleteOrderResponseDto();

            var order = await _repository.GetOrderById(request.Id);
            if (order == null)
            {
                throw new Exception($"Order with id {request.Id} doesn't exist");

            }

            await _repository.DeleteOrder(order);
            await _repository.SaveChanges();

            return response;
        }

        public async Task<GetAllOrdersResponseDto> GetAllOrders(GetAllOrdersRequestDto request, string userId)
        {
            var response = new GetAllOrdersResponseDto();
            var result = await _repository.GetAllOrders();
            
            result = result.Where(x => x.UserId == Convert.ToInt32(userId)).ToList();
            
            response.Orders = result.Select(x=> new OrderDto(x.Id,x.PaymentMethod,x.OrderDescription,x.OrderTotalAmount,
                x.OrderCreationDateTime,x.DeliveryTime,x.OrderProducts.Select(y=> new DTOs.Product.ProductDto(
                    y.Product.Id,
                    y.Product.Name,
                    y.Product.PriceUnit,
                    y.Product.Description,
                    y.Product.CategoryId,
                    y.Product.Barcode,
                    y.Product.UrlImage,
                    y.Product.Status,
                    y.Product.CreationTime,
                    y.Product.LastUpdate
                    )).ToList())).ToList();

            return response;
        }

        public async Task<GetOrdersByUserIdResponseDto> GetOrdersByUserId(GetOrdersByUserIdRequestDto request, string userId)
        {
            var result = new GetOrdersByUserIdResponseDto();
            var orderList = new List<Order>();
            var user = await _repository.GetUserById(Int32.Parse(userId));

            if (user.ShopKeeper == false)
            {
                orderList = await _repository.GetAllOrdersByUserId(Int32.Parse(userId));

            }
            else
            {
                orderList = await _repository.GetAllOrdersByShopKeeperId(Int32.Parse(userId));
            }

                result.Orders = orderList.Select(x => new OrderDto(x.Id, x.PaymentMethod, x.OrderDescription, x.OrderTotalAmount,
                    x.OrderCreationDateTime, x.DeliveryTime,x.OrderProducts.Select(y => new DTOs.Product.ProductDto(
                        y.Product.Id,
                        y.Product.Name,
                        y.Product.PriceUnit,
                        y.Product.Description,
                        y.Product.CategoryId,
                        y.Product.Barcode,
                        y.Product.UrlImage,
                        y.Product.Status,
                        y.Product.CreationTime,
                        y.Product.LastUpdate
                        )).ToList())).ToList();

            return result;
        }

        public async Task<GetOrderStatusResponseDto> GetOrderStatus(GetOrderStatusRequestDto request)
        {
            // get order by id

            var order = await _repository.GetOrderById(request.OrderId);
            var response = new GetOrderStatusResponseDto();

            // get order by idthe last updated status available.
            var orderStatus = order.OrderStatus.Where(x => x.StatusTime == DateTime.MaxValue).FirstOrDefault();

            response.StatusChangedTime = orderStatus.StatusTime;
            response.OrderStatusId = orderStatus.OrderId;
            response.Status = orderStatus.Status.ToString();
            
            return response;
        }

        public async Task<UpdateOrderResponseDto> UpdateOrder(UpdateOrderRequestDto request)
        {
            var response = new UpdateOrderResponseDto();

            Order order = await _repository.GetOrderById(request.Id);

            if (order == null)
            {
                throw new Exception($"Order with id {request.Id} doesn't exist");

            }

            // assignin modifications to the original order.
            order.PaymentMethod = request.PaymentMethod;
            order.UserId = request.UserId;
            order.OrderDescription = request.OrderDescription;
            order.OrderTotalAmount = request.OrderTotalAmount;
            order.DeliveryTime = request.DeliveryTime;
            order.ShopKeeperId = request.ShopKeeperId;

            // update order record into DB
            await _repository.UpdateOrder(order);
            await _repository.SaveChanges();

            //Assigning values to response
            response.UserId = request.UserId;
            response.PaymentMethod = request.PaymentMethod;
            response.OrderTotalAmount = request.OrderTotalAmount;
            response.OrderStatus = request.OrderStatus;
            response.OrderDescription = request.OrderDescription;
            response.DeliveryTime = request.DeliveryTime;
            response.ShopKeeperId = request.ShopKeeperId;

            return response;
        }
    }
}

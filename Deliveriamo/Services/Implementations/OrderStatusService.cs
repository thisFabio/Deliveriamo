using Deliveriamo.DTOs.Order;
using Deliveriamo.Services.Interfaces;
using DeliveriamoRepository.Entity;
using Deliveriamo.Services.Exceptions;
using DeliveriamoRepository;
using Microsoft.EntityFrameworkCore;
using Deliveriamo.DTOs.Enums;
using OrderStatus = DeliveriamoRepository.Entity.OrderStatus;
using Deliveriamo.DTOs.OrderStatus;

namespace Deliveriamo.Services.Implementations
{
    public class OrderStatusService : IOrderStatusService
    {

        private readonly IRepositoryService _repository;



        public OrderStatusService(IRepositoryService repository)
        {
            _repository = repository;

        }

   
        public async Task<GetOrderStatusResponseDto> GetOrderStatus(GetOrderStatusRequestDto request)
        {
            // get order by id

            var order = await _repository.GetOrderById(request.OrderId);
            var response = new GetOrderStatusResponseDto();

            // get order by idthe last updated status available.
            var orderStatus = order.OrderStatus.OrderByDescending(x=> x.StatusTime).FirstOrDefault();

            response.StatusChangedTime = orderStatus.StatusTime;
            response.OrderStatusId = orderStatus.OrderId;
            response.Status = orderStatus.Status?.Name;
            
            return response;
        }

        public async Task<PushForwardOrderStatusResponseDto> PushForwardStatus(PushForwardOrderStatusRequestDto request)
        {
            var response = new PushForwardOrderStatusResponseDto();
            // get the last order status of the order
            var orderStatus = await _repository.GetOrderStatusByOrderId(request.OrderId);

            // get the record from Status flow, to move on into the process
            var statusFlowRecord = await _repository.GetStatusFlowByStatusId(orderStatus.StatusId);

            //create a new order status to add
            var nextOrderStatus = new OrderStatus()
            {
                OrderId = orderStatus.OrderId,
                StatusId = statusFlowRecord.NextStatus.Id,
                StatusTime = DateTime.Now,

            };
            // adding the new order status
            await _repository.AddOrderStatus(nextOrderStatus);
            await _repository.SaveChanges();

            response.OrderStatusId = nextOrderStatus.StatusId;
            return response;

        }

        public async Task<CancelOrderStatusResponseDto> CancelOrderStatus(CancelOrderStatusStatusRequestDto request)
        {
            var response = new CancelOrderStatusResponseDto();
            // get the last order status of the order
            var orderStatus = await _repository.GetOrderStatusByOrderId(request.OrderId);

            // get the next order status, to select the canceled status
            var statusFlowRecord = await _repository.GetStatusFlowByStatusId(orderStatus.StatusId);


            //create a new order status to add
            var nextOrderStatus = new OrderStatus()
            {
                OrderId = orderStatus.OrderId,
                StatusId = statusFlowRecord.CanceledStatus.Id,
                StatusTime = DateTime.Now,

            };
            // adding the new order status
            await _repository.AddOrderStatus(nextOrderStatus);
            await _repository.SaveChanges();

            response.OrderStatusId = nextOrderStatus.StatusId;
            return response;
        }
    }
}

using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIDQueryHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public GetOrderDetailByIDQueryHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<GetOrderDetailByIDQueryResult> Handle(GetOrderDetailByIDQuery query)
        {
            var values = await _orderDetailRepository.GetByIDAsync(query.ID);

            return new GetOrderDetailByIDQueryResult
            {
               OrderDetailID=values.OrderDetailID,
               OrderingID=values.OrderingID,
               ProductAmount=values.ProductAmount,
               ProductID=values.ProductID,
               ProductName=values.ProductName,
               ProductPrice=values.ProductPrice,    
               ProductTotalPrice = values.ProductTotalPrice
            };
        }
    }
}

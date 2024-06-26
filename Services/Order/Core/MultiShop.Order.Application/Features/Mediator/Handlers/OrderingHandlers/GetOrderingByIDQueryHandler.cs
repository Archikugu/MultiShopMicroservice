﻿using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIDQueryHandler : IRequestHandler<GetOrderingByIDQuery, GetOrderingByIDQueryResult>
    {
        private readonly IRepository<Ordering> _orderingRepository;

        public GetOrderingByIDQueryHandler(IRepository<Ordering> orderingRepository)
        {
            _orderingRepository = orderingRepository;
        }

        public async Task<GetOrderingByIDQueryResult> Handle(GetOrderingByIDQuery request, CancellationToken cancellationToken)
        {
            var values = await _orderingRepository.GetByIDAsync(request.ID);
            return new GetOrderingByIDQueryResult
            {
                OrderDate = values.OrderDate,
                OrderingID = values.OrderingID,
                TotalPrice = values.TotalPrice,
                UserID = values.UserID
            };
        }
    }
}

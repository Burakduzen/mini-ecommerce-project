using ETicaretAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Basket.RemoveBasketItem
{
    public class RemoveBasketItemCommandHandler : IRequestHandler<RemoveBasketItemCommandRequest, RemoveBasketItemCommandResponse>
    {
        readonly IBasketService _baseService;

        public RemoveBasketItemCommandHandler(IBasketService baseService)
        {
            _baseService = baseService;
        }

        public async Task<RemoveBasketItemCommandResponse> Handle(RemoveBasketItemCommandRequest request, CancellationToken cancellationToken)
        {
            await _baseService.RemoveBasketItemAsync(request.BasketItemId);

            return new();
        }
    }
}

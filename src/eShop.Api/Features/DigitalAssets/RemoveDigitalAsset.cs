﻿using eShop.Api.Core;
using eShop.Api.Interfaces;
using eShop.Api.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace eShop.Api.Features
{
    public class RemoveDigitalAsset
    {
        public class Request : IRequest<Response>
        {
            public Guid DigitalAssetId { get; set; }
        }

        public class Response : ResponseBase
        {
            public DigitalAssetDto DigitalAsset { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;

            public Handler(IEShopDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var digitalAsset = await _context.DigitalAssets.SingleAsync(x => x.DigitalAssetId == request.DigitalAssetId);

                _context.DigitalAssets.Remove(digitalAsset);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    DigitalAsset = digitalAsset.ToDto()
                };
            }

        }
    }
}
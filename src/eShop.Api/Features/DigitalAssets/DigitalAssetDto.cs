using System;

namespace eShop.Api.Features
{
    public class DigitalAssetDto
    {
        public Guid DigitalAssetId { get; set; }
        public byte[] Bytes { get; set; }
        public string ContentType { get; set; }
    }
}

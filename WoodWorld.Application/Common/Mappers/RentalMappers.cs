using System;
using System.Collections.Generic;
using System.Text;
using WoodWorld.Application.Dtos;
using WoodWorld.Domain;

namespace WoodWorld.Application.Common.Mappers
{
    public static class RentalMappers
    {
        public static RentalDto ToDto(this Rental rental)
        {
            //TODO: add returned at to dto and mapper
            return new RentalDto
            (
                rental.Id,
                rental.UserId,
                rental.ToolId,
                rental.RentedAt,
                rental.DueAt,
                rental.DailyRateAtCheckout,
                rental.Status,
                rental.CreatedAt
            );
        }
    }
}

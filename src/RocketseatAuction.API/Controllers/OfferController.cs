using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Communication.Request;
using RocketseatAuction.API.Filters;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;

namespace RocketseatAuction.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : RockeatseatAuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer([FromRoute] int itemId, [FromBody] RequestCreateOffer request, [FromServices] CreateOfferUseCase useCase)
    {
        var id = useCase.Execute(itemId, request);

        return Created("", id);
    }
}

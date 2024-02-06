using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public Auction? Execute() 
    {
        var repository = new RocketseatAuctionDbContext();

        var today = DateTime.Now.AddDays(-10);

        return repository
            .Auctions
            .Include(x => x.Items)
            .FirstOrDefault(x => today >= x.Starts && today <= x.Ends);
    }
}

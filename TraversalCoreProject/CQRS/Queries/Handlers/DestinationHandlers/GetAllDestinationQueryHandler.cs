using DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using TraversalCoreProject.CQRS.Results.DestinationResults;

namespace TraversalCoreProject.CQRS.Queries.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }
        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                Id = x.Id,
                City = x.City,
                DayNight = x.DayNight,
                Capacity = x.Capacity,
                Price = x.Price
            }).AsNoTracking().ToList();
            return values;
        }
    }
}

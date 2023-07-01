using DataAccess.Concrete;
using TraversalCoreProject.CQRS.Commands.DestinationCommands;
using Entity.Concrete;

namespace TraversalCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class CreateDestinationCommandHandler
    {
        private readonly Context _context;

        public CreateDestinationCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(CreateDestinationCommand command)
        {
            _context.Destinations.Add(new Destination
            {
                City = command.City,
                Price = command.Price,
                Capacity = command.Capacity,
                Status =true,
                DayNight = command.DayNight
            });
            _context.SaveChanges();
        }
    }
}

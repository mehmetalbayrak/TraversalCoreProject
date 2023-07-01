using DataAccess.Concrete;
using MediatR;
using NuGet.Protocol.Plugins;
using TraversalCoreProject.CQRS.Commands.GuideCommands;
using Entity.Concrete;

namespace TraversalCoreProject.CQRS.Handlers.GuideHandlers
{
    public class CreateGuideQueryHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new Guide
            {
                Name = request.Name,
                Description = request.Description,
                Image = "image",
                Status = true
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}

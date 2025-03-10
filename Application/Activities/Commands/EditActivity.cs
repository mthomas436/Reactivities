using Domain;
using AutoMapper;
using MediatR;
using Persistence;
using Mapster;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Activities.Commands
{
    public class EditActivity
    {
        public class Command : IRequest
        {
            public required Activity Activity { get; set; }
        }

        public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
        {
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities
                    .FindAsync([request.Activity.Id], cancellationToken) 
                        ?? throw new Exception("Cannot find activity");

 
                context.Entry(activity).State = EntityState.Detached;

                activity  = request.Activity.Adapt<Activity>();
 
                context.Entry(activity).State = EntityState.Modified;
 
                await context.SaveChangesAsync(cancellationToken);
 
            }
        }
    }
}

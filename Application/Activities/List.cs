using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistance;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            // private readonly ILogger _logger;

            public Handler(DataContext context, ILogger<List> logger)
            {
                _context = context;
                // _logger = logger;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {

                //Kod nije pokazivayet rabotu CancellationToken (kogda client ostanovil request(zakril browser, ili sdelal cancel))
                // try
                // { 
                //     for (int i = 0; i < 10; i++)
                //     {
                //         cancellationToken.ThrowIfCancellationRequested();
                //         await Task.Delay(1000, cancellationToken);
                //         _logger.LogInformation($"Task {i} has completed");
                //     }
                // }
                // catch (Exception ex)
                // {
                //     _logger.LogInformation("Task was cancelled", ex.Message);                    
                // }

                return await _context.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}
using MarsRovers.Contracts;
using MarsRovers.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<IProcessInstructions, ProcessInstructions>()
            .AddScoped<ICompass, Compass>()
            .AddScoped<IMoveRover, MoveRover>();
    }
}

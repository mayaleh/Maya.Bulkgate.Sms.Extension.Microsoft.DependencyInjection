# Maya.BulkGate.Sms.Extension.Microsoft.DependencyInjection

[![NuGet](https://img.shields.io/nuget/v/Maya.BulkGate.Sms.Extension.Microsoft.DependencyInjection.svg)](https://www.nuget.org/packages/Maya.BulkGate.Sms.Extension.Microsoft.DependencyInjection)

## Get it

Install Maya.BulkGate.Sms.Extension.Microsoft.DependencyInjection from the package manager console:

```
PM> Install-Package Maya.BulkGate.Sms.Extension.Microsoft.DependencyInjection
```


## Usages

`````c#
...
using Maya.BulkGate.Sms.Extension.Microsof.DependencyInjection;

...

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMayaBulkGateSms(Configuration);
    }
}
`````
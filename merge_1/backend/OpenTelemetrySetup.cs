using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
public static class OpenTelemetrySetup
{
    public static void AddMyccaTelemetry(this IServiceCollection services)
    {
        services.AddOpenTelemetry()
            .ConfigureResource(r => r.AddService("MyCCA"))
            .WithMetrics(m =>
            {
                m.AddAspNetCoreInstrumentation()
                 .AddRuntimeInstrumentation()
                 .AddMeter("MyCCA.Sync")
                 .AddPrometheusExporter();
            });
    }
}
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ClickHouse.EntityFrameworkCore;
public class ClickHouseOptionsExtension : IDbContextOptionsExtension
{
    public DbContextOptionsExtensionInfo Info => new ExtensionInfo(this);

    public void ApplyServices(IServiceCollection services)
    {
        services.AddEntityFrameworkClickHouse();
    }

    public void Validate(IDbContextOptions options)
    {
    }

    private class ExtensionInfo : DbContextOptionsExtensionInfo
    {
        public ExtensionInfo(IDbContextOptionsExtension extension) : base(extension)
        {
        }

        public override string LogFragment => "using ClickHouse";

        public override long GetServiceProviderHashCode() => 0;

        public override void PopulateDebugInfo(IDictionary<string, string> debugInfo)
        {
            debugInfo["ClickHouse"] = "1";
        }

        public override bool ShouldUseSameServiceProvider(DbContextOptionsExtensionInfo other) => true;
    }
}
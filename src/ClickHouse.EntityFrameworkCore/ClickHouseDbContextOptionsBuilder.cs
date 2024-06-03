using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using Microsoft.EntityFrameworkCore;

namespace ClickHouse.EntityFrameworkCore;
public class ClickHouseDbContextOptionsBuilder : RelationalDbContextOptionsBuilder<ClickHouseDbContextOptionsBuilder, ClickHouseOptionsExtension>
{
    public ClickHouseDbContextOptionsBuilder(DbContextOptionsBuilder optionsBuilder)
        : base(optionsBuilder)
    {
    }

    public ClickHouseDbContextOptionsBuilder UseClickHouse(string connectionString)
    {
        ((IDbContextOptionsBuilderInfrastructure)this).AddOrUpdateExtension(GetOrCreateExtension().WithConnectionString(connectionString));
        return this;
    }

    protected override ClickHouseOptionsExtension GetOrCreateExtension()
    {
        var existing = OptionsBuilder.Options.FindExtension<ClickHouseOptionsExtension>();
        return existing ?? new ClickHouseOptionsExtension();
    }
}
using System;
using Microsoft.Extensions.Logging;
using SchoolAut0mater.PowerSchoolService.EntityFrameworkCore;
using SchoolAut0mater.Shared.Hosting.Microservices.DbMigrations.EfCore;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace SchoolAut0mater.PowerSchoolService.DbMigrations;

public class PowerSchoolServiceDatabaseMigrationChecker : PendingEfCoreMigrationsChecker<PowerSchoolServiceDbContext>
{
    public PowerSchoolServiceDatabaseMigrationChecker(
        ILoggerFactory loggerFactory,
        IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant,
        IDistributedEventBus distributedEventBus,
        IAbpDistributedLock abpDistributedLock)
        : base(
            loggerFactory,
            unitOfWorkManager,
            serviceProvider,
            currentTenant,
            distributedEventBus,
            abpDistributedLock,
            PowerSchoolServiceDbProperties.ConnectionStringName)
    {

    }
}

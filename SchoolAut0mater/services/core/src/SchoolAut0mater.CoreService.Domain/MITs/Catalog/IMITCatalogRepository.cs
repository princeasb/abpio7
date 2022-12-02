using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SchoolAut0mater.CoreService.MITs.Catalog
{
    public interface IMITCatalogRepository : IRepository<MITCatalog, int>
    {
        Task<List<MITCatalog>> GetListAsync(
            string filterText = null,
            // string parentCatalogCode = null,
            // List<string> linkedFeatures = null,
            // bool? isFactory = null,
            // bool? isActive = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            // string parentCatalogCode = null,
            // List<string> linkedFeatures = null,
            // bool? isFactory = null,
            // bool? isActive = null,
            CancellationToken cancellationToken = default);
    }
}
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SchoolAut0mater.CoreService.MITs.Item
{
    public interface IMITItemRepository : IRepository<MITItem, int>
    {
        Task<MITItemWithNavigationProperties> GetWithNavigationPropertiesAsync(
    int id,
    CancellationToken cancellationToken = default
);

        Task<List<MITItemWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string code = null,
            string name = null,
            string databaseValue = null,
            string displayValue = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            bool? isFactory = null,
            bool? isActive = null,
            string mITCatalogCode = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<MITItem>> GetListAsync(
            string filterText = null,
            string code = null,
            string name = null,
            string databaseValue = null,
            string displayValue = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            bool? isFactory = null,
            bool? isActive = null,
            string mITCatalogCode = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string code = null,
            string name = null,
            string databaseValue = null,
            string displayValue = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            bool? isFactory = null,
            bool? isActive = null,
            string mITCatalogCode = null,
            CancellationToken cancellationToken = default);
    }
}
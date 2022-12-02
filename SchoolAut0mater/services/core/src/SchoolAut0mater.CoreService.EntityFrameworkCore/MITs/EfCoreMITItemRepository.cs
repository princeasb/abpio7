using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using SchoolAut0mater.CoreService.EntityFrameworkCore;
using SchoolAut0mater.CoreService.MITs.Item;

namespace SchoolAut0mater.CoreService.MITs
{
    public class EfCoreMITItemRepository : EfCoreRepository<CoreServiceDbContext, MITItem, int>, IMITItemRepository
    {
        public EfCoreMITItemRepository(IDbContextProvider<CoreServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<MITItemWithNavigationProperties> GetWithNavigationPropertiesAsync(int id, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();

            return (await GetDbSetAsync())
                .Where(b => b.Id == id)
                .Select(mITItem => new MITItemWithNavigationProperties
                {
                    MITItem = mITItem,
                    MITCatalog = dbContext.MITCatalogs.FirstOrDefault(c => c.Id == mITItem.MITCatalogId)
                }).FirstOrDefault();
        }

        public async Task<List<MITItemWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, code, name, databaseValue, displayValue, sortOrderMin, sortOrderMax, isFactory, isActive, mITCatalogCode);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? MITItemConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<MITItemWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from mITItem in (await GetDbSetAsync())
                   join mITCatalog in (await GetDbContextAsync()).MITCatalogs on mITItem.MITCatalogId equals mITCatalog.Id into mITCatalogs
                   from mITCatalog in mITCatalogs.DefaultIfEmpty()

                   select new MITItemWithNavigationProperties
                   {
                       MITItem = mITItem,
                       MITCatalog = mITCatalog
                   };
        }

        protected virtual IQueryable<MITItemWithNavigationProperties> ApplyFilter(
            IQueryable<MITItemWithNavigationProperties> query,
            string filterText,
            string code = null,
            string name = null,
            string databaseValue = null,
            string displayValue = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            bool? isFactory = null,
            bool? isActive = null,
            string mITCatalogCode = null)
        {
            int? mITCatalogId = null;
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e =>
                    e.MITItem.Code.Contains(filterText) ||
                    e.MITItem.Name.Contains(filterText) ||
                    e.MITItem.DatabaseValue.Contains(filterText) ||
                    e.MITItem.DisplayValue.Contains(filterText)
                )
                .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.MITItem.Code.Contains(code))
                .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.MITItem.Name.Contains(name))
                .WhereIf(!string.IsNullOrWhiteSpace(databaseValue), e => e.MITItem.DatabaseValue.Contains(databaseValue))
                .WhereIf(!string.IsNullOrWhiteSpace(displayValue), e => e.MITItem.DisplayValue.Contains(displayValue))
                .WhereIf(sortOrderMin.HasValue, e => e.MITItem.SortOrder >= sortOrderMin.Value)
                .WhereIf(sortOrderMax.HasValue, e => e.MITItem.SortOrder <= sortOrderMax.Value)
                .WhereIf(isFactory.HasValue, e => e.MITItem.IsFactory == isFactory)
                .WhereIf(isActive.HasValue, e => e.MITItem.IsActive == isActive)
                .WhereIf(mITCatalogId != null, e => e.MITCatalog != null && e.MITCatalog.Id == mITCatalogId);
        }

        public async Task<List<MITItem>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, code, name, databaseValue, displayValue, sortOrderMin, sortOrderMax, isFactory, isActive);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? MITItemConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, code, name, databaseValue, displayValue, sortOrderMin, sortOrderMax, isFactory, isActive, mITCatalogCode);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<MITItem> ApplyFilter(
            IQueryable<MITItem> query,
            string filterText,
            string code = null,
            string name = null,
            string databaseValue = null,
            string displayValue = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            bool? isFactory = null,
            bool? isActive = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => 
                    e.Code.Contains(filterText) || 
                    e.Name.Contains(filterText) || 
                    e.DatabaseValue.Contains(filterText) || 
                    e.DisplayValue.Contains(filterText)
                )
                .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.Code.Contains(code))
                .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                .WhereIf(!string.IsNullOrWhiteSpace(databaseValue), e => e.DatabaseValue.Contains(databaseValue))
                .WhereIf(!string.IsNullOrWhiteSpace(displayValue), e => e.DisplayValue.Contains(displayValue))
                .WhereIf(sortOrderMin.HasValue, e => e.SortOrder >= sortOrderMin.Value)
                .WhereIf(sortOrderMax.HasValue, e => e.SortOrder <= sortOrderMax.Value)
                .WhereIf(isFactory.HasValue, e => e.IsFactory == isFactory)
                .WhereIf(isActive.HasValue, e => e.IsActive == isActive);
        }

    }
}
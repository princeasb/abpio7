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

namespace SchoolAut0mater.CoreService.MITs
{
    public class EfCoreMITCatalogRepository : EfCoreRepository<CoreServiceDbContext, MITCatalog, int>, IMITCatalogRepository
    {
        public EfCoreMITCatalogRepository(IDbContextProvider<CoreServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<MITCatalog>> GetListAsync(
            string filterText = null,
            string code = null,
            string name = null,
            List<string> linkedFeatures = null,
            string parentCatalogCode = null,
            bool? isFactory = null,
            bool? isActive = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, code, name, linkedFeatures, parentCatalogCode, isFactory, isActive);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? MITCatalogConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string code = null,
            string name = null,
            List<string> linkedFeatures = null,
            string parentCatalogCode = null,
            bool? isFactory = null,
            bool? isActive = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, code, name, linkedFeatures, parentCatalogCode, isFactory, isActive);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<MITCatalog> ApplyFilter(
            IQueryable<MITCatalog> query,
            string filterText,
            string code = null,
            string name = null,
            List<string> linkedFeatures = null,
            string parentCatalogCode = null,
            bool? isFactory = null,
            bool? isActive = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.ParentCatalogCode.Contains(filterText) || e.Code.Contains(filterText) || e.Name.Contains(filterText) || e.DisplayName.Contains(filterText) || e.LinkedFeatures.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(parentCatalogCode), e => e.ParentCatalogCode.Contains(parentCatalogCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.Code.Contains(code))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))                    
                    // .WhereIf(linkedFeatures!=null&& linkedFeatures.Count>1, e => e.LinkedFeatures.Contains(linkedFeatures))
                    .WhereIf(isFactory.HasValue, e => e.IsFactory == isFactory)
                    .WhereIf(isActive.HasValue, e => e.IsActive == isActive);
        }

    }
}
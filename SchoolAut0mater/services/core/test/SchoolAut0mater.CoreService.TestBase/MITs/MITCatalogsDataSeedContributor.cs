using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using SchoolAut0mater.CoreService.MITs;
using System.Collections.Generic;

namespace SchoolAut0mater.CoreService.MITs
{
    public class MITCatalogsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IMITCatalogRepository _mITCatalogRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public MITCatalogsDataSeedContributor(IMITCatalogRepository mITCatalogRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _mITCatalogRepository = mITCatalogRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded) { return; }

            await _mITCatalogRepository.InsertAsync(new MITCatalog
            (
                code: "d10fc6e16f164871a9e3",
                name: "d5de6dc1e41f42c2953568952e5ce7b40476ff72cf164aeab118f4778e80ddd0df0e8339c64c46a08c54524aab28c7da9ce1",
                linkedFeatures: new List<string> { "*" },
                parentCatalogCode: "826afe6f1241435cb893",
                isFactory: true,
                isActive: true
            ));

            await _mITCatalogRepository.InsertAsync(new MITCatalog
            (
                code: "d8e6ea4429244398a5ea",
                name: "3023d669b2064244985db5fbea8526bc4a8cc65411504c72abddc1178c789eb7d9793c87cb734db19192fb0101ec4966b93f",
                linkedFeatures: new List<string> { "*" },
                parentCatalogCode: "05cb2101668f4b2a870d",
                isFactory: true,
                isActive: true
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}
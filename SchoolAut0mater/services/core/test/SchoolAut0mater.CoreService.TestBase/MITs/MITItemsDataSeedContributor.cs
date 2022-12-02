using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using SchoolAut0mater.CoreService.MITs.Item;

namespace SchoolAut0mater.CoreService.MITs
{
    public class MITItemsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IMITItemRepository _mITItemRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly MITCatalogsDataSeedContributor _mITCatalogsDataSeedContributor;

        public MITItemsDataSeedContributor(IMITItemRepository mITItemRepository, IUnitOfWorkManager unitOfWorkManager, MITCatalogsDataSeedContributor mITCatalogsDataSeedContributor)
        {
            _mITItemRepository = mITItemRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _mITCatalogsDataSeedContributor = mITCatalogsDataSeedContributor;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _mITCatalogsDataSeedContributor.SeedAsync(context);

            await _mITItemRepository.InsertAsync(new MITItem
            (
                code: ".qh",
                name: "].4^q_.O.  67T0.5zz_05",
                databaseValue: "] __c ",
                displayValue: " ",
                sortOrder: 1208948099,
                isFactory: true,
                isActive: true,
                mITCatalogId: 1
            ));

            await _mITItemRepository.InsertAsync(new MITItem
            (
                code: ".eTb.c1P--.iP9cW",
                name: ".0.Y^^I56",
                databaseValue: "^.K",
                displayValue: "  X^mb",
                sortOrder: 461153089,
                isFactory: true,
                isActive: true,
                mITCatalogId: 2
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}
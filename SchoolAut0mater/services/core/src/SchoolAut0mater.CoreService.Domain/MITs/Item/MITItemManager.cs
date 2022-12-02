using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace SchoolAut0mater.CoreService.MITs.Item
{
    public class MITItemManager : DomainService
    {
        private readonly IMITItemRepository _mITItemRepository;

        public MITItemManager(IMITItemRepository mITItemRepository)
        {
            _mITItemRepository = mITItemRepository;
        }

        public async Task<MITItem> CreateAsync(
            int mITCatalogId, 
            string code, 
            string name, 
            string databaseValue, 
            string displayValue, 
            int? sortOrder = null, 
            bool? isFactory = null, 
            bool? isActive = null
        )
        {
            Check.NotNull(mITCatalogId, nameof(mITCatalogId));
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), MITItemConsts.CodeMaxLength, MITItemConsts.CodeMinLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), MITItemConsts.NameMaxLength, MITItemConsts.NameMinLength);
            Check.NotNullOrWhiteSpace(databaseValue, nameof(databaseValue));
            Check.Length(databaseValue, nameof(databaseValue), MITItemConsts.DatabaseValueMaxLength, MITItemConsts.DatabaseValueMinLength);
            Check.NotNullOrWhiteSpace(displayValue, nameof(displayValue));
            Check.Length(displayValue, nameof(displayValue), MITItemConsts.DisplayValueMaxLength, MITItemConsts.DisplayValueMinLength);

            var mITItem = new MITItem(
                mITCatalogId, 
                code, 
                name, 
                databaseValue, 
                displayValue, 
                sortOrder, 
                isFactory, 
                isActive
             );

            return await _mITItemRepository.InsertAsync(mITItem);
        }

        public async Task<MITItem> UpdateAsync(
            int id,
            // string code, 
            string name,
            string databaseValue, 
            string displayValue, 
            int? sortOrder = null, 
            bool? isActive = null, 
            [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), MITItemConsts.NameMaxLength, MITItemConsts.NameMinLength);
            Check.NotNullOrWhiteSpace(databaseValue, nameof(databaseValue));
            Check.Length(databaseValue, nameof(databaseValue), MITItemConsts.DatabaseValueMaxLength, MITItemConsts.DatabaseValueMinLength);
            Check.NotNullOrWhiteSpace(displayValue, nameof(displayValue));
            Check.Length(displayValue, nameof(displayValue), MITItemConsts.DisplayValueMaxLength, MITItemConsts.DisplayValueMinLength);

            var mITItem = await _mITItemRepository.GetAsync(id);
            // mITItem.Code = code;
            mITItem.Name = name;
            mITItem.DatabaseValue = databaseValue;
            mITItem.DisplayValue = displayValue;
            mITItem.SortOrder = sortOrder;
            mITItem.IsActive = isActive;

            mITItem.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _mITItemRepository.UpdateAsync(mITItem);
        }

    }
}
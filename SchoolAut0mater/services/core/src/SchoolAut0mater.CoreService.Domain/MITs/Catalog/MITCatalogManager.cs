using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace SchoolAut0mater.CoreService.MITs.Catalog
{
    public class MITCatalogManager : DomainService
    {
        private readonly IMITCatalogRepository _mITCatalogRepository;

        public MITCatalogManager(IMITCatalogRepository mITCatalogRepository)
        {
            _mITCatalogRepository = mITCatalogRepository;
        }

        public async Task<MITCatalog> CreateAsync(
            string code,
            string name,
            [CanBeNull] List<string> linkedFeatures = null,
            [CanBeNull] string parentCatalogCode = null,
            [CanBeNull] bool isFactory = false,
            [CanBeNull] bool isActive = true
        )
        {
            Check.Length(parentCatalogCode, nameof(parentCatalogCode), MITCatalogConsts.ParentCatalogCodeMaxLength);
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), MITCatalogConsts.CodeMaxLength, MITCatalogConsts.CodeMinLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), MITCatalogConsts.NameMaxLength, MITCatalogConsts.NameMinLength);
            Check.Length(linkedFeatures.ToString(), nameof(linkedFeatures), MITCatalogConsts.LinkedFeaturesMaxLength, MITCatalogConsts.LinkedFeaturesMinLength);

            var mITCatalog = new MITCatalog(
                code,
                name,
                linkedFeatures,
                parentCatalogCode,
                isFactory,
                isActive
             );

            return await _mITCatalogRepository.InsertAsync(mITCatalog);
        }

        public async Task<MITCatalog> UpdateAsync(
            int id,
            string code,
            string name,
            [CanBeNull] List<string> linkedFeatures = null,
            [CanBeNull] string parentCatalogCode = null,
            [CanBeNull] bool isFactory = false,
            [CanBeNull] bool isActive = true,
            [CanBeNull] string concurrencyStamp = null
        )
        {
            linkedFeatures ??= new List<string> { "*" };
            Check.Length(parentCatalogCode, nameof(parentCatalogCode), MITCatalogConsts.ParentCatalogCodeMaxLength);
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), MITCatalogConsts.CodeMaxLength, MITCatalogConsts.CodeMinLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), MITCatalogConsts.NameMaxLength, MITCatalogConsts.NameMinLength);
            Check.Length(linkedFeatures.ToString(), nameof(linkedFeatures), MITCatalogConsts.LinkedFeaturesMaxLength, MITCatalogConsts.LinkedFeaturesMinLength);

            var mITCatalog = await _mITCatalogRepository.GetAsync(id);

            mITCatalog.Code = code;
            mITCatalog.Name = name;
            mITCatalog.LinkedFeatures = linkedFeatures;
            mITCatalog.ParentCatalogCode = parentCatalogCode;
            mITCatalog.IsFactory = isFactory;
            mITCatalog.IsActive = isActive;

            mITCatalog.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _mITCatalogRepository.UpdateAsync(mITCatalog);
        }

    }
}
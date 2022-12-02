using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using SchoolAut0mater.CoreService.MITs;
using SchoolAut0mater.CoreService.EntityFrameworkCore;
using Xunit;
using System.Collections.Generic;

namespace SchoolAut0mater.CoreService.MITs
{
    public class MITCatalogRepositoryTests : CoreServiceEntityFrameworkCoreTestBase
    {
        private readonly IMITCatalogRepository _mITCatalogRepository;

        public MITCatalogRepositoryTests()
        {
            _mITCatalogRepository = GetRequiredService<IMITCatalogRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _mITCatalogRepository.GetListAsync(
                    filterText: "826afe6f1241435cb893"
                // parentCatalogCode: "826afe6f1241435cb893",
                // linkedFeatures: new List<string> { "*" },
                // isFactory: true,
                // isActive: true
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(1);
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _mITCatalogRepository.GetCountAsync(
                    filterText: "826afe6f1241435cb893"
                // parentCatalogCode: "05cb2101668f4b2a870d",
                // linkedFeatures: new List<string> { "*" },                    
                // isFactory: true,
                // isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}
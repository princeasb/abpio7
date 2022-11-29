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
                    parentCatalogCode: "826afe6f1241435cb893",
                    code: "d10fc6e16f164871a9e3",
                    name: "d5de6dc1e41f42c2953568952e5ce7b40476ff72cf164aeab118f4778e80ddd0df0e8339c64c46a08c54524aab28c7da9ce1",
                    linkedFeatures: new List<string> { "*" },
                    isFactory: true,
                    isActive: true
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
                    parentCatalogCode: "05cb2101668f4b2a870d",
                    code: "d8e6ea4429244398a5ea",
                    name: "3023d669b2064244985db5fbea8526bc4a8cc65411504c72abddc1178c789eb7d9793c87cb734db19192fb0101ec4966b93f",
                    linkedFeatures: new List<string> { "*" },                    
                    isFactory: true,
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}
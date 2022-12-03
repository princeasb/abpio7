using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using SchoolAut0mater.CoreService.MITs;
using SchoolAut0mater.CoreService.EntityFrameworkCore;
using Xunit;

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
                    parentCatalogCode: "68ca7c25b3674aa4b4ee",
                    code: "3b3f58b69a314d04a239",
                    name: "02516f5326f747ddbe4e2b0bca8dac874d11951cd6984478806d87891b7134be4c67a08ba6234972a89c0bed1c011a7b635f",
                    displayName: "e9754f9cefc548138a8bbee9066964b0bd9d2346447d4cdaa5b903f0f802fac985473f72a27e4e0098451c722c1b847",
                    linkedFeatures: "3a85bd1d268f43eab778004296f0c4b2db331aac3f1340b8ae632832f252a009fe62515156b44f52aaa1bbce67582d74258b2ad92f46430d8d9b60f366bfe22301657311e08c4ed8a9302a8baa2da825f8593c04020346dcbbf983444c1662b8b8640144e64b47bc81b74e1ffddbb0fd684b438e17554c02901f70da02",
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
                    parentCatalogCode: "a0d051cbca124139ade4",
                    code: "94438a1303e5487383b1",
                    name: "23eeb68c72bf4dd3b3bbc19f6f039cb969bb41b40bd542f8bd727cd811f41818f70a4997d92740e7a3b2efc0c163dfc10793",
                    displayName: "1f49a1cd7ee5424796ab072201338a5fe39567d86f644a6cbcc8223d61fafce0e408bf964a044a1881e33d166005",
                    linkedFeatures: "c74f0615989a4b38ae3a258fdd38811f136eb06734dd4a3096cc88613a384bcbe065919dfb7b4131b6dbf6eaf3ac09712c31d93771d646e7a9dfd6afdecd8cec644e11bbdc204a608e7dfff1ef6b36768316f33188e44d6a9ce060222236d4a9b7cb238592064830ae61812c755fd02e91d97969360a4cfabb770e5bbb",
                    isFactory: true,
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}
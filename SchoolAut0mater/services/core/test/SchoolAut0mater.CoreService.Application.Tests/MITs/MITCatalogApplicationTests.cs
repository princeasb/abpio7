using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace SchoolAut0mater.CoreService.MITs
{
    public class MITCatalogsAppServiceTests : CoreServiceApplicationTestBase
    {
        private readonly IMITCatalogsAppService _mITCatalogsAppService;
        private readonly IRepository<MITCatalog, int> _mITCatalogRepository;

        public MITCatalogsAppServiceTests()
        {
            _mITCatalogsAppService = GetRequiredService<IMITCatalogsAppService>();
            _mITCatalogRepository = GetRequiredService<IRepository<MITCatalog, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _mITCatalogsAppService.GetListAsync(new GetMITCatalogsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == 1).ShouldBe(true);
            result.Items.Any(x => x.Id == 2).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _mITCatalogsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new MITCatalogCreateDto
            {
                ParentCatalogCode = "96e72a3cf48a4b648073",
                Code = "02c11f234cc544678573",
                Name = "92da0f8c05f444809c4bf6a6f977e1010a2aad6856ca47959ad54cb97bc0122b84e09d88fa9740db87039aaa24aed2beb347",
                DisplayName = "5e67f1c55d854984bd72998485bb662bfc0f1e5dcb814dde9098fe96c1331caebaa9fd5291724f658b5c639b40f068ad5c1",
                LinkedFeatures = "406d2c76a59b42228414e7ff72829f4f8a860c72a21c4b978d9882e66e42af2dd5eee2288bf847ec8962733abbb169323bfaf1f4c4fd41ab8d50bf8f45276991d789d2b2853a4922b4711e69f9de7e814ff220acd00e4ba5aeb48f267d476a41cebc08685ca94ec1aa43e5821c5834d3befa4286a9464bbd9d1029cc90",
                IsFactory = true,
                IsActive = true
            };

            // Act
            var serviceResult = await _mITCatalogsAppService.CreateAsync(input);

            // Assert
            var result = await _mITCatalogRepository.FindAsync(c => c.ParentCatalogCode == serviceResult.ParentCatalogCode);

            result.ShouldNotBe(null);
            result.ParentCatalogCode.ShouldBe("96e72a3cf48a4b648073");
            result.Code.ShouldBe("02c11f234cc544678573");
            result.Name.ShouldBe("92da0f8c05f444809c4bf6a6f977e1010a2aad6856ca47959ad54cb97bc0122b84e09d88fa9740db87039aaa24aed2beb347");
            result.DisplayName.ShouldBe("5e67f1c55d854984bd72998485bb662bfc0f1e5dcb814dde9098fe96c1331caebaa9fd5291724f658b5c639b40f068ad5c1");
            result.LinkedFeatures.ShouldBe("406d2c76a59b42228414e7ff72829f4f8a860c72a21c4b978d9882e66e42af2dd5eee2288bf847ec8962733abbb169323bfaf1f4c4fd41ab8d50bf8f45276991d789d2b2853a4922b4711e69f9de7e814ff220acd00e4ba5aeb48f267d476a41cebc08685ca94ec1aa43e5821c5834d3befa4286a9464bbd9d1029cc90");
            result.IsFactory.ShouldBe(true);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new MITCatalogUpdateDto()
            {
                ParentCatalogCode = "e9a7d5e778ff4541acfb",
                Code = "c237bbd14ecc4df0baaa",
                Name = "c942c5809efd4285ab4632b72ad6afb65efa8e89df3e437da468d36076fe2ca5845959a791144f5d9ff9e0d0f99bcf3b14e6",
                DisplayName = "9437280d47bc4e009aee2076a12322d2e37",
                LinkedFeatures = "46c5a1bd6a594d38b2dcbc8ad75ad1739d6ddaa7d55d414c8c42d9ec501fef60ee0ec49fab9d4860b27783931e667d9690dea8afddd640699c3c04349ff19652ac58b226c7e44f3dabc3080d02e97cd91d656f43605542e885b3a534fa9ccbac99aa7f1ddb314c6cb716c5789e0f4f2f8cf939354ac04a0bb823e39d9f",
                IsFactory = true,
                IsActive = true
            };

            // Act
            var serviceResult = await _mITCatalogsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _mITCatalogRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ParentCatalogCode.ShouldBe("e9a7d5e778ff4541acfb");
            result.Code.ShouldBe("c237bbd14ecc4df0baaa");
            result.Name.ShouldBe("c942c5809efd4285ab4632b72ad6afb65efa8e89df3e437da468d36076fe2ca5845959a791144f5d9ff9e0d0f99bcf3b14e6");
            result.DisplayName.ShouldBe("9437280d47bc4e009aee2076a12322d2e37");
            result.LinkedFeatures.ShouldBe("46c5a1bd6a594d38b2dcbc8ad75ad1739d6ddaa7d55d414c8c42d9ec501fef60ee0ec49fab9d4860b27783931e667d9690dea8afddd640699c3c04349ff19652ac58b226c7e44f3dabc3080d02e97cd91d656f43605542e885b3a534fa9ccbac99aa7f1ddb314c6cb716c5789e0f4f2f8cf939354ac04a0bb823e39d9f");
            result.IsFactory.ShouldBe(true);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _mITCatalogsAppService.DeleteAsync(1);

            // Assert
            var result = await _mITCatalogRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}
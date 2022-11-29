using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;
using System.Collections.Generic;

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

        // [Fact]
        // public async Task CreateAsync()
        // {
        //     // Arrange
        //     var input = new MITCatalogCreateDto
        //     {
        //         Code = "da9384e37ef44e84a4a7",
        //         Name = "c3dcbb4f787e41d5924bce4222981d33b83881e8e20345918eb6963a71352bc6445360ac1cfa4dccad7a253c2cf2acbcc92b",
        //         LinkedFeatures = new List<string> { "*" },
        //         ParentCatalogCode = "d12b031a861d40f2814c",
        //         IsFactory = true,
        //         IsActive = true
        //     };
           
        //     // Act
        //     var serviceResult = await _mITCatalogsAppService.CreateAsync(input);
           
        //     // Assert
        //     var result = await _mITCatalogRepository.FindAsync(c => c.ParentCatalogCode == serviceResult.ParentCatalogCode);
           
        //     result.ShouldNotBe(null);
        //     result.ParentCatalogCode.ShouldBe("d12b031a861d40f2814c");
        //     result.Code.ShouldBe("da9384e37ef44e84a4a7");
        //     result.Name.ShouldBe("c3dcbb4f787e41d5924bce4222981d33b83881e8e20345918eb6963a71352bc6445360ac1cfa4dccad7a253c2cf2acbcc92b");
        //     result.DisplayName.ShouldBe("3f17d06959c24786ae08c586e6f90ba71a269d19ca1b4700acd");
        //     result.LinkedFeatures.ShouldBe(new List<string> { "*" });
        //     result.IsFactory.ShouldBe(true);
        //     result.IsActive.ShouldBe(true);
        // }
           
        // [Fact]
        // public async Task UpdateAsync()
        // {
        //     // Arrange
        //     var input = new MITCatalogUpdateDto()
        //     {
        //         Code = "8d24a88ed4704816bac2",
        //         Name = "bbad36b5758740949c87fb8b6c21c8f8ba63946830ed4436828bf5c7f33e3c55126b9399175b4e3581d26022a6511b5a6a37",
        //         DisplayName = "25afa51494ad409faa461ef27a488b7291d8871f218743",
        //         LinkedFeatures = new List<string> { "*" },
        //         ParentCatalogCode = "65fcc7d8eab444b0a82c",
        //         IsFactory = true,
        //         IsActive = true
        //     };
           
        //     // Act
        //     var serviceResult = await _mITCatalogsAppService.UpdateAsync(1, input);
           
        //     // Assert
        //     var result = await _mITCatalogRepository.FindAsync(c => c.Id == serviceResult.Id);
           
        //     result.ShouldNotBe(null);
        //     result.ParentCatalogCode.ShouldBe("65fcc7d8eab444b0a82c");
        //     result.Code.ShouldBe("8d24a88ed4704816bac2");
        //     result.Name.ShouldBe("bbad36b5758740949c87fb8b6c21c8f8ba63946830ed4436828bf5c7f33e3c55126b9399175b4e3581d26022a6511b5a6a37");
        //     result.DisplayName.ShouldBe("25afa51494ad409faa461ef27a488b7291d8871f218743");
        //     result.LinkedFeatures.ShouldBe(new List<string> { "*" });
        //     result.IsFactory.ShouldBe(true);
        //     result.IsActive.ShouldBe(true);
        // }
           
        // [Fact]
        // public async Task DeleteAsync()
        // {
        //     // Act
        //     await _mITCatalogsAppService.DeleteAsync(1);
           
        //     // Assert
        //     var result = await _mITCatalogRepository.FindAsync(c => c.Id == 1);
           
        //     result.ShouldBeNull();
        // }
    }
}
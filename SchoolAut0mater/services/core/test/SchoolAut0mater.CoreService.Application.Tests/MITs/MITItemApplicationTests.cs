using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;
using SchoolAut0mater.CoreService.MITs.Item;

namespace SchoolAut0mater.CoreService.MITs
{
    public class MITItemsAppServiceTests : CoreServiceApplicationTestBase
    {
        private readonly IMITItemsAppService _mITItemsAppService;
        private readonly IRepository<MITItem, int> _mITItemRepository;

        public MITItemsAppServiceTests()
        {
            _mITItemsAppService = GetRequiredService<IMITItemsAppService>();
            _mITItemRepository = GetRequiredService<IRepository<MITItem, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _mITItemsAppService.GetListAsync(new GetMITItemsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.MITItem.Id == 1).ShouldBe(true);
            result.Items.Any(x => x.MITItem.Id == 2).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _mITItemsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new MITItemCreateDto
            {
                Code = "e..X3",
                Name = "a D. .]m g",
                DatabaseValue = "6] ",
                DisplayValue = "T",
                SortOrder = 1960242219,
                IsFactory = true,
                IsActive = true,
                MITCatalogId = 1
            };

            // Act
            var serviceResult = await _mITItemsAppService.CreateAsync(input);

            // Assert
            var result = await _mITItemRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("e..X3");
            result.Name.ShouldBe("a D. .]m g");
            result.DatabaseValue.ShouldBe("6] ");
            result.DisplayValue.ShouldBe("T");
            result.SortOrder.ShouldBe(1960242219);
            result.IsFactory.ShouldBe(true);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new MITItemUpdateDto()
            {
                Name = "b.Z.",
                DatabaseValue = "  ",
                DisplayValue = "p",
                SortOrder = 527112257,
                IsActive = true
            };

            // Act
            var serviceResult = await _mITItemsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _mITItemRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("121X1bt6sPS7WGT-");
            result.Name.ShouldBe("b.Z.");
            result.DisplayName.ShouldBe("3ca4b50b21544f1f9f0c325e1503d5b596d");
            result.DatabaseValue.ShouldBe("  ");
            result.DisplayValue.ShouldBe("p");
            result.SortOrder.ShouldBe(527112257);
            result.IsFactory.ShouldBe(true);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _mITItemsAppService.DeleteAsync(1);

            // Assert
            var result = await _mITItemRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using SchoolAut0mater.CoreService.EntityFrameworkCore;
using Xunit;
using SchoolAut0mater.CoreService.MITs.Item;

namespace SchoolAut0mater.CoreService.MITs
{
    public class MITItemRepositoryTests : CoreServiceEntityFrameworkCoreTestBase
    {
        private readonly IMITItemRepository _mITItemRepository;

        public MITItemRepositoryTests()
        {
            _mITItemRepository = GetRequiredService<IMITItemRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _mITItemRepository.GetListAsync(
                    code: ".qh",
                    name: "].4^q_.O.  67T0.5zz_05",
                    databaseValue: "] __c ",
                    displayValue: " ",
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
                var result = await _mITItemRepository.GetCountAsync(
                    code: ".eTb.c1P--.iP9cW",
                    name: ".0.Y^^I56",
                    databaseValue: "^.K",
                    displayValue: "  X^mb",
                    isFactory: true,
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}
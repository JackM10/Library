using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;
using LibrarryCrudOps.DAL.Services;
using LibrarryCrudOps.Models;

namespace LibraryTests.PerformanceTests
{
    public class LibraryInRamPerfomanceTests
    {
        [Test]
        public async Task ListReturnAllValuesFromRepoLessThan100ms()
        {
            //Arrange & Act
            var benchSummary = BenchmarkRunner.Run<LibraryInRamBenchmarks>();

            //get previous measurments:
            var previousMeasurments = new List<PerformanceMeasurment>(); //await GetPreviousMeasurments();

            await SaveCurrentMeasurments();

            //If amount of measurments is small, warn about it
            var isMoreMeasurmentsRequired = DoWeHaveEnoughOfData(previousMeasurments);

            while (isMoreMeasurmentsRequired)
            {
                benchSummary = BenchmarkRunner.Run<LibraryInRamBenchmarks>();
                //previousMeasurments = await GetPreviousMeasurments();
                isMoreMeasurmentsRequired = DoWeHaveEnoughOfData(previousMeasurments);
            }

            //Assert
            Assert.True(benchSummary.Reports[0].ResultStatistics.Mean < 100);

            bool DoWeHaveEnoughOfData(List<PerformanceMeasurment> data)
            {
                if (data.Count <= 50)
                {
                    return true;
                }
                return false;
            }

            async Task SaveCurrentMeasurments()
            {
                //ToDo:
                //await _context.Measurments.AddAsync(new PerformanceMeasurment { Median = benchSummary.Reports[0].ResultStatistics.Mean, TestName = nameof(ListReturnAllValuesFromRepoLessThan100ms) });
                //await _context.SaveChangesAsync();
            }

            //async Task<List<PerformanceMeasurment>> GetPreviousMeasurments() =>
            //    await _context.Measurments.Where(m => m.TestName.Equals(nameof(ListReturnAllValuesFromRepoLessThan100ms))).ToListAsync();
        }
    }

    public class LibraryInRamBenchmarks
    {
        private LibraryInRAMRepository _libraryInRAMRepository;
        private Book _testBook;

        [SetUp]
        public void Setup()
        {
            _testBook = new Book
            {
                Authors = new string[] { "testAuth" },
                Title = "testTitle",
                DateOfPublication = DateTime.Now.AddDays(-5),
                Id = Guid.NewGuid()
            };
        }

        [Benchmark]
        public async Task CreateBook_CreatingProperBook_SuccessResponse()
        {
            await _libraryInRAMRepository.CreateAsync(_testBook);
            var resultFromGet = await _libraryInRAMRepository.GetByIdAsync(_testBook.Id);
            await _libraryInRAMRepository.DeleteAsync(_testBook.Id);
            var nullResultAfterCleaning = await _libraryInRAMRepository.GetByIdAsync(_testBook.Id);

            Assert.NotNull(resultFromGet);
            Assert.IsNull(nullResultAfterCleaning);
        }
    }
}
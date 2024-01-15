using FluentAssertions;
using RedingtonTask.Domain.Entities;
using RedingtonTask.Domain.Services;

namespace RedingtonTask.Tests
{
    public class CalculationServiceTests
    {
        private readonly CalculationService _sut;

        public CalculationServiceTests()
        {
            _sut = new CalculationService();
        }

        [Theory]
        [InlineData(0, 0.25)]
        [InlineData(1, 0.75)]
        public void CalculateReturnsCorrectValue(int type, decimal result)
        {
            // Arrange
            var probability = new Probability
            {
                FirstValue = 0.5m,
                SecondValue = 0.5m,
                FunctionType = (FunctionType)type,
            };

            var actual = _sut.Calculate(probability);

            actual.Should().Be(result);
        }
    }
}

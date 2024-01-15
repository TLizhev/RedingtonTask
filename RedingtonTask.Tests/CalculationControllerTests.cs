using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RedingtonTask.Domain.Entities;
using RedingtonTask.Domain.Services;
using RedingtonTask.Web.Controllers;

namespace RedingtonTask.Tests
{
    public class CalculationControllerTests
    {
        private readonly CalculationController _sut;
        private readonly Mock<ICalculationService> _service;

        public CalculationControllerTests()
        {
            _service = new Mock<ICalculationService>();
            _sut = new CalculationController(_service.Object);
        }

        [Fact]
        public void CreateReturnsRedirectToIActionResult()
        {
            // Arrange
            var probability = new Probability
            {
                FirstValue = 0.5m,
                SecondValue = 0.5m,
                FunctionType = FunctionType.CombinedWith,
                Result = 0.25m,
            };

            // Act
            var result = _sut.Create(probability);

            // Assert
            result.Should().BeOfType<RedirectToActionResult>();
        }
    }
}

using System.ComponentModel;
using RedingtonTask.Domain.Entities;

namespace RedingtonTask.Domain.Services
{
    public class CalculationService : ICalculationService
    {
        public decimal Calculate(Probability probability)
        {
            // Add log.
            return probability.Result = probability.FunctionType switch
            {
                FunctionType.CombinedWith =>
                    probability.FirstValue * probability.SecondValue,
                FunctionType.Either =>
                    probability.FirstValue + probability.SecondValue - probability.FirstValue * probability.SecondValue,
                _ => throw new InvalidEnumArgumentException("A function with that name does not exist.")
            };
        }
    }
}

using RedingtonTask.Domain.Entities;

namespace RedingtonTask.Domain.Services
{
    public interface ICalculationService
    {
        public decimal Calculate(Probability probability);
    }
}

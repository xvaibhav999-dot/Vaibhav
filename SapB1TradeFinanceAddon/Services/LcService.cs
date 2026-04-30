using SapB1TradeFinanceAddon.Data;

namespace SapB1TradeFinanceAddon.Services
{
    public class LcService
    {
        private readonly TradeFinanceRepository _repository;

        public LcService(TradeFinanceRepository repository)
        {
            _repository = repository;
        }

        public void Create(LetterOfCredit lc)
        {
            _repository.SaveLc(lc);
        }
    }
}

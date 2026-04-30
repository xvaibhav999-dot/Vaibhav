using SapB1TradeFinanceAddon.Data;

namespace SapB1TradeFinanceAddon.Services
{
    public class BgService
    {
        private readonly TradeFinanceRepository _repository;

        public BgService(TradeFinanceRepository repository)
        {
            _repository = repository;
        }

        public void Create(BankGuarantee bg)
        {
            _repository.SaveBg(bg);
        }
    }
}

using SecondLab;

namespace  SecondLab.Factories;

public interface IAccountFactory
{
    BankAccountBuilder CreateBankAccount(string accountId, uint chipsAmount);
    
    CasinoAccountBuilder CreateCasinoAccount(string accountId, uint chipsAmount);
}
using SecondLab;
namespace SecondLab.Factories;

public class AccountFactory: IAccountFactory
{
    public BankAccountBuilder CreateBankAccount(string accountId, uint chipsAmount)
    {
        BankAccountBuilder builder = new();
        builder.AccountId(accountId);
        builder.MoneyAmount(chipsAmount);
        return builder;
    }

    public CasinoAccountBuilder CreateCasinoAccount(string accountId, uint chipsAmount)
    {
        CasinoAccountBuilder builder = new();
        builder.AccountId(accountId);
        builder.ChipsAmount(chipsAmount);
        return builder;
    }

}
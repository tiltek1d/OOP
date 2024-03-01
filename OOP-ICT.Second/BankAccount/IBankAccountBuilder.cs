namespace SecondLab;

public interface IBankAccountBuilder
{
    void AccountId(string accountId);
    void MoneyAmount(uint moneyAmount);

    BankAccount CreateBankAccount();
}
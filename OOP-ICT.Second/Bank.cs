namespace SecondLab;
using SecondLab.Factories;
using SecondLab.Exceptions;
public class Bank
{
    private List<BankAccount> _bankAccounts;
    
    public Bank()
    {
        _bankAccounts = new List<BankAccount>();
    }

    public void CreateBankAccount(string accountId, uint moneyAmount)
    {
        BankAccountBuilder builder = new AccountFactory().CreateBankAccount(accountId, moneyAmount);
        BankAccountDirector director = new (builder);
        director.Construct(accountId, moneyAmount);
        _bankAccounts.Add(builder.CreateBankAccount());
    }

    public void DepositMoney(uint moneyAmount, string accountId)
    {
        BankAccount bankAccount = _bankAccounts.Find(account => account.AccountId == accountId)!;

        if (_bankAccounts.Contains(bankAccount))
        {
            bankAccount.DepositMoney(moneyAmount);
        }
        else
        {
            throw new IncorrectBankAccountIdException(accountId);
        }
    }
    
    public void WithdrawalMoney(uint moneyAmount, string accountId)
    {
        BankAccount bankAccount = _bankAccounts.Find(account => account.AccountId == accountId)!;
        if (_bankAccounts.Contains(bankAccount) && WithdrawalSufficiencyCheck(moneyAmount, accountId))
        {
            bankAccount.WithdrawalMoney(moneyAmount);
        }

        if (!_bankAccounts.Contains(bankAccount))
        {
            throw new IncorrectBankAccountIdException(accountId);
        }

        if (!WithdrawalSufficiencyCheck(moneyAmount, accountId))
        {
            throw new NotEnoughMoneyException(moneyAmount - bankAccount.MoneyAmount);
        }
    }
    
    private bool WithdrawalSufficiencyCheck(uint moneyAmount, string accountId)
    {
        BankAccount bankAccount = _bankAccounts.Find(account => account.AccountId == accountId)!;

        if (_bankAccounts.Contains(bankAccount))
        {
            return bankAccount.MoneyAmount >= moneyAmount;
        }

        return false;
    }

    public uint GetMoneyBalance(string accountId)
    {
        if (_bankAccounts.Contains(_bankAccounts.Find(account => account.AccountId == accountId)!))
        {
            return _bankAccounts.Find(account => account.AccountId == accountId)!.MoneyAmount;
        }
        else
        {
            throw new IncorrectBankAccountIdException(accountId);
        }
    }

    public BankAccount GetBankAccount(string accountId)
    {
        BankAccount bankAccount = _bankAccounts.Find(account => account.AccountId == accountId)!;

        if (_bankAccounts.Contains(bankAccount))
        {
            return bankAccount;
        }
        else
        {
            throw new IncorrectBankAccountIdException(accountId);
        }
    }
}
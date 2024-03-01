using SecondLab;
using SecondLab.Exceptions;
using SecondLab.Factories;

namespace SecondLab;

public class BlackjackCasino
{
    private List<CasinoAccount> _casinoAccounts;

    public BlackjackCasino()
    {
        _casinoAccounts = new List<CasinoAccount>();
    }

    public void CreateCasinoAccount(string accountId, uint chipsAmount)
    {
        CasinoAccountBuilder builder = new AccountFactory().CreateCasinoAccount(accountId, chipsAmount);
        CasinoAccountDirector director = new (builder);
        director.Construct(accountId, chipsAmount);
        _casinoAccounts.Add(builder.CreateCasinoAccount());
    }
    
    public void AccrualOfWin(uint chipsAmount, string accountId)
    {
        CasinoAccount casinoAccount = _casinoAccounts.Find(account => account.AccountId == accountId)!;

        if (_casinoAccounts.Contains(casinoAccount))
        {
            casinoAccount.AccrueWin(chipsAmount);
        }
        else
        {
            throw new IncorrectCasinoAccountIdException(accountId);
        }
    }
    
    public void AccrualOfLose(uint chipsAmount, string accountId)
    {
        CasinoAccount casinoAccount = _casinoAccounts.Find(account => account.AccountId == accountId)!;
        if (_casinoAccounts.Contains(casinoAccount) && BettingSufficiencyCheck(chipsAmount, accountId))
        {
            casinoAccount.AccrueLose(chipsAmount);
        }

        if (!_casinoAccounts.Contains(casinoAccount))
        {
            throw new IncorrectCasinoAccountIdException(accountId);
        }

        if (!BettingSufficiencyCheck(chipsAmount, accountId))
        {
            throw new NotEnoughChipsException(chipsAmount - casinoAccount.ChipsAmount);
        }
    }

    private bool BettingSufficiencyCheck(uint chipsAmount, string accountId)
    {
        CasinoAccount casinoAccount = _casinoAccounts.Find(account => account.AccountId == accountId)!;

        if (_casinoAccounts.Contains(casinoAccount))
        {
            return casinoAccount.ChipsAmount >= chipsAmount;
        }

        return false;
    }

    public uint GetChipsBalance(string accountId)
    {
        if (_casinoAccounts.Contains(_casinoAccounts.Find(account => account.AccountId == accountId)!))
        {
            return _casinoAccounts.Find(account => account.AccountId == accountId)!.ChipsAmount;
        }
        else
        {
            throw new IncorrectCasinoAccountIdException(accountId);
        }
    }

    public void AccrualBlackjack(string accountId, uint blackjackReward)
    {
        CasinoAccount casinoAccount = _casinoAccounts.Find(account => account.AccountId == accountId)!;
        if (_casinoAccounts.Contains(casinoAccount))
        {
            casinoAccount.AccrueWin(blackjackReward);
        }
        else
        {
            throw new IncorrectCasinoAccountIdException(accountId); 
        }
    }
    public CasinoAccount GetCasinoAccount(string accountId)
    {
        CasinoAccount casinoAccount = _casinoAccounts.Find(account => account.AccountId == accountId)!;

        if (_casinoAccounts.Contains(casinoAccount))
        {
            return casinoAccount;
        }
        else
        {
            throw new IncorrectCasinoAccountIdException(accountId);
        }
    }
    public void DepositChips(uint chipsAmount, string accountId)
    {
        CasinoAccount casinoAccount = _casinoAccounts.Find(account => account.AccountId == accountId)!;

        if (_casinoAccounts.Contains(casinoAccount))
        {
            casinoAccount.DepositChips(chipsAmount);
        }
        else
        {
            throw new IncorrectCasinoAccountIdException(accountId);
        }
    }
    public void WithdrawalChips(uint chipsAmount, string accountId)
    {
        CasinoAccount casinoAccount = _casinoAccounts.Find(account => account.AccountId == accountId)!;

        if (_casinoAccounts.Contains(casinoAccount))
        {
            casinoAccount.WithdrawalChips(chipsAmount);
        }
        else
        {
            throw new IncorrectCasinoAccountIdException(accountId);
        }
    }
    
}
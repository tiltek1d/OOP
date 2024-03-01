using SecondLab.Exceptions;

namespace SecondLab;

public class CasinoAccount
{
    public string AccountId { get; }
    public uint ChipsAmount { get; private set; }

    public CasinoAccount(string accountId, uint chipsAmount)
    {
        AccountId = accountId;
        ChipsAmount = chipsAmount;
    }

    public void DepositChips(uint chipsAmount)
    {
        ChipsAmount += chipsAmount;
    }

    public void WithdrawalChips(uint chipsAmount)
    {
        if (ChipsAmount < chipsAmount)
        {
            throw new NotEnoughChipsException(chipsAmount);
        }
        
        ChipsAmount -= chipsAmount;
    }
    public void AccrueWin(uint chipsAmount)
    {
        ChipsAmount += chipsAmount;
    }
    
    public void AccrueLose(uint chipsAmount)
    {
        if (ChipsAmount < chipsAmount)
        {
            throw new NotEnoughChipsException(chipsAmount);
        }
        
        ChipsAmount -= chipsAmount;
    }
}
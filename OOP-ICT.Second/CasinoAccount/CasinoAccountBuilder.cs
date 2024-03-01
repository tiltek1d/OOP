namespace SecondLab;

public class CasinoAccountBuilder: ICasinoAccountBuilder
{
    private string _accountId = null!;
    private uint _chipsAmount;
    
    public void AccountId(string accountId)
    {
        _accountId = accountId;
    }

    public void ChipsAmount(uint chipsAmount)
    {
        _chipsAmount = chipsAmount;
    }

    public CasinoAccount CreateCasinoAccount()
    {
        CasinoAccount account = new(_accountId, _chipsAmount);

        return account;
    }
}
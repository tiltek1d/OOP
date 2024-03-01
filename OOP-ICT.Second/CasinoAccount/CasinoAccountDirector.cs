namespace SecondLab;

public class CasinoAccountDirector
{
    private readonly CasinoAccountBuilder _casinoBuilder;

    public CasinoAccountDirector(CasinoAccountBuilder casinoBuilder)
    {
        _casinoBuilder = casinoBuilder;
    }

    public void Construct(string accountId, uint chipsAmount)
    {
        _casinoBuilder.AccountId(accountId);
        _casinoBuilder.ChipsAmount(chipsAmount);
    }
}
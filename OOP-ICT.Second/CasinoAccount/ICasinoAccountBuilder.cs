namespace SecondLab;

public interface ICasinoAccountBuilder
{
    void AccountId(string accountId);
    void ChipsAmount(uint chipsAmount);

    CasinoAccount CreateCasinoAccount();
}
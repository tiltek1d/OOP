using SecondLab.Exceptions;
using SecondLab;
using SecondLab.Factories;

namespace FourthLab.Models;

public class PokerCasino
{
    private readonly uint _exchangeRate;
    private readonly List<CasinoAccount> _accounts = new();
    private readonly AccountFactory _accountFactory = new();

    public PokerCasino(uint exchangeRate)
    {
        _exchangeRate = exchangeRate;
    }
    public void CreateNewAccount(uint idClient)
    {
        _accounts.Add(_accountFactory.CreateCasinoAccount(idClient.ToString(), 0).CreateCasinoAccount());
    }

    public void BuyChips(uint idClient, uint amount)
    {
        GetCasinoAccount(idClient).DepositChips(amount);
    }

    public void ExchangeChips(uint idClient, uint amount)
    {
        GetCasinoAccount(idClient).WithdrawalChips(amount);
    }

    public CasinoAccount GetCasinoAccount(uint idClient)
    {
        if (_accounts.FirstOrDefault(i => i.AccountId == idClient.ToString()) is null)
            throw new IncorrectBankAccountIdException("There is no such client in casino");
        return _accounts.FirstOrDefault(i => i.AccountId == idClient.ToString())!;
    }

    public bool IsEnoughChips(uint idClient, uint amount)
    {
        return GetCasinoAccount(idClient).ChipsAmount > amount;
    }

    public uint GetExchangeRate()
    {
        return _exchangeRate;
    }
}
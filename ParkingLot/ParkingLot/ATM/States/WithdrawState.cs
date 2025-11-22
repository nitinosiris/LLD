namespace ATM.States;

public class WithdrawState : AtmState
{
    public override void CashWithdraw(Atm atm, Card card, int amount)
    {
        if (card.Account.Balance >= amount)
        {
            card.Account.SetBalance(card.Account.Balance - amount);
            Console.WriteLine("Withdrawed " + amount + " card");
            ExitAtm(atm);
        }
        else
        {
            Console.WriteLine("Insufficient funds");
            ExitAtm(atm);
        }
    }
    
    public override void ExitAtm(Atm atm)
    {
        ReturnCard();
        atm.SetAtmState(new IdleState());
        Console.WriteLine("Exited from ATM");
    }

    public override void ReturnCard()
    {
        Console.WriteLine("Card returned");
    }
}
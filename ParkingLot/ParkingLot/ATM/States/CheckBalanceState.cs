namespace ATM.States;

public class CheckBalanceState : AtmState
{
    public override void DisplayBalance(Atm atm, Card card)
    {
        Console.WriteLine("Balance is " + card.Account.Balance);
        ExitAtm(atm);
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
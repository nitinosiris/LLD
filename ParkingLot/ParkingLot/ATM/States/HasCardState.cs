namespace ATM.States;

public class HasCardState : AtmState
{
    public override void AuthenticatePin(Atm atm, Card card, int pin)
    {
        if (card.IsPinValid(pin))
        {
            Console.WriteLine("Pin is valid");
            atm.SetAtmState(new SelectOperationState());
        }
        else
        {
            Console.WriteLine("Pin is not valid");
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
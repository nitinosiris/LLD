namespace ATM.States;

public class IdleState : AtmState
{
    public override void InsertCard(Atm atm, Card card)
    {
        Console.WriteLine("Card Inserted");
        atm.SetAtmState(new HasCardState());
    }
}
namespace ATM;

public abstract class AtmState
{
    public virtual void InsertCard(Atm atm, Card card)
    {
        Console.WriteLine("Opps! Something went wrong");
    }

    public virtual void AuthenticatePin(Atm atm, Card card, int pin)
    {
        Console.WriteLine("Opps! Something went wrong");
    }

    public virtual void CashWithdraw(Atm atm, Card card, int amount)
    {
        Console.WriteLine("Opps! Something went wrong");
    }

    public virtual void SelectOperation(Atm atm, Card card, TransactionType transactionType)
    {
        Console.WriteLine("Opps! Something went wrong");
    }

    public virtual void DisplayBalance(Atm atm, Card card)
    {
        Console.WriteLine("Opps! Something went wrong");
    }

    public virtual void ReturnCard()
    {
        Console.WriteLine("Opps! Something went wrong");
    }

    public virtual void ExitAtm(Atm atm)
    {
        Console.WriteLine("Opps! Something went wrong");
    }
}
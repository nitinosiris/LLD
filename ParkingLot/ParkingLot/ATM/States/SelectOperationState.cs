namespace ATM.States;

public class SelectOperationState : AtmState
{
    public override void SelectOperation(Atm atm, Card card, TransactionType transactionType)
    {
        switch (transactionType)
        {
            case TransactionType.CheckBalance:
                atm.SetAtmState(new CheckBalanceState());
                Console.WriteLine("Check Balance");
                break;
            case TransactionType.WithDraw:
                atm.SetAtmState(new WithdrawState());
                Console.WriteLine("Withdraw");
                break;
            default:
                Console.WriteLine("Unknown transaction type");
                ExitAtm(atm);
                break;
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
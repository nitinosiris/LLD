namespace ATM;

public class BankAccount(int balance)
{
    public int Balance { get; private set; } = balance;

    public void SetBalance(int balance)
    {
        Balance = balance;
    }
}
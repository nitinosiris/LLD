namespace ATM;

public class Card(string cardNumber, BankAccount account, int pin)
{
    public string CardNumber { get; private set; } = cardNumber;
    public BankAccount Account { get; private set; } = account;
    private int Pin { get; } = pin;

    public bool IsPinValid(int enteredPin)
    {
        return Pin == enteredPin;
    }
}

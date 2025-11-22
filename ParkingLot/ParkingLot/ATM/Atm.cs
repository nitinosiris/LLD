using ATM.States;

namespace ATM;

public class Atm
{
    private AtmState _atmState = new IdleState();

    public void SetAtmState(AtmState atmState)
    {
        _atmState = atmState;
    }

    public void PrintCurrentStatus()
    {
        Console.WriteLine("Atm state is " + _atmState);
    }

    public AtmState GetAtmState()
    {
        return _atmState;
    }
}
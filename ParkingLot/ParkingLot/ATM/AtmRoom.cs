namespace ATM;

public class AtmRoom(Atm atm, User user)
{
    public Atm Atm { get; set; } = atm;
    public User User { get; set; } = user;
}
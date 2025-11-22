using ATM;

var user = new User("Nitin");
var bankAccount = new BankAccount(2000);
var card = new Card("1234", bankAccount, 123);
var atm = new Atm();

var atmRoom = new AtmRoom(atm, user);

atmRoom.Atm.PrintCurrentStatus();

atmRoom.Atm.GetAtmState().InsertCard(atm, card);
atmRoom.Atm.PrintCurrentStatus();

atmRoom.Atm.GetAtmState().AuthenticatePin(atm, card, 123);
atmRoom.Atm.PrintCurrentStatus();

// atmRoom.Atm.GetAtmState().SelectOperation(atm, card, TransactionType.CheckBalance);
// atmRoom.Atm.PrintCurrentStatus();

atmRoom.Atm.GetAtmState().SelectOperation(atm, card, TransactionType.WithDraw);
atmRoom.Atm.PrintCurrentStatus();

atmRoom.Atm.GetAtmState().CashWithdraw(atm, card, 3000);
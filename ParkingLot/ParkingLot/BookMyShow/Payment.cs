namespace BookMyShow;

public class Payment(int price, PaymentStatus paymentStatus)
{
    public string Id { get;  private set; } = Guid.NewGuid().ToString();

    public int Price { get; private set; } = price;
    
    public PaymentStatus Status { get; private set; } = paymentStatus;
}
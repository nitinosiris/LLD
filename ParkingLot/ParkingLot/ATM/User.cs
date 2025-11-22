namespace ATM;

public class User(string name)
{
    public string Name { get; private set; } = name;
    private List<Card> Card { get; set; } = [];

    public void AddCard(Card card)
    {
        Card.Add(card);
    }

    public void RemoveCard(Card card)
    {
        Card.Remove(card);
    }
}
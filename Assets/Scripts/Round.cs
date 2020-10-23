public class Round {
    public short Number { get; private set; }
    public bool Finished { get; private set; }
    public IPlayer Winner { get; private set; }

    public Round(short number, IPlayer player1, IPlayer player2)
    {
        Number = number;
        StartRound(player1, player2);
    }

    public void StartRound(IPlayer player1, IPlayer player2)
    {
        //Organizar as peças na cena
    }

    public void EndRound()
    {
        //Definir o vencedor do round no atributo Winner
        //Resetar as peças na cena
    }
}
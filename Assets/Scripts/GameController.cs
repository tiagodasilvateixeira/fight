using System;
using System.Collections.Generic;

public class GameController
{
    public DateTime RoundTime { get; private set; }
    public List<Round> Rounds { get; private set; }
    public string BackgroundImage { get; private set; }
    public string Music { get; private set; }
    public IPlayer Player1 { get; private set; }
    public IPlayer Player2 { get; private set; }

    void StartFight()
    {
        //Iniciar loop de rounds
        //Para Corrigir: Passar musica e background para a classe Round
    }

    void PauseFight()
    {

    }

    void EndFight()
    {

    }

    void CancelFight()
    {

    }

    void DetermineWinner()
    {
        
    }
}

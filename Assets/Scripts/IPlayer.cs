public interface IPlayer {
    short Life { get;set; }
    short Energy { get;set; }
    short EspecialPower { get;set; }
    byte Orientation { get;set; }
    bool IA { get;set; }

    void Walk();
    void Jump();
    void Punch();
    void Kick();
    void Block();
    void EspecialAtack();
    void Hit();
    void KO();
    void Win();
}
public interface IPlayer {
    string Name { get; set; }
    int Life { get;set; }
    int Energy { get;set; }
    int EspecialPower { get;set; }
    byte Orientation { get;set; }
    bool IA { get;set; }

    bool CheckWalkInput();
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
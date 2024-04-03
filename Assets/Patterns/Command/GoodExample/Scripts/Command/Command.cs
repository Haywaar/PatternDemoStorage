public abstract class Command
{
    public abstract void Execute();
    public abstract bool CanBeExecuted();
    public abstract TurnType GetTurnType();
}

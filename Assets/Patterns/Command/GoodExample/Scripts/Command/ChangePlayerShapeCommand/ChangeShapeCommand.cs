public class ChangeShapeCommand : Command
{
    public readonly PlayerShape PlayerShape;

    // Receiver
    private PlayerShapeChanger PlayerShapeChanger;


    public ChangeShapeCommand(PlayerShapeChanger playerShapeChanger, PlayerShape playerShape)
    {
        PlayerShapeChanger = playerShapeChanger;
        PlayerShape = playerShape;
    }

    public override bool CanBeExecuted()
    {
        return true;
    }

    public override void Execute()
    {
        PlayerShapeChanger.SetShape(PlayerShape);
    }

    public override TurnType GetTurnType()
    {
        return TurnType.ChangeShape;
    }
}
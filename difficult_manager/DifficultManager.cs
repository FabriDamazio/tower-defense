using Godot;

public partial class DifficultManager : Node
{
    [Export]
    public float GameLength = 30.0f;

    [Export]
    public Curve SpawnTimeCurve;

    private Timer _timer;

    public override void _Ready()
    {
        _timer = GetNode<Timer>("%Timer");
        _timer.Start(GameLength);
    }

    public float GameProgressRatio()
    {
        return 1.0f - ((float)_timer.TimeLeft / GameLength);
    }

    public float GetSpawnTime()
    {
        return SpawnTimeCurve.Sample(GameProgressRatio());
    }
}

using Godot;

public partial class DifficultManager : Node
{
    [Export]
    public float GameLength = 30.0f;

    [Export]
    public Curve SpawnTimeCurve;

    [Signal]
    public delegate void StopSpawingEnemiesEventHandler();

    [Export]
    public Curve EnemyHealthCurve;

    private Timer _timer;

    public override void _Ready()
    {
        _timer = GetNode<Timer>("%Timer");
        _timer.Timeout += OnTimerTimeout;
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

    public float GetEnemyHealth()
    {
        return EnemyHealthCurve.Sample(GameProgressRatio());
    }

    private void OnTimerTimeout()
    {
        EmitSignal(SignalName.StopSpawingEnemies);
    }
}

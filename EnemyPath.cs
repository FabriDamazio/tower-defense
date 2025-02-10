using Godot;

public partial class EnemyPath : Path3D
{
    [Export]
    public PackedScene EnemyScene;

    [Export]
    public DifficultManager _difficultManager;

    private Timer _timer;

    public override void _Ready()
    {
        _timer = GetNode<Timer>("%Timer");
        _timer.Timeout += OnTimerTimeout;
    }

    public void SpawnEnemy()
    {
        var enemy = EnemyScene.Instantiate();
        AddChild(enemy);
        _timer.WaitTime = _difficultManager.GetSpawnTime();
    }

    private void OnTimerTimeout()
    {
        SpawnEnemy();
    }

}

using Godot;

public partial class EnemyPath : Path3D
{
    [Export]
    public PackedScene EnemyScene;

    [Export]
    public DifficultManager _difficultManager;

    [Export]
    public VictoryLayer VictoryLayer;

    private Timer _timer;

    public override void _Ready()
    {
        _timer = GetNode<Timer>("%Timer");
        _timer.Timeout += OnTimerTimeout;

        _difficultManager.StopSpawingEnemies += OnStopSpawingEnemies;
    }

    public void SpawnEnemy()
    {
        Enemy enemy = EnemyScene.Instantiate<Enemy>();
        enemy.MaxHealth = (int)_difficultManager.GetEnemyHealth();
        AddChild(enemy);
        _timer.WaitTime = _difficultManager.GetSpawnTime();
        enemy.TreeExited += EnemyDefeated;
    }

    private void OnTimerTimeout()
    {
        SpawnEnemy();
    }

    private void OnStopSpawingEnemies()
    {
        _timer.Stop();
    }

    private void EnemyDefeated()
    {
        if (_timer.IsStopped())
        {
            foreach (var child in GetChildren())
            {
                if (child is PathFollow3D)
                    return;
            }
            VictoryLayer.Victory();
        }
    }
}

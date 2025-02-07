using Godot;

public partial class Turret : Node3D
{
    [Export]
    public PackedScene Projectile;

    [Export]
    public float TurretRange = 10.0f;

    private Timer _shotTimer;
    private Node3D _turretTop;
    private Path3D _enemyPath;
    private PathFollow3D _target;

    public override void _Ready()
    {
        _shotTimer = GetNode<Timer>("%Timer");
        _shotTimer.Timeout += OnTimerTimeout;

        _turretTop = GetNode<Node3D>("%TurretTop");
    }

    public override void _PhysicsProcess(double delta)
    {
        _target = FindBestTarget();

        if (_target is not null)
            LookAt(_target.GlobalPosition, Vector3.Up, true);
    }

    public void SetEnemyPath(Path3D path)
    {
        _enemyPath = path;
    }

    private void OnTimerTimeout()
    {
        if (_target is not null)
        {
            var shot = Projectile.Instantiate<Projectile>();
            AddChild(shot);
            shot.GlobalPosition = _turretTop.GlobalPosition;
            shot.Direction = GlobalBasis.Z;
        }
    }

    private PathFollow3D FindBestTarget()
    {
        PathFollow3D bestTarget = null;
        float bestProgress = 0;

        foreach (var enemy in _enemyPath.GetChildren())
        {
            if (enemy is PathFollow3D)
            {
                var path = (PathFollow3D)enemy;
                var distance = GlobalPosition.DistanceTo(path.GlobalPosition);

                if (distance <= TurretRange && path.Progress > bestProgress)
                {
                    bestTarget = path;
                    bestProgress = path.Progress;
                }
            }
        }

        return bestTarget;
    }
}

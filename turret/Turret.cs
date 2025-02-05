using Godot;
using System.Linq;

public partial class Turret : Node3D
{
    [Export]
    public PackedScene Projectile;

    private Timer _shotTimer;
    private Node3D _turretTop;
    private Path3D _enemyPath;

    public override void _Ready()
    {
        _shotTimer = GetNode<Timer>("%Timer");
        _shotTimer.Timeout += OnTimerTimeout;

        _turretTop = GetNode<Node3D>("%TurretTop");
    }

    public override void _PhysicsProcess(double delta)
    {
        var enemy = _enemyPath.GetChildren().Last() as Enemy;
        LookAt(enemy.GlobalPosition, Vector3.Up, true);
    }

    public void SetEnemyPath(Path3D path)
    {
        _enemyPath = path;
    }

    private void OnTimerTimeout()
    {
        var shot = Projectile.Instantiate<Projectile>();
        AddChild(shot);
        shot.GlobalPosition = _turretTop.GlobalPosition;
        shot.Direction = GlobalBasis.Z;
    }
}

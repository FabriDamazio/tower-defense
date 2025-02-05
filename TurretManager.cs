using Godot;

public partial class TurretManager : Node3D
{
    [Export]
    public PackedScene Turret;

    [Export]
    public Path3D EnemyPath;

    public override void _Ready()
    {
    }

    public void BuildTurret(Vector3 position)
    {
        var newTurret = Turret.Instantiate<Turret>();
        AddChild(newTurret);
        newTurret.GlobalPosition = position;
        newTurret.SetEnemyPath(EnemyPath);
    }
}

using Godot;

public partial class TurretManager : Node3D
{
    [Export]
    public PackedScene Turret;

    public override void _Ready()
    {
    }

    public void BuildTurret(Vector3 position)
    {
      var newTurret = Turret.Instantiate<Node3D>();
      AddChild(newTurret);
      newTurret.GlobalPosition = position;
    }
}

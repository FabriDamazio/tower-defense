using Godot;

public partial class Enemy : PathFollow3D
{
  [Export]
  public float Speed = 2.5f;

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
    Progress += (float)delta * Speed;
	}
}

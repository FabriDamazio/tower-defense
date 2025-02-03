using Godot;

public partial class Enemy : PathFollow3D
{
    [Export]
    public float Speed = 2.5f;

    private Base _base;

    public override void _Ready()
    {
        _base = GetTree().GetFirstNodeInGroup("base") as Base;
    }

    public override void _Process(double delta)
    {
        Progress += (float)delta * Speed;

        if (ProgressRatio == 1.0)
        {
            _base.TakeDamage();
        }
    }
}

using Godot;

public partial class Enemy : PathFollow3D
{
    [Export]
    public float Speed = 2.5f;

    [Export]
    public int MaxHealth = 50;

    public int CurrentHealth;
    private Base _base;

    public override void _Ready()
    {
        _base = GetTree().GetFirstNodeInGroup("base") as Base;
        CurrentHealth = MaxHealth;
    }

    public override void _Process(double delta)
    {
        Progress += (float)delta * Speed;

        if (ProgressRatio == 1.0)
        {
            _base.TakeDamage();
            SetProcess(false);
        }
    }

    public void SetCurrentHealth(int value)
    {
        CurrentHealth = value;

        if (CurrentHealth < 1)
            QueueFree();
    }
}

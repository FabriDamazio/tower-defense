using Godot;

public partial class Projectile : Area3D
{
    [Export]
    public float Speed = 30.0f;

    public Vector3 Direction = Vector3.Forward;
    private Timer _timer;

    public override void _Ready()
    {
        _timer = GetNode<Timer>("%Timer");
        _timer.Timeout += OnTimerTimeout;

        AreaEntered += OnAreaEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        Position = Position + Direction * Speed * (float)delta;
    }

    private void OnTimerTimeout()
    {
        QueueFree();
    }

    private void OnAreaEntered(Area3D area)
    {
        if (area.IsInGroup("enemy_area"))
        {
            GD.Print(area);
            var enemy = area.GetParent<Enemy>();
            enemy.SetCurrentHealth(enemy.CurrentHealth - 25);
            QueueFree();
        }
    }
}

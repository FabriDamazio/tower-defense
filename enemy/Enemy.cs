using Godot;

public partial class Enemy : PathFollow3D
{
    [Export]
    public float Speed = 2.5f;

    [Export]
    public int MaxHealth = 50;

    [Export]
    public int Reward = 15;

    public int CurrentHealth;

    private Base _base;
    private AnimationPlayer _animationPlayer;
    private Bank _bank;

    public override void _Ready()
    {
        _base = GetTree().GetFirstNodeInGroup("base") as Base;
        CurrentHealth = MaxHealth;

        _animationPlayer = GetNode<AnimationPlayer>("%AnimationPlayer");
        _bank = GetTree().GetFirstNodeInGroup("bank") as Bank;
    }

    public override void _Process(double delta)
    {
        Progress += (float)delta * Speed;

        if (ProgressRatio == 1.0)
        {
            _base.TakeDamage();
            SetProcess(false);
            QueueFree();
        }
    }

    public void SetCurrentHealth(int value)
    {
        if (value < CurrentHealth)
            _animationPlayer.Play("take_damage");

        CurrentHealth = value;


        if (CurrentHealth < 1)
        {
            _bank.SetGold(_bank.CurrentGold + Reward);
            QueueFree();
        }
    }
}

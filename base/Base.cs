using Godot;

public partial class Base : Node3D
{
    [Export]
    public int MaxHealth { get; set; } = 5;

    [Export]
    public int CurrentHealth = 0;

    private Label3D _healthLabel;

    public override void _Ready()
    {
        _healthLabel = GetNode<Label3D>("%HealthLabel");
        _healthLabel.Text = MaxHealth.ToString();
        SetHealth(MaxHealth);
    }

    public void SetHealth(int value)
    {
        CurrentHealth = value;
        GD.Print("health was changed");
        _healthLabel.Text = CurrentHealth.ToString();

        if (CurrentHealth < 1)
        {
            GetTree().ReloadCurrentScene();
        }
    }

    public int GetHealth()
    {
        return CurrentHealth;
    }

    public void TakeDamage()
    {
        GD.Print("Damage dealt to base");

        SetHealth(CurrentHealth - 1);
    }
}

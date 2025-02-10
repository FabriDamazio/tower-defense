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
        SetHealth(MaxHealth);
    }

    public void SetHealth(int value)
    {
        CurrentHealth = value;
        _healthLabel.Text = $"{CurrentHealth.ToString()}/{MaxHealth.ToString()}";

        var healthDiff = (float)CurrentHealth/(float)MaxHealth;
        _healthLabel.Modulate = Colors.Red.Lerp(Colors.White, healthDiff) ;

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

using Godot;
using System;

public partial class Bank : MarginContainer
{
    [Export]
    public int StartingGold = 150;

    public int CurrentGold = 0;

    private Label _goldLabel;

    public override void _Ready()
    {
        _goldLabel = GetNode<Label>("%GoldLabel");
        SetGold(StartingGold);
    }

    public void SetGold(int value)
    {
        CurrentGold = Math.Max(value, 0);
        _goldLabel.Text = $"Gold: {CurrentGold}";
    }
}

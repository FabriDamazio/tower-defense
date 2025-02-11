using Godot;

public partial class VictoryLayer : CanvasLayer
{
    private Button _retryButton;
    private Button _quitButton;
    private TextureRect _star1;
    private TextureRect _star2;
    private TextureRect _star3;
    private Base _base;
    private Bank _bank;
    private Label _healthLabel;
    private Label _moneyLabel;

    public override void _Ready()
    {
        _retryButton = GetNode<Button>("%RetryButton");
        _retryButton.ButtonDown += OnRetryButtonDown;

        _quitButton = GetNode<Button>("%QuitButton");
        _quitButton.ButtonDown += OnQuitButtonDown;

        _star1 = GetNode<TextureRect>("%Star1");
        _star2 = GetNode<TextureRect>("%Star2");
        _star3 = GetNode<TextureRect>("%Star3");
        _healthLabel = GetNode<Label>("%HealthLabel");
        _moneyLabel = GetNode<Label>("%MoneyLabel");

        _base = GetTree().GetFirstNodeInGroup("base") as Base;
        _bank = GetTree().GetFirstNodeInGroup("bank") as Bank;
    }

    private void OnRetryButtonDown()
    {
        GetTree().ReloadCurrentScene();
    }

    private void OnQuitButtonDown()
    {
        GetTree().Quit();
    }

    public void Victory()
    {
        Visible = true;
        if (_base.MaxHealth == _base.CurrentHealth)
        {
            _star2.Modulate = Colors.White;
            _healthLabel.Visible = true;
        }

        if (_bank.CurrentGold >= 500)
        {
            _star3.Modulate = Colors.White;
            _moneyLabel.Visible = true;
        }
    }
}

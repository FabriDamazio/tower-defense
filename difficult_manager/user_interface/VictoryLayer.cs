using Godot;

public partial class VictoryLayer : CanvasLayer
{
    private Button _retryButton;
    private Button _quitButton;

    public override void _Ready()
    {
        _retryButton = GetNode<Button>("%RetryButton");
        _retryButton.ButtonDown += OnRetryButtonDown;

        _quitButton = GetNode<Button>("%QuitButton");
        _quitButton.ButtonDown += OnQuitButtonDown;
    }

    private void OnRetryButtonDown()
    {
        GetTree().ReloadCurrentScene();
    }

    private void OnQuitButtonDown()
    {
        GetTree().Quit();
    }
}

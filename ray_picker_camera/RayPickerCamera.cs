using Godot;

public partial class RayPickerCamera : Camera3D
{
    [Export]
    public float ClickableRange = 100.0f;

    private RayCast3D _rayCast3D;

    public override void _Ready()
    {
        _rayCast3D = GetNode<RayCast3D>("%RayCast3D");
    }

    public override void _Process(double delta)
    {
        Vector2 mousePosition = GetViewport().GetMousePosition();
        _rayCast3D.TargetPosition = ProjectLocalRayNormal(mousePosition) * ClickableRange;
        _rayCast3D.ForceRaycastUpdate();
        GD.Print(_rayCast3D.GetCollider());
        GD.Print(_rayCast3D.GetCollisionPoint());
    }
}

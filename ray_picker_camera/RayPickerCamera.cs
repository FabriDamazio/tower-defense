using Godot;

public partial class RayPickerCamera : Camera3D
{
    [Export]
    public float ClickableRange = 100.0f;

    [Export]
    public GridMap GridMap;

    [Export]
    public TurretManager TurretManager;

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

        if (_rayCast3D.IsColliding())
        {
            var collider = _rayCast3D.GetCollider();

            if (collider is GridMap)
            {
                Input.SetDefaultCursorShape(Input.CursorShape.PointingHand);

                if (Input.IsActionPressed("click"))
                {
                    Vector3 collisionPoint = _rayCast3D.GetCollisionPoint();
                    Vector3I cellPosition = GridMap.LocalToMap(collisionPoint);

                    if (GridMap.GetCellItem(cellPosition) == 0)
                    {
                        GridMap.SetCellItem(cellPosition, 1);
                        var tilePosition = GridMap.MapToLocal(cellPosition);
                        TurretManager.BuildTurret(tilePosition);
                    }
                }
            }
        }
        else
        {
            Input.SetDefaultCursorShape(Input.CursorShape.Arrow);
        }
    }
}

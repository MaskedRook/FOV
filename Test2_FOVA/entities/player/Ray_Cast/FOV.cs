using Godot;
using System;

public class FOV : Polygon2D
{   
    [Export]
    float field_of_view = 360f;
    int rayCount = 1000;
    float viewDistance = 600f;
    public override void _Process(float delta)
    {
        float angle = 0;
        float angleIncrease = field_of_view / rayCount;

        Vector2[] vertices = new Vector2[rayCount + 1 + 1];

        vertices[0] = Vector2.Zero;

        int vertexIndex = 1;

        for(int i = 0; i <= rayCount; i++)
        {
            Vector2 vector_angle = new Vector2((float)Math.Cos(angle * (Math.PI/180f)), (float)Math.Sin(angle * (Math.PI/180f)));
            Vector2 vertex;

            var spaceState = GetWorld2d().DirectSpaceState;
            var result = spaceState.IntersectRay(GlobalPosition, GlobalPosition + vector_angle * viewDistance, new Godot.Collections.Array {GetParent()}, 0b00000000001111110000);
            if(result.Count > 0)
            {   
                vertex = (Vector2)result["position"] - GlobalPosition;
            }
            else
            {
                vertex = vector_angle * viewDistance;
            }

            vertices[vertexIndex] = vertex;
            vertexIndex++;
            angle -= angleIncrease;
        }
        this.Polygon = vertices;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Move : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Direction dir;

    void OnMouseDown()
    {
        Vector2 pos = target.position;
        switch (dir)
        {
            case Direction.RIGHT:
                pos.x += 0.2f;
                break;
            case Direction.LEFT:
                pos.x -= 0.2f;
                break;
            case Direction.UP:
                pos.y += 0.2f;
                break;
            case Direction.DOWN:
                pos.y -= 0.2f;
                break;
            default:
                break;
        }

        target.position = pos;
    }
}

public enum Direction
{
    UP, DOWN, RIGHT, LEFT
}


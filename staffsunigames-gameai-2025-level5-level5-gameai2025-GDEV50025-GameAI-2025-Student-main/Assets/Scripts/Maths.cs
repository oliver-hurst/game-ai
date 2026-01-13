using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Maths
{
    public static float Magnitude(Vector2 a )
    {
       
        
        float magnitude = Mathf.Sqrt(a.x*a.x +a.y*a.y);
        return magnitude;

    }

    public static Vector2 Normalise(Vector2 a )
    {
      a = a / Magnitude(a);
        return a;
    }

    public static float Dot(Vector2 lhs, Vector2 rhs)
    {
      lhs = lhs / Magnitude(lhs);
        rhs = rhs / Magnitude(rhs);
        float dot = lhs.x*rhs.x + lhs.y*rhs.y;
        return dot;
    }

    /// <summary>
    /// Returns the radians of the angle between two vectors
    /// </summary>
    public static float Angle(Vector2 lhs, Vector2 rhs)
    {
      float angle = Mathf.Acos(Dot(lhs, rhs));
        return angle;
    }

    /// <summary>
    /// Translates a vector by X angle in degrees
    /// </summary>
    public static Vector2 RotateVector(Vector2 vector, float degrees)
    {
        Vector2 vOut = new Vector2();
        // first convert degrees to radians
        float radians = degrees * Mathf.Deg2Rad;
        vOut.x = vector.x * Mathf.Cos(radians) - vector.y * Mathf.Sin(radians);
        vOut.y = vector.x * Mathf.Sin(radians) + vector.y * Mathf.Cos(radians);
        vOut.x = vector.x * vector.y;
        return vOut;
    }
}

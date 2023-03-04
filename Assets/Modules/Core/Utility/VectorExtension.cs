using UnityEngine;

public static class VectorExtension
{
    /// <summary>
    /// Creates a vector which X,Y Components individually are clamped between their min/max counterparts
    /// </summary>
    /// <param name="value"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static Vector2 Clamp(this Vector2 value, Vector2 min, Vector2 max)
    {
        return new Vector2(Mathf.Clamp(value.x, min.x, max.x), Mathf.Clamp(value.y, min.y, max.y));
    }

    /// <summary>
    /// Creates a vector which X,Y Components individually are clamped between their min/max counterparts
    /// </summary>
    /// <param name="value"></param>
    /// <param name="minX"></param>
    /// <param name="minY"></param>
    /// <param name="maxX"></param>
    /// <param name="maxY"></param>
    /// <returns></returns>
    public static Vector2 Clamp(this Vector2 value, float? minX, float? minY, float? maxX, float? maxY)
    {
        return new Vector2(Mathf.Clamp(value.x, minX ?? value.x, maxX ?? value.x), Mathf.Clamp(value.y, minY ?? value.y, maxY ?? value.y));
    }

    /// <summary>
    /// Returns if the given vector is inside the given coordinates, use null values for limitless bounds
    /// </summary>
    /// <param name="value"></param>
    /// <param name="minX"></param>
    /// <param name="minY"></param>
    /// <param name="maxX"></param>
    /// <param name="maxY"></param>
    /// <returns></returns>
    public static bool IsInside(this Vector2 value, float? minX, float? minY, float? maxX, float? maxY)
    {
        minX ??= value.x;
        minY ??= value.y;
        maxX ??= value.x;
        maxY ??= value.y;

        return !(value.x > maxX || value.x < minX || value.y > maxY || value.y < minY);
    }

    /// <summary>
    /// Returns the vector2 with the x,y values of the vector3
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Vector2 V2(this Vector3 value)
    {
        return new Vector2(value.x, value.y);
    }

    /// <summary>
    /// Returns the vector3 with the x,y values of the vector2 and 0 for z or an optional value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Vector3 V3(this Vector2 value, float z = 0)
    {
        return new Vector3(value.x, value.y, z);
    }

    /// <summary>
    /// Rotates a 2d Vector clockwise
    /// </summary>
    /// <param name="v"></param>
    /// <param name="degrees"></param>
    /// <returns></returns>
    public static Vector2 Rotate(this Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }
}



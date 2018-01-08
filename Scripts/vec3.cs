using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vec3
{

    public float x, y, z;
    public static Vec3 zero = new Vec3(0f, 0f, 0f);
    public static Vec3 one = new Vec3(1f, 1f, 1f);
    public static Vec3 unitX = new Vec3(1f, 0f, 0f);
    public static Vec3 unitY = new Vec3(0f, 1f, 0f);
    public static Vec3 unitZ = new Vec3(0f, 0f, 1f);
    public static Vec3 up = new Vec3(0f, 1f, 0f);
    public static Vec3 down = new Vec3(0f, -1f, 0f);
    private static Vec3 right = new Vec3(1f, 0f, 0f);
    public static Vec3 left = new Vec3(-1f, 0f, 0f);
    public static Vec3 forward = new Vec3(0f, 0f, -1f);
    public static Vec3 backward = new Vec3(0f, 0f, 1f);
    public Vec3(float posx, float posy, float posz)
    {
        x = posx;
        y = posy;
        z = posz;
        posx = x;
        posy = y;
        posz = z;
        
    }

    public Vec3 (Vector3 v)
    {
        x = v.x;
        y = v.y;
        z = v.z;
    }
    public static Vec3 Zero
    {
        get { return zero; }
    }

    public static Vec3 One
    {
        get { return one; }
    }

    public static Vec3 UnitX
    {
        get { return unitX; }
    }

    public static Vec3 UnitY
    {
        get { return unitY; }
    }

    public static Vec3 UnitZ
    {
        get { return unitZ; }
    }

    public static Vec3 Up
    {
        get { return up; }
    }

    public static Vec3 Down
    {
        get { return down; }
    }

    public static Vec3 Right
    {
        get { return right; }
    }

    public static Vec3 Left
    {
        get { return left; }
    }

    public static Vec3 Forward
    {
        get { return forward; }
    }

    public static Vec3 Backward
    {
        get { return backward; }
    }
  
   /* public void Vec3Scale(float sizeX, float sizeY, float sizeZ)
    {
        this.transform.localScale = new Vector3(sizeX, sizeY, sizeZ);
    }*/
    /* public static bool operator ==(Vec3 value1, Vec3 value2)
     {
         return value1.x == value2.x
             && value1.y == value2.y
             && value1.y == value2.z;
     }

     public static bool operator !=(Vec3 value1, Vec3 value2)
     {
         return !(value1 == value2);
     }*/
    public static Vec3 operator +(Vec3 a, Vec3 b)
    {
        return new Vec3(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static Vec3 operator -(Vec3 a, Vec3 b)
    {
        return new Vec3(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static Vec3 operator -(Vec3 a)
    {
        return new Vec3(-a.x, -a.y, -a.z);
    }

    public static Vec3 operator *(Vec3 a, float d)
    {
        return new Vec3(a.x * d, a.y * d, a.z * d);
    }

    public static Vec3 operator *(float d, Vec3 a)
    {
        return new Vec3(a.x * d, a.y * d, a.z * d);
    }


    public static float Dot(Vec3 lhs, Vec3 rhs)
    {
        return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
    }
    public static float Distance(Vec3 a, Vec3 b)
    {
        Vec3 vector = new Vec3(a.x - b.x, a.y - b.y, a.z - b.z);
        return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
    }

    public static Vec3 Cross(Vec3 vector1,Vec3 vector2)
    {
        Vec3 result = new Vec3(vector1.y * vector2.z - vector2.y * vector1.z,
                             -(vector1.x * vector2.z - vector2.x * vector1.z),
                             vector1.x * vector2.y - vector2.x * vector1.y);
        return result;
    }
    public static float DistanceSquared(Vec3 vector1, Vec3 vector2)
    {
        return DistanceSquared(vector1, vector2);
    }
    public static void DistanceSquared(ref Vec3 value1, ref Vec3 value2, out float result)
    {
        result = (value1.x - value2.x) * (value1.x - value2.x) +
                 (value1.y - value2.y) * (value1.y - value2.y) +
                 (value1.z - value2.z) * (value1.z - value2.z);
    }
    public static Vec3 Lerp(Vec3 value1, Vec3 value2, float amount)
    {
        return new Vec3(
            Mathf.Lerp(value1.x, value2.x, amount),
            Mathf.Lerp(value1.y, value2.y, amount),
            Mathf.Lerp(value1.z, value2.z, amount));
    }

    public static Vec3 Normalize(Vec3 v)
    {
        float norm = Mathf.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
        v.x /= norm;
        v.y /= norm;
        v.z /= norm;

        return v;
    }

    public static float Mod(Vec3 v)
    {
        return Mathf.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
    }
}


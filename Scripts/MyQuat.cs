using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyQuat 
{
    public float w, x, y, z;

    public MyQuat() { }

    public MyQuat(Vec3 axis, float angle)
    {
        angle = Mathf.Deg2Rad * angle;
        axis = Vec3.Normalize(axis);
        w = Mathf.Cos(angle/2);
        x = axis.x * Mathf.Sin(angle / 2);
        y = axis.y * Mathf.Sin(angle / 2);
        z = axis.z * Mathf.Sin(angle / 2);

    }

    public MyQuat(Quaternion q)
    {
        w = q.w;
        x = q.x;
        y = q.y;
        z = q.z;
    }
    
    public MyQuat(float _w, float _x, float _y, float _z)
    {
        w = _w;
        x = _x;
        y =_y;
        z = _z;
    }

    public MyQuat Inverse()
    {
        return Conjugate();
    }

    public MyQuat Multiply(MyQuat q, MyQuat r)
    {   
      MyQuat t = new MyQuat();
       t.w = (r.w * q.w - r.x * q.x - r.y * q.y - r.z * q.z);
       t.x = (r.w * q.x + r.x * q.w - r.y * q.z + r.z * q.y);
       t.y = (r.w * q.y + r.x * q.z + r.y * q.w - r.z * q.x);
       t.z = (r.w * q.z - r.x * q.y + r.y * q.x + r.z * q.w);
       return t;
   }

    public static MyQuat operator *(MyQuat q, MyQuat r)
    {
        MyQuat t = new MyQuat();
        t.w = (r.w * q.w - r.x * q.x - r.y * q.y - r.z * q.z);
        t.x = (r.w * q.x + r.x * q.w - r.y * q.z + r.z * q.y);
        t.y = (r.w * q.y + r.x * q.z + r.y * q.w - r.z * q.x);
        t.z = (r.w * q.z - r.x * q.y + r.y * q.x + r.z * q.w);
        return t;
    }

    public float module()
    {
        return Mathf.Sqrt(x*x + y*y + z*z + w*w);
    }

    public MyQuat Conjugate()
    {
        MyQuat result = new MyQuat();
        result.x = x * -1;
        result.y = y * -1;
        result.z = z * -1;
        result.w = w;

        return result;
    }

    public static  MyQuat AngleAxis(float angle, Vec3 axis)
    {
        Vec3 vn = Vec3.Normalize(axis);

        angle = angle * Mathf.Deg2Rad;

        MyQuat q = new MyQuat(Mathf.Cos(angle/2), vn.x * Mathf.Sin(angle / 2), vn.y * Mathf.Sin(angle / 2), vn.z * Mathf.Sin(angle / 2));
        return q;
    }
}

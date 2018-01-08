

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class Attractor : MonoBehaviour
{
    [ExecuteInEditMode]

    public static Material m;

    LineRenderer forceline;
    int lengthLine = 2;
    //SELF MADE STUFF
    public Vec3 position, velocity;
    Vec3 dir, force, inter;
    public Slider slider;
    public Attractor attractor;
    Vec3 lastpos = Vec3.zero;
    Vec3 originalSliderpos, actual;
    public float fx, fy, fz;
    public float mass, dist;
    public static float delta;
    public float bigMass;
    float offset;
    public static int vectors = -1;
    private Vec3 sunPos = Vec3.zero; // posició del sol en el sistema
    public Transform origin;
    public static float G = 500f;

    Material lineMat;

    // [SerializeField]
    public Vector3 speed;
    public Vector3 rotata;
    Vector3 pos, vforce;

    MyQuat q;



    void FixedUpdate()
    {
        bigMass = Hole.bigMassa;
        if (attractor != null)
        {

            Attract(attractor);

        }

    }

    void Start()
    {

        lineMat = m;

        delta = 0.033f;
        originalSliderpos = new Vec3(510, 1178, -239);
        //mod2 = Vec3.Mod(originalSliderpos);
        q = new MyQuat(transform.rotation);

        //Esta fet aixi degut a que s han d iniialitzar tots els valors, un per un, de les posicions
        fx = transform.position.x;
        fy = transform.position.y;
        fz = transform.position.z;


        velocity = new Vec3(speed.x, speed.y, speed.z) * 20;
        position = new Vec3(fx, fy, fz);

    }



    void Attract(Attractor objToAttract)
    {

        //----------------SELF MADE NICELY NICE STUFF//------
        actual = TargetPos.getPos();
        if (delta >= 0.033f + 0.02 * 14)
            delta = 0.033f + 0.02f * 14;
        if (delta <= 0)
            delta = 0;

        position = new Vec3(fx, fy, fz); // Planeta petit
        dir = sunPos - position;
        dist = Vec3.Distance(sunPos, position);
        inter = new Vec3(fx - fx / 3, fy - fy / 3, fz - fz / 3);



        float f = (G * bigMass * mass) / Mathf.Pow(dist, 2);
        Vec3 gravity = Vec3.Normalize(dir) * f;


        velocity.x = velocity.x + delta / 20 * gravity.x;
        velocity.y = velocity.y + delta / 20 * gravity.y;
        velocity.z = velocity.z + delta / 20 * gravity.z;


        // position = position + velocity * Time.deltaTime;
        fx = fx + velocity.x * delta;
        fy = fy + velocity.y * delta;
        fz = fz + velocity.z * delta;

        q.y += 1 * Mathf.Rad2Deg;

        transform.position = new Vector3(position.x, position.y, position.z);
        transform.rotation = new Quaternion(q.x, q.y, q.z, q.w);

        pos = new Vector3(position.x, position.y, position.z);
        vforce = new Vector3(fx, fy, fz);
        Vector3 intt = new Vector3(inter.x, inter.y, inter.z);

    }


/*
    public static Vec3 getPos()
    {
        return position;
    }
    */

}



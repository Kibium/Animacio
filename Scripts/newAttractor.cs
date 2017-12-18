

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class newAttractor : MonoBehaviour
{

    //SELF MADE STUFF
    Vec3 position, velocity, dir, force;
    public static newAttractor attract;
    Vec3 lastpos = Vec3.zero;
    public float fx, fy, fz;
    public float mass, dist;
    private float delta = 0.33f;
    public float bigMass = 332950;
    private Vec3 sunPos = Vec3.zero; // posició del sol en el sistema
    public newAttractor[] newAttractors;
    const float G = 500f;
    

    public Rigidbody A;
    public Rigidbody B;
    // [SerializeField]
    float distance;

    //[SerializeField]
    Vector3 direction;

    //[SerializeField]
    Vector3 GravForce;

    // [SerializeField]
    public Vector3 speed;
    public Vector3 rotata;

    void FixedUpdate()
    {
          attract = this;
          newAttract(attract);
        
    }

    void Start()
    {
 
        Debug.Log(speed.x+ speed.z+ speed.y);
     
        velocity = new Vec3(speed.x, speed.y, speed.z) * 20;
        position = new Vec3(fx, fy, fz);
        //A.velocity = speed * 50;
        //velocity = Vec3.backward;

    }

    void OnDisable()
    {
        //newAttractors.Remove(this);
    }

    void newAttract(newAttractor objToAttract)
    {
        /*direction = A.position - B.position;
          distance = direction.magnitude;

          if (distance == 0f)
              return;

          float forceMagnitude = G * (A.mass * B.mass) / Mathf.Pow(distance, 2);
         //Debug.Log("Gravity in  RB for: " + name + ": " + forceMagnitude);

          GravForce = direction.normalized * forceMagnitude;
         Debug.Log("Gravity for RB" + name + " is :" + GravForce);
         A.transform.Rotate(rotata * Time.deltaTime);

         /* A.AddForce(-GravForce);*/

        //----------------SELF MADE NICELY NICE STUFFY STUFF//------

        position = new Vec3(fx, fy, fz); // Planeta petit
        dir = sunPos - position;
        dist = Vec3.Distance(sunPos, position);

        float f = (G * bigMass * mass) / Mathf.Pow(dist, 2);
        Vec3 gravity = Vec3.Normalize(dir) * f;

        velocity.x = velocity.x + Time.deltaTime / 20 * gravity.x;
        velocity.y = velocity.y + Time.deltaTime / 20 * gravity.y;
        velocity.z = velocity.z + Time.deltaTime / 20 * gravity.z;

        // position = position + velocity * Time.deltaTime;
        fx = fx + velocity.x * Time.deltaTime;
        fy = fy + velocity.y * Time.deltaTime;
        fz = fz + velocity.z * Time.deltaTime;

        transform.position = new Vector3(position.x, position.y, position.z);



    }

}

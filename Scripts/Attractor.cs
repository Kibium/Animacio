

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Attractor : MonoBehaviour {

    LineRenderer forceline;
    int lengthLine = 2;
    //SELF MADE STUFF
    Vec3 position, velocity, dir, force, inter;
    public Slider slider;
    public Attractor attractor;
    Vec3 lastpos = Vec3.zero;
    public float fx,fy,fz;
    public float  mass, dist;
    private float delta = 0.33f;
    public  float bigMass;
    public static bool vectors = false;
    private Vec3 sunPos = Vec3.zero; // posició del sol en el sistema

	public static float G = 500f;
	

	/*public Rigidbody A;
    public Rigidbody B;
   // [SerializeField]
    float distance;

    //[SerializeField]
    Vector3 direction;

    //[SerializeField]
     Vector3 GravForce;*/

   // [SerializeField]
    public Vector3 speed;
    public Vector3 rotata;

    MyQuat q;
    


  void FixedUpdate ()
     {
        bigMass = Hole.bigMassa;
        if (attractor != null)
        {
            
            Attract(attractor);

        }

     }

     void Start ()
     {
        
        forceline = gameObject.AddComponent<LineRenderer>();
        forceline.widthMultiplier = 5.5f;
        forceline.positionCount = lengthLine;
        forceline.material = new Material(Shader.Find("Particles/Additive"));
 

        /*speedline = gameObject.AddComponent<LineRenderer>();
        speedline.widthMultiplier = 4.5f;
        speedline.positionCount = lengthLine;
        speedline.material = new Material(Shader.Find("Particles/Additive"));
        speedline.startColor = Color.green;
        speedline.endColor = Color.green;*/



        q = new MyQuat(transform.rotation);
        velocity = new Vec3(speed.x, speed.y, speed.z)*20;
        position = new Vec3(fx, fy ,fz);

        //inter = new Vec3(fx-fx / 3, fy-fy / 3, fz-fz / 3);
        //A.velocity = speed * 50;
        //velocity = Vec3.backward;

    }

   

     void Attract (Attractor objToAttract)
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

        position = new Vec3(fx,fy, fz); // Planeta petit
        dir = sunPos - position;
        dist = Vec3.Distance(sunPos, position);
        inter = new Vec3(fx - fx / 3, fy - fy / 3, fz - fz / 3);



        float f = (G * bigMass * mass) / Mathf.Pow(dist, 2);
        Vec3 gravity = Vec3.Normalize(dir) * f;

      
        velocity.x = velocity.x + slider.value/20 * gravity.x;
        velocity.y = velocity.y + slider.value / 20 * gravity.y;
        velocity.z = velocity.z + slider.value / 20 * gravity.z;


       // position = position + velocity * Time.deltaTime;
        fx = fx + velocity.x * slider.value;
        fy = fy + velocity.y * slider.value;
        fz = fz+ velocity.z * slider.value;

        q.y += 2 * Time.deltaTime;

        transform.position = new Vector3(position.x, position.y, position.z);
        transform.rotation = new Quaternion(q.x, q.y, q.z, q.w);

        Vector3 pos = new Vector3(position.x, position.y, position.z);
        Vector3 force = new Vector3(fx, fy, fz);
        Vector3 intt = new Vector3(inter.x, inter.y, inter.z);

        forceline.startColor = Color.red;
        forceline.endColor = Color.red;

        forceline.SetPosition(0, pos);
        forceline.SetPosition(1, force-pos/3); 

        

        //speedline.SetPosition(0, pos);
        //speedline.SetPosition(1, speed - pos / 3);


        //Debug.DrawLine(pos, (force - pos)/10, Color.red);
    }


}



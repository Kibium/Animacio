using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IK_FABRIK2 : MonoBehaviour
{
    public Transform[] joints;
    public Transform target;

    private Vec3[] copy, v3joints;
    private float[] distances;
    private bool done;

    public float maxIterations = 10;

    public float treshold_condition = 0.01f;

    void Start()
    {
        distances = new float[joints.Length - 1];
        copy = new Vec3[joints.Length];
    }

    void Update()
    {
        // 1.Copy the joints positions to work with. 
        //Calculate also the distances between joints
        //TODO1

        Vec3 tpos = new Vec3(target.position);

        copy[0] = new Vec3(joints[0].position);
        for (int i = 0; i < copy.Length - 1; i++)
        {
            Vec3 temp = new Vec3(joints[i + 1].position);
            copy[i + 1] = temp;
            distances[i] = Vec3.Distance(copy[i + 1], copy[i]);
        }


        //done = TODO2
        done = Vec3.Mod(copy[copy.Length - 1] - tpos) < treshold_condition;
        if (!done)
        {
            float targetRootDist = Vec3.Distance(copy[0], tpos);

            // Update joint positions
            if (targetRootDist > distances.Sum())
            {
                // The target is unreachable
                //TODO3

                for (int i = 0; i < copy.Length - 1; i++)
                {
                    float r = Vec3.Distance(tpos, copy[i]);
                    float lambda = distances[i] / r;
                    copy[i + 1] = (1 - lambda) * copy[i] + (lambda * tpos);

                }


            }
            else
            {
                float comvulguis = Vec3.Distance(tpos, copy[copy.Length - 1]);
                Vec3 b = copy[0];

                int iter = 0;
                // The target is reachable
                while (comvulguis > treshold_condition && iter < maxIterations)
                {


                    iter++;
                    // STAGE 1: FORWARD REACHING
                    //TODO

                    //Debug.Log("FABRIK iteration:" + iter);
                    copy[copy.Length - 1] = tpos;
                    for (int i = copy.Length - 2; i > 0; i--)
                    {
                        float r = Vec3.Distance(copy[i + 1], copy[i]);
                        float lambda = distances[i] / r;
                        copy[i] = (1 - lambda) * copy[i + 1] + (lambda * copy[i]);


                    }
                    // STAGE 2: BACKWARD REACHING
                    //TODO
                    copy[0] = b;
                    for (int i = 0; i < copy.Length - 1; i++)
                    {
                        float r = Vec3.Distance(copy[i + 1], copy[i]);
                        float lambda = distances[i] / r;
                        copy[i + 1] = (1 - lambda) * copy[i] + (lambda * copy[i + 1]);

                    }
                    comvulguis = Vec3.Distance(copy[copy.Length - 1], tpos);


                }
            }

            // Update original joint rotations
            for (int i = 0; i <= joints.Length - 2; i++)
            {
                //TODO4 
                //without rotations of the different pieces:
                //joints[i + 1].position = copy[i + 1];
                //with rotations of the different pieces:
                Vec3 temp1 = new Vec3(joints[i + 1].position);
                Vec3 temp2 = new Vec3(joints[i].position);

                Vec3 init =  temp1-temp2 ;
                Vec3 now =  copy[i + 1] - copy[i];

                //float angle = Mathf.Acos(Vector3.Dot(init.normalized, now.normalized))*Mathf.Rad2Deg;
                float cosa = Vec3.Dot(Vec3.Normalize(init), Vec3.Normalize(now));
                float sina = Vec3.Mod(Vec3.Cross(Vec3.Normalize(init), Vec3.Normalize(now)));

                float angle = Mathf.Atan2(sina, cosa) * Mathf.Rad2Deg;


                Vec3 axis = Vec3.Normalize(Vec3.Cross(init, now));


                MyQuat temp = new MyQuat(joints[i].rotation);
                MyQuat q = MyQuat.AngleAxis(angle, axis) * temp; 

                Quaternion trueQ = new Quaternion(q.x, q.y, q.z, q.w);
                joints[i].rotation =trueQ;
                Vector3 v = new Vector3(copy[i + 1].x, copy[i + 1].y, copy[i + 1].z);
                joints[i + 1].position = v;

            }
        }
    }

}
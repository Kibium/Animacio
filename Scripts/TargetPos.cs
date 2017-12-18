using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPos : MonoBehaviour {
    public GameObject g;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vec3 v = new Vec3(transform.position);

        if (Input.GetKey(KeyCode.A))
           v-= new Vec3(5, 0, 0);
        if (Input.GetKey(KeyCode.D))
           v += new Vec3(5, 0, 0);
        if (Input.GetKey(KeyCode.W))
            v += new Vec3(0, 0, 5);
        if (Input.GetKey(KeyCode.S))
           v -= new Vec3(0, 0, 5);

        g.transform.position = new Vector3(v.x, v.y, v.z);
        Debug.Log(g.transform.position);


    }
}

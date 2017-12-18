using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearPlaneta : MonoBehaviour {

    public newAttractor urthToCreate;
    public GameObject posToCreate;
    public Canvas canvas;

	// Use this for initialization

        public void createPlanet()
        { 
        if(GameObject.Find("Urth (1)(Clone)") == null)
        Instantiate(urthToCreate,new Vector3(posToCreate.transform.position.x, posToCreate.transform.position.y, posToCreate.transform.position.z),Quaternion.identity,canvas.transform);
  
    }
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

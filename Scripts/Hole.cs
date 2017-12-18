using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {
    float G = 1;
    public float radius = 0;

    [SerializeField]
    public static float bigMassa = 332950;
    
    public Attractor[] attractors;
    public newAttractor[] newAttractors;
    // Use this for initialization
    void Start () {
        radius = (2 * bigMassa * 2) / (299 * 299); // originalment 2m/c*c
      
    }

    void absorb()
    {
        for (int i = 0; i < attractors.Length; i++)
        {
            if (attractors[i] != null)
            {
                if (attractors[i].dist <= radius + 100)
                {
                    bigMassa += attractors[i].mass * 20; // la massa ja canvia si hi ha contacte amb un planeta
                    radius = (10 * bigMassa) / (299 * 299); // originalment 2m/c*c
                                                            
                    Attractor.G += (bigMassa / 332950) * 20;
                    Debug.Log(Attractor.G);
                    Destroy(attractors[i]);
                    attractors[i].gameObject.SetActive(false);
                    i += 1;
                    break;

                }
            }
        }
    }
   
      
    void absorbNewAttractor()
    {
        if (newAttractor.attract != null)
            {
                if (newAttractor.attract.dist <= radius + 50)
                 {
                    
                    bigMassa += newAttractor.attract.mass * 25; 
                    radius = (10 * bigMassa) / (299 * 299); 
                                                            
                    Attractor.G += (bigMassa / 332950) * 20;
                    Debug.Log(Attractor.G);
                    Destroy(newAttractor.attract);
                    newAttractor.attract.gameObject.SetActive(false);
                }

            
        }
    }
      
   
	// Update is called once per frame
	void Update () {
     
        absorb();
        absorbNewAttractor();
        
        transform.localScale = new Vector3(radius, radius, radius);
	}
}

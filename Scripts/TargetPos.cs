using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetPos : MonoBehaviour {
    public GameObject g;
    public GameObject cubeslider;

    public newAttractor urthToCreate;
    public GameObject posToCreate;
    public Canvas canvas;

    int y;
    static Vec3 v2, aux;
    // Use this for initialization
    void Start () {
        y = SceneManager.GetActiveScene().buildIndex;
        v2 = new Vec3(cubeslider.transform.position);
        aux = new Vec3(posToCreate.transform.position);
    }

    public void createPlanet()
    {
        if (GameObject.Find("Urth (1)(Clone)") == null)
            Instantiate(urthToCreate, new Vector3(aux.x, aux.y, aux.z), Quaternion.identity, canvas.transform);

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

        if (v.x <= -950)
            v.x = -950;

        if (v.x >= 800)
            v.x = 800;

        if (v.z >= -50)
            v.z = -50;

        if (v.z <= -550)
            v.z = -550;

        if (v2.x <= -630)
            v2.x = -630;

        if (v2.x >= -370)
            v2.x = -370;

        if (v.x >= -950 && v.x <= -650 && v.z >= -205 && v.z <= -125 && Input.GetKeyDown(KeyCode.J) && y==0 )
            SceneManager2.ChangeScene(1);

        if (v.x >= -950 && v.x <= -650 && v.z >= -205 && v.z <= -125 && Input.GetKeyDown(KeyCode.J) && y == 1)
            SceneManager2.ChangeScene(0);
        if (v.x >= -950 && v.x <= -650 && v.z >= -275 && v.z <= -214 && Input.GetKeyDown(KeyCode.J))
            Attractor.vectors *= -1;

        if (v.x >= -950 && v.x <= -650 && v.z >= -130 && v.z <= 30 && Input.GetKeyDown(KeyCode.J) && y == 1)
            createPlanet();

        if (v.x >= -950 && v.x <= -825 && v.z >= -535 && v.z <= -450 && Input.GetKeyDown(KeyCode.J) && v2.x >= -643)
        {
            v2.x -= 10;
            Attractor.delta -= 0.01f;
        }

        if (v.x >= -720 && v.x <= -520 && v.z >= -535 && v.z <= -450 && Input.GetKeyDown(KeyCode.J) && v2.x <= -389)
        {
            v2.x += 10;
            Attractor.delta += 0.01f;

        }




        g.transform.position = new Vector3(v.x, v.y, v.z);
        cubeslider.transform.position = new Vector3(v2.x, v2.y, v2.z);
        Debug.Log(g.transform.position);


    }

    public static Vec3 getPos()
    {
        return v2;
    }
}

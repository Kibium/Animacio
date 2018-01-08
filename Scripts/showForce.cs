using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class showForce : MonoBehaviour
{
    public Material m;
    public Attractor[] attractors;
    Vec3 pos;
    public Transform origin;
    private void Start()
    {
    }
    private void Update()
    {
        
    }

    private void OnPostRender()
    {
        RenderLines();
    }

    private void OnDrawGizmos()
    {

        RenderLines();
    }

    void RenderLines()
    {
        if (Attractor.vectors > 0)
        {
            for (int i = 0; i < attractors.Length; i++)
            {
                //FORCE VECTORS
                GL.PushMatrix();
                GL.Begin(GL.LINES);
                m.SetPass(0);
                GL.Color(Color.red);
                GL.Vertex3(origin.position.x + 2 * attractors[i].transform.position.x / 3, origin.position.y + 2 * attractors[i].transform.position.y / 3, origin.position.z + 2 * attractors[i].transform.position.z / 3);
                GL.Vertex3(attractors[i].transform.position.x, attractors[i].transform.position.y, attractors[i].transform.position.z);

                GL.End();
                GL.PopMatrix();
           
                //SPEED VECTORS
                GL.PushMatrix();
                GL.Begin(GL.LINES);
                m.SetPass(0);
                GL.Color(Color.green);
                GL.Vertex3(attractors[i].position.x, attractors[i].position.y, attractors[i].position.z);
                GL.Vertex3(attractors[i].position.x + attractors[i].velocity.x, attractors[i].position.y + attractors[i].velocity.y, attractors[i].position.z + attractors[i].velocity.z);

                GL.End();
                GL.PopMatrix();
            }

        }
    }
}

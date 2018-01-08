using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager2 : MonoBehaviour {

    public void ChangeSceneButton(int scene)
    {
        Attractor.G = 500f;
        Hole.bigMassa = 332950;
        Application.LoadLevel(scene);
    }

    public static void ChangeScene(int scene)
    {
        Attractor.G = 500f;
        Hole.bigMassa = 332950;
        Application.LoadLevel(scene);
    }
}

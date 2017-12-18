using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawvectors : MonoBehaviour {
    public Button b;
	// Use this for initialization
	void Start () {
        Button btn = b.GetComponent<Button>();
        btn.onClick.AddListener(ToggleVectors);
    }
	
	// Update is called once per frame
	void ToggleVectors () {
        if (!Attractor.vectors)
        {
            Attractor.vectors = true;
            Debug.Log("ACTIVE");

        }
        else
            Attractor.vectors = false;
    }
}

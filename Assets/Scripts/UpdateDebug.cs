using UnityEngine;
using System.Collections;

public class UpdateDebug : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            AFDebug.Log("OXE ");
        }
    }
}

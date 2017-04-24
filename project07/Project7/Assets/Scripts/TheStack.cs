using System;
using System.Collections;
using UnityEngine;

public class TheStack : MonoBehaviour {
    private GameObject[] theStack;
    private int stackIndex;
    private int scoreCount = 0;

	// Use this for initialization
	private void Start () {
        theStack = new GameObject[transform.childCount];
        
        for (int i = 0; i < transform.childCount; i++) {
            theStack[i] = transform.GetChild(i).gameObject;
        }
        stackIndex = transform.childCount - 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 
            PlaceTitle();
            scoreCount++;
        }
	}

    private void PlaceTitle(){
        theStack[stackIndex].transform.localPosition = new Vector3(0, scoreCount, 0);
    }
}

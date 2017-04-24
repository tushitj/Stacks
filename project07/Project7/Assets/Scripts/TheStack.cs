using System;
using System.Collections;
using UnityEngine;

public class TheStack : MonoBehaviour
{
    private const float BOUND_SIZE = 3.5f;

    private GameObject[] theStack;

    private int stackIndex;
    private int scoreCount = 0;

    private float tileTransition = 0.0f;
    private float titleSpeed = 2.5f;

    // Use this for initialization
    private void Start()
    {
        theStack = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            theStack[i] = transform.GetChild(i).gameObject;
        }
        stackIndex = transform.childCount - 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (PlaceTitle())
            {
                SpawnTitle();
                scoreCount++;
            }
            else {
                EndGame();
            }
        }
        MoveTile();
    }

    private void MoveTile()
    {
        tileTransition += Time.deltaTime * titleSpeed;
        theStack[stackIndex].transform.localPosition = new Vector3(Mathf.Sin(tileTransition * BOUND_SIZE), scoreCount, 0);

    }

    private void EndGame()
    {

    }

    private void SpawnTitle()
    {
        stackIndex--;
        if (stackIndex < 0)
            stackIndex = transform.childCount - 1;
        theStack[stackIndex].transform.localPosition = new Vector3(0, scoreCount, 0);

    }
    private bool PlaceTitle()
    {
        return true;
    }
}

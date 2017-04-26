﻿using System;
using System.Collections;
using UnityEngine;

public class TheStack : MonoBehaviour
{
    private const float BOUND_SIZE = 3.5f;
	private const float STACK_MOVING_SPEED = 5.0f;
	private const float ERROR_MARGIN = 0.1f;

    private GameObject[] theStack;
	private Vector2 stackBounds = new Vector2 (BOUND_SIZE, BOUND_SIZE);

    private int stackIndex;
    private int scoreCount = 0;
	private int combo = 0;

    private float tileTransition = 0.0f;
    private float titleSpeed = 2.5f;
	private float secondaryPosition;

	private bool isMovingOfX = true;

	private Vector3 desiredPosition;
	private Vector3 lastTilePosition;


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
		transform.position = Vector3.Lerp (transform.position, desiredPosition, STACK_MOVING_SPEED * Time.deltaTime);
    }

    private void MoveTile()
    {
        tileTransition += Time.deltaTime * titleSpeed;
		if(isMovingOfX)
			theStack[stackIndex].transform.localPosition = new Vector3(Mathf.Sin(tileTransition) * BOUND_SIZE, scoreCount, secondaryPosition);
		else
			theStack[stackIndex].transform.localPosition = new Vector3(secondaryPosition, scoreCount, Mathf.Sin(tileTransition) * BOUND_SIZE);
    }

    private void EndGame()
    {

    }

    private void SpawnTitle()
    {
		lastTilePosition = theStack [stackIndex].transform.localPosition;
        stackIndex--;
        if (stackIndex < 0)
            stackIndex = transform.childCount - 1;

		desiredPosition = (Vector3.down) * scoreCount;
        theStack[stackIndex].transform.localPosition = new Vector3(0, scoreCount, 0);

    }
    private bool PlaceTitle()
	{
		Transform t = theStack [stackIndex].transform;

		if (isMovingOfX) {
			float deltaX = lastTilePosition - t.position.x;
			if (Mathf.Abs (deltaX) > ERROR_MARGIN) {
				combo = 0;
				stackBounds.x -= MAthf.Abs (deltaX);
				if (stackBounds.x <= 0)
					return false;

				float middle = lastTilePosition.x + t.localPositon.x / 2;
				t.localScale()

			}
		}
		secondaryPosition = (isMovingOfX)
			? t.localPosition.x
			: t.localPosition.z;
		
		isMovingOfX = !isMovingOfX;


        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRubble : MonoBehaviour {

	private void OnCollisonEnter(Collision col){
		Destroy (col.gameObject);
	}
}

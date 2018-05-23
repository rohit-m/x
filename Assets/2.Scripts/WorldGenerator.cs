using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour {

	public int worldSize;
	public float tileSize;
	public float waitTime;
	public float directionUpChance;
	public float directionLeftChance;
	public float directonRightChance;

	void Start() {
		StartCoroutine(GenLevel());
	}

	IEnumerator GenLevel() {
		// Generate Level
		for (int i = 0; i < worldSize; i++) {
			int dir = Random.Range (0f, 1f);
			TheCreator (dir);
			yield return new WaitForSeconds (waitTime);
		}

		yield return 0;
	}

	void DirGen(float randDir) {
		if (randDir < directionUpChance) {
			//Move up
			TheCreator (0);
		} else if (randDir < directionLeftChance) {
			//Move left
			TheCreator (3);
		} else if (randDir < directonRightChance) {
			//Move right
			TheCreator (2);
		} else {
			//Move down
			TheCreator (1);
		}
	}

	void TheCreator(int dir) {
		// Actual object that moves and makes the level
		switch (dir) {
		case 0:
			transform.position = new Vector3 (transform.position.x, transform.position.y + tileSize, 0);
				break;

		case 1:
			transform.position = new Vector3 (transform.position.x, transform.position.y - tileSize, 0);
				
				break;

		case 2:
			transform.position = new Vector3 (transform.position.x + tileSize, transform.position.y, 0);
				
				break;

		case 3:
			transform.position = new Vector3 (transform.position.x - tileSize, transform.position.y + tileSize, 0);
			break;
		}
	}
}

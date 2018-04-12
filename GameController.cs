using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	[SerializeField]
	public GameObject moleContainer;
	public Player player;

	[SerializeField]
	public TextMesh infoText;
	public float spawnDuration = 1.5f;
	public float spawnDecrement = 0.1f;
	public float minimumSpawnDuration = 0.5f;
	// Game lasts 30 seconds then starts over again
	public float GameTimer = 30f;
	// "Moles" are Avocados
	private Mole[] moles;
	private float spawnTimer = 0f;
	// Wait a few seconds to restart the game
	private float resetTimer = 3f;

	// Use this for initialization
	void Start () {
		// GetComponentsInChildren NOT GetComponentInChildren
		moles = moleContainer.GetComponentsInChildren<Mole> ();
		moles[Random.Range (0, moles.Length)].Rise ();
	}
	
	// Update is called once per frame
	void Update () {
		GameTimer -= Time.deltaTime;

		if (GameTimer > 0f) {
			infoText.text = "Hit all the avocados!\nTime: " + Mathf.Floor (GameTimer) + "\nScore: " + player.score;

			spawnTimer -= Time.deltaTime;

			if (spawnTimer <= 0f) {
				moles[Random.Range (0, moles.Length)].Rise ();
				spawnDuration -= spawnDecrement;

				if (spawnDuration <= minimumSpawnDuration) {
					spawnDuration = minimumSpawnDuration;
				}
				spawnTimer = spawnDuration;
			}
		} else {
			infoText.text = "Game Over! Your score: " + Mathf.Floor(player.score);
			resetTimer -= Time.deltaTime;

			if (resetTimer <= 0f) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		}
	}
}
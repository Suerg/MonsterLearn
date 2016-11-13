using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public BoardManager boardScript;
	[HideInInspector] public bool playersTurn = true;
	int tick = 0;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
		boardScript = GetComponent<BoardManager> ();
		InitGame ();

	}

	void InitGame()
	{
		boardScript.SetupScene (1);
	}
	// Update is called once per frame
	void Update () 
	{
		tick++;

		if (!playersTurn && tick % 2 == 0)
			playersTurn = true;	
	}

}

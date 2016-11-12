using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public BoardManager boardScript;

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
		boardScript.SetupScene (level);
	}
	// Update is called once per frame
	void Update () 
	{
	}

}

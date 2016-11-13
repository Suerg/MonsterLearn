using UnityEngine;
using System.Collections;

public class Player : MovingObject {
	public float restartLevelDelay = 1f;

	private Animator animator;

	// Use this for initialization
	protected override void Start () {
		animator = GetComponent<Animator>();
		base.Start();
	}

	protected override void AttemptMove <T> (int xDir, int yDir)
	{
		base.AttemptMove<T>(xDir, yDir);
		RaycastHit2D hit;
		GameManager.instance.playersTurn = false;
	}
	
	protected override void OnCantMove <T> (T component)
	{

	}

	// Update is called once per frame
	void Update () {
		if (!GameManager.instance.playersTurn)
			return;

		int horizontal = 0;
		int vertical = 0;

		horizontal = (int) Input.GetAxis("Horizontal");
		vertical = (int) Input.GetAxis("Vertical");
		
		animator.SetTrigger("playerWalk");

		if (horizontal != 0)
			vertical = 0;
		
		if (horizontal != 0 || vertical != 0)
		{
			AttemptMove<Obstacle> (horizontal, vertical);
			//animator.SetTrigger("playerWalk");
		}
	}
}

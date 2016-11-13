using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System;

public class damageCalculator : MonoBehaviour {
	const double BASE_DAMAGE = 10.0;
	public class Question{
		private string question;
		private float givenTime;
		private string[] choices = new string [4];
		private char correctAnswerChoice;
		private string explanation;
		private Stopwatch stopW;
		public Question(string currentQuestion, float timeAlloted, string[] options, char answer, string reason){
			question = currentQuestion;
			givenTime = timeAlloted;
			choices = options;
			answer = correctAnswerChoice;
			explanation = reason;
			stopW = new Stopwatch();
			stopW.Start();
		}

		public string getCharAnswer(int n){
			switch(n){
			case 0:
				return "a) ";
			case 1:
				return "b) ";
			case 2:
				return "c) ";
			case 3:
				return "d) ";
			}
		}

		public void printQuestion(){
			Debug.Log(question + "\n");
			for (int i = 0; i < 4; i++) {
				Debug.Log (getCharAnswer (i) + choices [i]);
				if (i == 1 || i == 3)
					Debug.Log ("\n");
			}
		}

		public bool checkAnswer(char selection){
			return (selection == correctAnswerChoice) ? true : false;
		}
		public float printAnswer(){
			Debug.Log ("The correct answer is: " + correctAnswerChoice + ".\n");
			Debug.Log (explanation + ".\n");
			return stopW.ElapsedMilliseconds ();
		}
	}

	// Use this for initialization
	void Start () {
		//do the battle scene
	}

	// Update is called once per frame
	void Update () {
		//don't know how to get timeGiven value
		float damage;
		if(checkAnswer()){
			damage = damageEquation (printAnswer(), timeGiven);
		}
	}

	float damageEquation(float timeDiff, float timeGiven){
		if (timeDiff <= (1 / 2) * timeGiven)
			return BASE_DAMAGE * (1.5);
		else if (timeDiff > timeGiven)
			return BASE_DAMAGE * (.65);
		else
			return BASE_DAMAGE;
	}
}

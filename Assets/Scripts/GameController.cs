using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour 
{
    public KeyCode restart;

    public Text playerLeftScore;
    public Text playerRightScore;
	public Text goalText;

    private Vector3 playerLeftOriginalPosition;
    private Vector3 playerRightOriginalPosition;
    private Vector3 pokeBallOriginalPosition;

    private GameObject playerLeft;
    private GameObject playerRight;
    private GameObject pokeball;
	private System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
    private bool goal = false;
    private int leftScore = 0;
    private int rightScore = 0;
	private static string emptyText = "";

	void Start()
    {
        initializeObjects();
        saveOriginalPositions();
        updateTexts();
    }

	void Update()
	{
		if (timer.IsRunning && timer.ElapsedMilliseconds > 2000) 
		{
			timer.Stop();
			restartPositions();
			Time.timeScale = 1;
			goalText.text = emptyText;
            goal = false;
        }

        if (Input.GetKey(restart))
        {
            timer.Stop();
            restartPositions();
            Time.timeScale = 1;
            goalText.text = emptyText;
            goal = false;
            leftScore = 0;
            rightScore = 0;
            updateTexts();
        }
	}

    public void updateLeftScore() 
    {
        if (!goal)
        {
            goal = true;
            leftScore++;
		    goalText.text = "GOOOOOOOAL of Player Left";
            updateTexts();
		    startGoalTimer();
        }
    }

    public void updateRightScore()
    {
        if (!goal)
        {
            goal = true;
            rightScore++;
            goalText.text = "GOOOOOOOAL of Player Right";
            updateTexts();
            startGoalTimer();
        }
    }

    private void updateTexts()
    {
        playerLeftScore.text = "Score: " + leftScore;
        playerRightScore.text = "Score: " + rightScore;
    }

	private void startGoalTimer()
	{
		timer.Reset();
		timer.Start ();
		Time.timeScale = 0.2f;		
	}

    private void initializeObjects()
    {
        playerLeft = GameObject.FindWithTag("PlayerLeft");
        playerRight = GameObject.FindWithTag("PlayerRight");
        pokeball = GameObject.FindWithTag("PokeBall");
    }

    private void saveOriginalPositions()
    {
        playerLeftOriginalPosition = playerLeft.transform.position;
        playerRightOriginalPosition = playerRight.transform.position;
        pokeBallOriginalPosition = pokeball.transform.position;
    }

    private void restartPositions()
    {
        playerLeft.transform.position = playerLeftOriginalPosition;
        playerLeft.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        playerRight.transform.position = playerRightOriginalPosition;
        playerRight.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        pokeball.transform.position = pokeBallOriginalPosition;
        Rigidbody2D pokeballRB = pokeball.GetComponent<Rigidbody2D>();
        pokeballRB.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        pokeballRB.GetComponent<Rigidbody2D>().angularVelocity = 0;
        pokeballRB.GetComponent<Rigidbody2D>().rotation = 0;
    }

}

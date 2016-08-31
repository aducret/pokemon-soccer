using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour 
{

    public Text playerLeftScore;
    public Text playerRightScore;

    private Vector3 playerLeftOriginalPosition;
    private Vector3 playerRightOriginalPosition;
    private Vector3 pokeBallOriginalPosition;

    private int leftScore = 0;
    private int rightScore = 0;

	void Start()
    {
        savePositions();
        updateTexts();
    }
	
	void Update()
    {

    }

    public void updateLeftScore() 
    {
        leftScore++;
        updateTexts();
    }

    public void updateRightScore()
    {
        rightScore++;
        updateTexts();
    }

    private void updateTexts()
    {
        playerLeftScore.text = "Score: " + leftScore;
        playerRightScore.text = "Score: " + rightScore;
        restartPositions();
    }

    private void savePositions()
    {
        playerLeftOriginalPosition = GameObject.FindWithTag("PlayerLeft").transform.position;
        playerRightOriginalPosition = GameObject.FindWithTag("PlayerRight").transform.position;
        pokeBallOriginalPosition = GameObject.FindWithTag("PokeBall").transform.position;
    }

    private void restartPositions()
    {
        GameObject.FindWithTag("PlayerLeft").transform.position = playerLeftOriginalPosition;
        GameObject.FindWithTag("PlayerRight").transform.position = playerRightOriginalPosition;
        GameObject.FindWithTag("PokeBall").transform.position = pokeBallOriginalPosition;
        GameObject.FindWithTag("PokeBall").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameObject.FindWithTag("PokeBall").GetComponent<Rigidbody2D>().angularVelocity = 0;
        GameObject.FindWithTag("PokeBall").GetComponent<Rigidbody2D>().rotation = 0;
    }

}

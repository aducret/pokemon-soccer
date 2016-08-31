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

    private GameObject playerLeft;
    private GameObject playerRight;
    private GameObject pokeball;

    private int leftScore = 0;
    private int rightScore = 0;

	void Start()
    {
        initializeObjects();
        saveOriginalPositions();
        updateTexts();
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

        playerRight.transform.position = playerRightOriginalPosition;

        pokeball.transform.position = pokeBallOriginalPosition;
        Rigidbody2D pokeballRB = pokeball.GetComponent<Rigidbody2D>();
        pokeballRB.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        pokeballRB.GetComponent<Rigidbody2D>().angularVelocity = 0;
        pokeballRB.GetComponent<Rigidbody2D>().rotation = 0;
    }

}

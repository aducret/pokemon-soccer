using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {

    public string position;

    private GameController gameController;

	void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
	}

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("PokeBall"))
        {
            if (position == "left")
            {
                gameController.updateRightScore();
            }
            else if (position == "right")
            {
                gameController.updateLeftScore();
            }
        }
    }

}

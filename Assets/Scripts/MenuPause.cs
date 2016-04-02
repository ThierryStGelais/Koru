using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour 
{
	public Button continueText;
	public Button restartText;
	public Button returnMenuText;
	public Button exitText;

    void Start ()
	{
		continueText = continueText.GetComponent<Button> ();
		restartText = restartText.GetComponent<Button> ();
		returnMenuText = returnMenuText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
	}

    void Update()
    {
        
	}

	public void Continue()

	{
        GameManager.Instance.getPlayersManager().GamePause();
    }

	public void Restart()

	{
        GameManager.Instance.getPlayersManager().GamePause();
		StartPoint.getStartPoint().GetComponent<StartPoint>().ResetLevel();
    }

	public void ReturnMenu()
	{
        GameManager.Instance.getPlayersManager().GamePause();
        SceneManager.LoadScene("Menu scene");
    }

	public void ExitGame()

	{
		Application.Quit();
	}

}
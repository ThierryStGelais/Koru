using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour 
{
	public Button startText;
	public Button creditsText;
	public Button exitText;

	void Start ()

	{
		startText = startText.GetComponent<Button> ();
		creditsText = creditsText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
	}

	void Update ()
	{

	}

	public void StartLevel()

	{
        SceneManager.LoadScene("Intro");
	}

	public void RollCredits()

	{
        SceneManager.LoadScene("Credits");
	}

	public void ExitGame()

	{
		Application.Quit();
	}

}
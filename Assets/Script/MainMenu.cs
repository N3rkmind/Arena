using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	public GameObject options, leaderboard, achievement, mainmenu;

	public void mainMenu()
	{
		mainmenu.SetActive (true);
		options.SetActive (false);
		leaderboard.SetActive (false);
		achievement.SetActive (false);
	}

	public void Options()
	{
		mainmenu.SetActive (false);
		options.SetActive (true);
		leaderboard.SetActive (false);
		achievement.SetActive (false);
	}

	public void Leaderboard()
	{
		mainmenu.SetActive (false);
		options.SetActive (false);
		leaderboard.SetActive (true);
		achievement.SetActive (false);
	}

	public void Achievement()
	{
		mainmenu.SetActive (false);
		options.SetActive (false);
		leaderboard.SetActive (false);
		achievement.SetActive (true);
	}

	public void PlayGame()
	{
		SceneManager.LoadScene ("Gym_Achievement");
	}
}

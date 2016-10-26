using UnityEngine;
using System.Collections;

[AddComponentMenu("AchievementCreator/Examples/ClickToCollect")]

public class ClickToCollect : MonoBehaviour
{
	public string achievementName = "Achievement name";
	public string pressA = "Achievement name";
	public int updateValue;

	private AchievementController controller;
	private AchievementWindow achievementWindow;

	//Initialization on game start.
	void Start()
	{
		controller = GameObject.Find ("AchievementController").GetComponent<AchievementController>();
		achievementWindow = GameObject.Find ("AchievementController").GetComponent<AchievementWindow> ();
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.A))
		{
			controller.UpdateAchievements(pressA, updateValue);
		}
	}

	//Mouse enter the object bounds.
	void OnMouseOver()
	{
		//Recoloring the object.
		GetComponent<Renderer>().material.color = Color.blue;

		//If we click on it, update the achievement.
		if(Input.GetMouseButtonDown(0))
		{
			//This is the actual updateing of the achievement.
			controller.UpdateAchievements(achievementName, updateValue);
			achievementWindow.RemoveAchievementClones ();
			achievementWindow.RefreshAchievementDisplay ();
			Destroy(gameObject);
		}
	}

	//Mouse exits the object.
	void OnMouseExit()
	{
		//Recoloring the object.
		GetComponent<Renderer>().material.color = Color.white;
	}
}

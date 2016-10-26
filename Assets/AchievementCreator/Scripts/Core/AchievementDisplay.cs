using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[AddComponentMenu("AchievementCreator/Core/AchievementDisplay")]
[RequireComponent(typeof(AudioSource))]

public class AchievementDisplay : MonoBehaviour
{
	public CanvasGroup displayUI;
	public Text displayText;
	public AudioClip completeSound;

	[Range(0, 15)] public int displayTime;
	private bool showAchievementUI;

	//Initialization on game start.
	void Awake()
	{
		displayText = displayUI.transform.GetChild(1).GetComponent<Text>();
		displayUI.alpha = 0;
	}

	//Running update every frame.
	void Update()
	{
		//Shows the Popup UI of the achievement.
		if(showAchievementUI)
		{
			displayUI.alpha = Mathf.Lerp(displayUI.alpha, 1, Time.fixedDeltaTime * 10);
		}
		
		//Fades the Popup UI of the achievement.
		else if(!showAchievementUI)
		{
			displayUI.alpha = Mathf.Lerp(displayUI.alpha, 0, Time.fixedDeltaTime * 10);
		}
	}

	//This function is called when an achievement is completed.
	public void DisplayAchievement(string name)
	{
		displayText.text = name;
		StartCoroutine("ShowAchievementUI");
	}

	//This function controlls the Popup UI show states.
	public IEnumerator ShowAchievementUI()
	{
		showAchievementUI = true;
		GetComponent<AudioSource>().PlayOneShot(completeSound);
		yield return new WaitForSeconds(displayTime);
		showAchievementUI = false;
	}
}

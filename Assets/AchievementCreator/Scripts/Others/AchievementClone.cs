using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[AddComponentMenu("AchievementCreator/Other/AchievementClone")]

public class AchievementClone : MonoBehaviour
{
	public Text nameText;
	public Text descriptionText;
	[Space(4)]
	public Image achievementIcon;
	public Image completeIcon;

	[HideInInspector]
	public Achievement myAchievement;
	
	void Start()
	{
		//Refreshing every information of this achievement clone.
		nameText.text = myAchievement.name;
		descriptionText.text = myAchievement.description;
		achievementIcon.sprite = myAchievement.icon;
		transform.gameObject.tag = "AchievementClone";

		//Adding extra information if required.
		if(myAchievement.showProgress && !myAchievement.isCompleted)
		{
			nameText.text = nameText.text + " [" + myAchievement.currentValue + "/" + myAchievement.requiredValue + "]";
		}

		//Hides the complete icon.
		if(!myAchievement.isCompleted)
		{
			completeIcon.color = new Color(completeIcon.color.r, completeIcon.color.g, completeIcon.color.b, 0f);
		}

		//Shows the complete icon.
		if(myAchievement.isCompleted)
		{
			completeIcon.color = new Color(completeIcon.color.r, completeIcon.color.g, completeIcon.color.b, 1f);
		}
	}
}

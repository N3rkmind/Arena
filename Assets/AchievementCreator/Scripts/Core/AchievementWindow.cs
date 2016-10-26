using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections;

[AddComponentMenu("AchievementCreator/Core/AchievementWindow")]
[RequireComponent(typeof(AudioSource))]

public class AchievementWindow : MonoBehaviour
{
	public CanvasGroup windowUI;
	public KeyCode openKey;
	[Space(4)]
	public Transform achievementClonePrefab;
	public LayoutGroup achievementHolder;
	[Space(4)]
	public AudioClip openSound;
	public AudioClip closeSound;

	private bool isShowing;
	private AchievementController controller;

	//Initialization on game start.
	void Awake()
	{
		controller = GetComponent<AchievementController>();

		windowUI.alpha = 0;
		RemoveAchievementClones();
	}

	//Running update every frame.
	void Update()
	{
		//Opening and closing the window via a key.
		if(Input.GetKeyDown(openKey))
		{
			isShowing = !isShowing;

			//Shows the window and instantiates the achievement clones.
			if(isShowing)
			{
				windowUI.alpha = 1;
				RefreshAchievementDisplay();
				GetComponent<AudioSource>().PlayOneShot(openSound);
			}

			//Hides the window and destroys all the achievement clones.
			else if(!isShowing)
			{
				windowUI.alpha = 0;
				RemoveAchievementClones();
				GetComponent<AudioSource>().PlayOneShot(closeSound);
			}
		}
	}

	//This function is called when we want to instantiate the achievement clones.
	public void RefreshAchievementDisplay()
	{
		for(int i = 0; i < controller.achievements.Length; i++)
		{
			Transform achievementClone = Instantiate(achievementClonePrefab, achievementHolder.transform.position, achievementHolder.transform.rotation) as Transform;
			achievementClone.SetParent(achievementHolder.transform, false);

			achievementClone.GetComponent<AchievementClone>().myAchievement = controller.achievements[i];
		}
	}

	//This function is called when we want to destroy the achievement clones.
	public void RemoveAchievementClones()
	{
		GameObject[] achievementClones = GameObject.FindGameObjectsWithTag("AchievementClone");

		if(achievementClones != null)
		{
			for(int a = 0; a < achievementClones.Length; a++)
			{
				Destroy(achievementClones[a].gameObject);
			}
		}
	}
}
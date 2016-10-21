using UnityEngine;
using UnityEditor;
using System.Collections;

[System.Serializable]
public class Achievement
{
	public string name;
	public string description;
	[Space(4)]
	public Sprite icon;
	[Space(4)]
	public int requiredValue;
	public int currentValue;
	[Space(4)]
	public bool showProgress;
	public bool isCompleted;

	[HideInInspector]
	public int completedBefore;
}

[AddComponentMenu("AchievementCreator/Core/AchievementController")]
[RequireComponent(typeof(AchievementDisplay))]

public class AchievementController : MonoBehaviour
{
	public Achievement[] achievements;
	private AchievementDisplay display;

	//Initialization on game start.
	void Awake()
	{
		display = GetComponent<AchievementDisplay>();
		LoadAchievements();

		//Debug.
		this.transform.gameObject.name = "AchievementController";
	}

	//This function is called when we want to update the achievements.
	public void UpdateAchievements(string updateName, int updateValue)
	{
		for(int i = 0; i < achievements.Length; i++)
		{
			//Loops through the achievements and checks what needs to be update.
			if(achievements[i].name == updateName)
			{
				//If the achievement is not completed yet, it will update the current progress of it.
				if(!achievements[i].isCompleted)
				{
					achievements[i].currentValue += updateValue;
					SaveAchievements(i, achievements[i].currentValue, achievements[i].completedBefore);
				}
				
				//If the achievement is completed shows the UI.
				if(achievements[i].currentValue >= achievements[i].requiredValue)
				{
					achievements[i].isCompleted = true;
					
					//If the Achievement is seen by the player already, it will not show up again.
					if(achievements[i].completedBefore == 0)
					{
						achievements[i].completedBefore = 1;
						display.DisplayAchievement(achievements[i].name);
						SaveAchievements(i, achievements[i].currentValue, achievements[i].completedBefore);
					}
				}
			}
		}
	}

	//Since PlayerPrefs doesn't support dynamic parameters, saving the Achievements individually.
	public void SaveAchievements(int place, int progress, int complete)
	{
		if(place == 0)
		{
			PlayerPrefs.SetInt("achProgress01", progress);
			PlayerPrefs.SetInt("achState01", complete);
		}
		else if(place == 1)
		{
			PlayerPrefs.SetInt("achProgress02", progress);
			PlayerPrefs.SetInt("achState02", complete);
		}
		else if(place == 2)
		{
			PlayerPrefs.SetInt("achProgress03", progress);
			PlayerPrefs.SetInt("achState03", complete);
		}
		else if(place == 3)
		{
			PlayerPrefs.SetInt("achProgress04", progress);
			PlayerPrefs.SetInt("achState04", complete);
		}
		else if(place == 4)
		{
			PlayerPrefs.SetInt("achProgress05", progress);
			PlayerPrefs.SetInt("achState05", complete);
		}
		else if(place == 5)
		{
			PlayerPrefs.SetInt("achProgress06", progress);
			PlayerPrefs.SetInt("achState06", complete);
		}
		else if(place == 6)
		{
			PlayerPrefs.SetInt("achProgress07", progress);
			PlayerPrefs.SetInt("achState07", complete);
		}
		else if(place == 7)
		{
			PlayerPrefs.SetInt("achProgress08", progress);
			PlayerPrefs.SetInt("achState08", complete);
		}
		else if(place == 8)
		{
			PlayerPrefs.SetInt("achProgress09", progress);
			PlayerPrefs.SetInt("achState09", complete);
		}
		else if(place == 9)
		{
			PlayerPrefs.SetInt("achProgress10", progress);
			PlayerPrefs.SetInt("achState10", complete);
		}
		else if(place == 10)
		{
			PlayerPrefs.SetInt("achProgress11", progress);
			PlayerPrefs.SetInt("achState11", complete);
		}
		else if(place == 11)
		{
			PlayerPrefs.SetInt("achProgress12", progress);
			PlayerPrefs.SetInt("achState12", complete);
		}
		else if(place == 12)
		{
			PlayerPrefs.SetInt("achProgress13", progress);
			PlayerPrefs.SetInt("achState13", complete);
		}
		else if(place == 13)
		{
			PlayerPrefs.SetInt("achProgress14", progress);
			PlayerPrefs.SetInt("achState14", complete);
		}
		else if(place == 14)
		{
			PlayerPrefs.SetInt("achProgress15", progress);
			PlayerPrefs.SetInt("achState15", complete);
		}
		else if(place == 15)
		{
			PlayerPrefs.SetInt("achProgress16", progress);
			PlayerPrefs.SetInt("achState16", complete);
		}
		else if(place == 16)
		{
			PlayerPrefs.SetInt("achProgress17", progress);
			PlayerPrefs.SetInt("achState17", complete);
		}
		else if(place == 17)
		{
			PlayerPrefs.SetInt("achProgress18", progress);
			PlayerPrefs.SetInt("achState18", complete);
		}
		else if(place == 18)
		{
			PlayerPrefs.SetInt("achProgress19", progress);
			PlayerPrefs.SetInt("achState19", complete);
		}
		else if(place == 19)
		{
			PlayerPrefs.SetInt("achProgress20", progress);
			PlayerPrefs.SetInt("achState20", complete);
		}
		else if(place == 20)
		{
			PlayerPrefs.SetInt("achProgress21", progress);
			PlayerPrefs.SetInt("achState21", complete);
		}
		else if(place == 21)
		{
			PlayerPrefs.SetInt("achProgress22", progress);
			PlayerPrefs.SetInt("achState22", complete);
		}
		else if(place == 22)
		{
			PlayerPrefs.SetInt("achProgress23", progress);
			PlayerPrefs.SetInt("achState23", complete);
		}
		else if(place == 23)
		{
			PlayerPrefs.SetInt("achProgress24", progress);
			PlayerPrefs.SetInt("achState24", complete);
		}
		else if(place == 24)
		{
			PlayerPrefs.SetInt("achProgress25", progress);
			PlayerPrefs.SetInt("achState25", complete);
		}
		else if(place == 25)
		{
			PlayerPrefs.SetInt("achProgress26", progress);
			PlayerPrefs.SetInt("achState26", complete);
		}
		else if(place == 26)
		{
			PlayerPrefs.SetInt("achProgress27", progress);
			PlayerPrefs.SetInt("achState27", complete);
		}
		else if(place == 27)
		{
			PlayerPrefs.SetInt("achProgress28", progress);
			PlayerPrefs.SetInt("achState28", complete);
		}
		else if(place == 28)
		{
			PlayerPrefs.SetInt("achProgress29", progress);
			PlayerPrefs.SetInt("achState29", complete);
		}
		else if(place == 29)
		{
			PlayerPrefs.SetInt("achProgress30", progress);
			PlayerPrefs.SetInt("achState30", complete);
		}
	}

	//Since PlayerPrefs doesn't support dynamic parameters, loading the Achievements individually.
	public void LoadAchievements()
	{
		for(int i = 0; i < achievements.Length; i++)
		{
			if(i == 0)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress01");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState01");
			}
			else if(i == 1)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress02");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState02");
			}
			else if(i == 2)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress03");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState03");
			}
			else if(i == 3)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress04");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState04");
			}
			else if(i == 4)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress05");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState05");
			}
			else if(i == 5)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress06");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState06");
			}
			else if(i == 6)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress07");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState07");
			}
			else if(i == 7)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress08");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState08");
			}
			else if(i == 8)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress09");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState09");
			}
			else if(i == 9)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress10");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState10");
			}
			else if(i == 10)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress11");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState11");
			}
			else if(i == 11)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress12");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState12");
			}
			else if(i == 12)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress13");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState13");
			}
			else if(i == 13)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress14");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState14");
			}
			else if(i == 14)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress15");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState15");
			}
			else if(i == 15)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress16");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState16");
			}
			else if(i == 16)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress17");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState17");
			}
			else if(i == 17)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress18");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState18");
			}
			else if(i == 18)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress19");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState19");
			}
			else if(i == 19)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress20");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState20");
			}
			else if(i == 20)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress21");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState21");
			}
			else if(i == 21)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress22");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState22");
			}
			else if(i == 22)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress23");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState23");
			}
			else if(i == 23)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress24");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState24");
			}
			else if(i == 24)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress25");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState25");
			}
			else if(i == 25)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress26");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState26");
			}
			else if(i == 26)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress27");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState27");
			}
			else if(i == 27)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress28");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState28");
			}
			else if(i == 28)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress29");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState29");
			}
			else if(i == 29)
			{
				achievements[i].currentValue = PlayerPrefs.GetInt("achProgress30");
				achievements[i].completedBefore = PlayerPrefs.GetInt("achState30");
			}
			
			//Checking if the Achievement is completed.
			if(achievements[i].currentValue >= achievements[i].requiredValue)
			{
				achievements[i].isCompleted = true;
			}
		}
	}
}

[CustomEditor(typeof(AchievementController))]
public class AchievementControllerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		if(GUILayout.Button("Delete Achievement Save"))
		{
			PlayerPrefs.DeleteKey("achProgress01");
			PlayerPrefs.DeleteKey("achState01");
			
			PlayerPrefs.DeleteKey("achProgress02");
			PlayerPrefs.DeleteKey("achState02");
			
			PlayerPrefs.DeleteKey("achProgress03");
			PlayerPrefs.DeleteKey("achState03");
			
			PlayerPrefs.DeleteKey("achProgress04");
			PlayerPrefs.DeleteKey("achState04");
			
			PlayerPrefs.DeleteKey("achProgress05");
			PlayerPrefs.DeleteKey("achState05");
			
			PlayerPrefs.DeleteKey("achProgress06");
			PlayerPrefs.DeleteKey("achState06");
			
			PlayerPrefs.DeleteKey("achProgress07");
			PlayerPrefs.DeleteKey("achState07");
			
			PlayerPrefs.DeleteKey("achProgress08");
			PlayerPrefs.DeleteKey("achState08");
			
			PlayerPrefs.DeleteKey("achProgress09");
			PlayerPrefs.DeleteKey("achState09");
			
			PlayerPrefs.DeleteKey("achProgress10");
			PlayerPrefs.DeleteKey("achState10");
			
			PlayerPrefs.DeleteKey("achProgress11");
			PlayerPrefs.DeleteKey("achState11");
			
			PlayerPrefs.DeleteKey("achProgress12");
			PlayerPrefs.DeleteKey("achState12");
			
			PlayerPrefs.DeleteKey("achProgress13");
			PlayerPrefs.DeleteKey("achState13");
			
			PlayerPrefs.DeleteKey("achProgress14");
			PlayerPrefs.DeleteKey("achState14");
			
			PlayerPrefs.DeleteKey("achProgress15");
			PlayerPrefs.DeleteKey("achState15");
			
			PlayerPrefs.DeleteKey("achProgress16");
			PlayerPrefs.DeleteKey("achState16");
			
			PlayerPrefs.DeleteKey("achProgress17");
			PlayerPrefs.DeleteKey("achState17");
			
			PlayerPrefs.DeleteKey("achProgress18");
			PlayerPrefs.DeleteKey("achState18");
			
			PlayerPrefs.DeleteKey("achProgress19");
			PlayerPrefs.DeleteKey("achState19");
			
			PlayerPrefs.DeleteKey("achProgress20");
			PlayerPrefs.DeleteKey("achState20");
			
			PlayerPrefs.DeleteKey("achProgress21");
			PlayerPrefs.DeleteKey("achState21");
			
			PlayerPrefs.DeleteKey("achProgress22");
			PlayerPrefs.DeleteKey("achState22");
			
			PlayerPrefs.DeleteKey("achProgress23");
			PlayerPrefs.DeleteKey("achState23");
			
			PlayerPrefs.DeleteKey("achProgress24");
			PlayerPrefs.DeleteKey("achState24");
			
			PlayerPrefs.DeleteKey("achProgress25");
			PlayerPrefs.DeleteKey("achState25");
			
			PlayerPrefs.DeleteKey("achProgress26");
			PlayerPrefs.DeleteKey("achState26");
			
			PlayerPrefs.DeleteKey("achProgress27");
			PlayerPrefs.DeleteKey("achState27");
			
			PlayerPrefs.DeleteKey("achProgress28");
			PlayerPrefs.DeleteKey("achState28");
			
			PlayerPrefs.DeleteKey("achProgress29");
			PlayerPrefs.DeleteKey("achState29");
			
			PlayerPrefs.DeleteKey("achProgress30");
			PlayerPrefs.DeleteKey("achState30");
			
			Debug.Log("Achievements save has been deleted.");
		}
	}
}

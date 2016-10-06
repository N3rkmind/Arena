using UnityEngine;
using System.Collections;

public class Atk_Melee : MonoBehaviour {

    #region DECLARATION
    // CONST

    // PRIVATE
    private MeshCollider MeleeTrigger;

    // PUBLIC

    #endregion

    #region UNITY METHODE
    void Awake ()
    {
        MeleeTrigger = gameObject.transform.FindChild("Melee_Trigger").GetComponent<MeshCollider>();

        MeleeTrigger.enabled = false;
    }

	void Start ()
    {
	    
	}

	void Update ()
    {
        
	}
    #endregion
}
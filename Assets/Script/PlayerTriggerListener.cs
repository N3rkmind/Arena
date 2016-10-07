using UnityEngine;
using System.Collections;

public class PlayerTriggerListener : MonoBehaviour {

    #region DECLARATION
    // CONST
    private const string MELEE_TRIGGER_NAME = "Melee_Trigger";

    // PRIVATE
    private MeshCollider ownMeleeTrigger;

    // PUBLIC

    #endregion

    #region UNITY METHODE
    void Awake()
    {
        ownMeleeTrigger = gameObject.transform.FindChild(MELEE_TRIGGER_NAME).GetComponent<MeshCollider>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == MELEE_TRIGGER_NAME)
        {
            if (col != ownMeleeTrigger)
            {
                //TODO: Call a methode on an player stats script insted
                print("HIT!");
            }
        }
    }
    #endregion
}
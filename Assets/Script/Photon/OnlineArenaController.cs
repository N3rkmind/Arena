using UnityEngine;
using System.Collections;

public class OnlineArenaController : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Joining game scene with " + PhotonNetwork.playerList.Length.ToString() + " players");
    }
}

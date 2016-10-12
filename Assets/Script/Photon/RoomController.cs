using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomController : MonoBehaviour
{
    public GameObject playerList;
    public GameObject playerPrefab;

    public Button startGameButton;

    private void Start()
    {
        foreach (PhotonPlayer p in PhotonNetwork.playerList)
            SpawnPlayer(p);

        if (PhotonNetwork.isMasterClient)
            startGameButton.interactable = true;
    }

    private void OnPhotonPlayerConnected(PhotonPlayer p)
    {
        SpawnPlayer(p);
    }

    private void SpawnPlayer(PhotonPlayer p)
    {
        var go = Instantiate(playerPrefab) as GameObject;
        go.transform.SetParent(playerList.transform);

        var txts = go.GetComponentsInChildren<Text>();
        txts[0].text = p.name;
    }

    public void StartGameButton()
    {
        GetComponent<PhotonView>().RPC("StartGame", PhotonTargets.All);
    }

    [PunRPC]
    private void StartGame()
    {
        SceneManager.LoadScene("Gym_OnlineArena");
    }
}
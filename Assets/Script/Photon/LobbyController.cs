using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public Text info;
    public Text userName;

    public GameObject gameContainer;
    public GameObject gamePrefab;

    public void Init()
    {
        info.text = "Initializing... please wait";
        PhotonNetwork.playerName = "User" + (Random.Range(0, 9000).ToString());
        userName.text = PhotonNetwork.playerName;
        ConnectToMaster();
    }

    private void ConnectToMaster()
    {
        PhotonNetwork.ConnectUsingSettings("0");
    }

    public void Refresh()
    {
        info.text = "Refreshing..";

        foreach (RoomInfo game in PhotonNetwork.GetRoomList())
        {
            var go = Instantiate(gamePrefab) as GameObject;
            go.transform.SetParent(gameContainer.transform);

            var txts = go.GetComponentsInChildren<Text>();

            txts[0].text = game.name;
            txts[1].text = "Players: " + game.playerCount + "/" + game.maxPlayers;

            var i = game;
            go.GetComponent<Button>().onClick.AddListener(() => JoinRoom(i));
        }
    }

    public void CreateGame()
    {
        info.text = "Creating a room...";
        PhotonNetwork.CreateRoom(Random.Range(0,9999).ToString());
    }

    public void JoinRoom(RoomInfo room)
    {
        PhotonNetwork.JoinRoom(room.name);
    }

    #region photon callback

    public virtual void OnConnectedToMaster()
    {
        info.text = "Connected to Master server!";
        Refresh();
    }

    public virtual void OnJoinedLobby()
    {
        info.text = "We've joined a lobby!";
    }

    public virtual void OnReceivedRoomListUpdate()
    {
        info.text = "Done Refreshing!";
    }

    public virtual void OnJoinedRoom()
    {
        info.text = "We've joined a Room!";
        SceneManager.LoadScene("Gym_Room");
    }

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager: MonoBehaviourPunCallbacks
{
    public enum AvatarType { Cactus, Robot, Unicorn };
    public AvatarType avatarType = AvatarType.Cactus;
    

    public override void OnEnable()
    {
        base.OnEnable();
        ExitGames.Client.Photon.Hashtable newProperties = new 
        ExitGames.Client.Photon.Hashtable();
        newProperties.Add("avatarType", avatarType.ToString());


        //PhotonNetwork.LocalPlayer.SetCustomProperties(properties);
    }

    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
    }

    void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try Connect To Server...");
    }



    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Server.");
        base.OnConnectedToMaster();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a Room");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new player joined the room.");
        Debug.Log("The new player's avatar is spawned" + newPlayer.CustomProperties["avatarType"].ToString());
        base.OnPlayerEnteredRoom(newPlayer);
    }

}

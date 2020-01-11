using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System;

public class NetworkManager : MonoBehaviourPunCallbacks, IMatchmakingCallbacks, IOnEventCallback
{
	public const byte InstantiateVrAvatarEventCode = 1; // example code, change to any value between 1 and 199

    public byte CustomManualInstantiationEventCode;
    public GameObject PlayerPrefab;
    public GameObject player;

    static public NetworkManager Instance;


    private void OnEnable()
	{
		PhotonNetwork.AddCallbackTarget(this);
        Debug.Log("started game");
        OnJoinedRoom();
        //SpawnPlayer();
    }

    #region Singleton
    public static NetworkManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    

    public void SpawnPlayer()
    {
        GameObject player = Instantiate(PlayerPrefab);
        PhotonView photonView = player.GetComponent<PhotonView>();

        if (PhotonNetwork.AllocateViewID(photonView))
        {
            object[] data = new object[]
            {
            player.transform.position, player.transform.rotation, photonView.ViewID
            };

            RaiseEventOptions raiseEventOptions = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others,
                CachingOption = EventCaching.AddToRoomCache
            };

            SendOptions sendOptions = new SendOptions
            {
                Reliability = true
            };

            PhotonNetwork.RaiseEvent(CustomManualInstantiationEventCode, data, raiseEventOptions, sendOptions);
        }
        else
        {
            Debug.LogError("Failed to allocate a ViewId.");

            Destroy(player);
        }
    }

    private void OnDisable()
	{
        Debug.Log("disabled_Room");
        PhotonNetwork.RemoveCallbackTarget(this);
	}

    #region IMatchmakingCallbacks

    public void OnJoinedRoom()
    {
        Instance = this;

        Debug.Log("joined_Room");
        //GameObject localAvatar = Instantiate(Resources.Load("LocalAvatar")) as GameObject;
        if (Photon.Pun.Demo.PunBasics.PlayerManagerSample.LocalPlayerInstance == null)
        {
            GameObject localAvatar = PhotonNetwork.Instantiate(this.PlayerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
            PhotonView photonView = localAvatar.GetComponent<PhotonView>();
            Debug.Log("PhotonViewId ---------------> " + photonView.ViewID);

            //if (PhotonNetwork.AllocateViewID(photonView))
            //{
            //	RaiseEventOptions raiseEventOptions = new RaiseEventOptions
            //	{
            //		CachingOption = EventCaching.AddToRoomCache,
            //		Receivers = ReceiverGroup.Others
            //	};

            //          PhotonNetwork.RaiseEvent(InstantiateVrAvatarEventCode, photonView.ViewID, raiseEventOptions, SendOptions.SendReliable);

            //      }
            //      else
            //{
            //	Debug.LogError("Failed to allocate a ViewId.");

            //	Destroy(localAvatar);
            //}
        }
        Debug.Log("Player count -------------->" + PhotonNetwork.CurrentRoom.PlayerCount);
    }

	public void OnFriendListUpdate(List<FriendInfo> friendList)
	{
	}

	public void OnCreatedRoom()
	{
        Debug.Log("room created");
	}

 

    public void OnCreateRoomFailed(short returnCode, string message)
	{
        Debug.Log("room created failed");
    }

	public void OnJoinRoomFailed(short returnCode, string message)
	{
        Debug.Log("room joined failed");
    }

	public void OnJoinRandomFailed(short returnCode, string message)
	{
        Debug.Log("random room joined");
    }

	


    #region Photon Callbacks

    /// <summary>
    /// Called when a Photon Player got connected. We need to then load a bigger scene.
    /// </summary>
    /// <param name="other">Other.</param>
    public override void OnPlayerEnteredRoom(Player other)
    {
        Debug.Log("OnPlayerEnteredRoom() " + other.NickName); // not seen if you're the player connecting

        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom

            LoadArena();
        }
    }

    /// <summary>
    /// Called when a Photon Player got disconnected. We need to load a smaller scene.
    /// </summary>
    /// <param name="other">Other.</param>
    public override void OnPlayerLeftRoom(Player other)
    {
        Debug.Log("OnPlayerLeftRoom() " + other.NickName); // seen when other disconnects

        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom

            LoadArena();
        }
    }

    /// <summary>
    /// Called when the local player left the room. We need to load the launcher scene.
    /// </summary>
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("PunBasics-Launcher");
    }

    #endregion

    public void OnEvent(EventData photonEvent)
    {


        //if (photonEvent.Code == CustomManualInstantiationEventCode)
        //{
        //    object[] data = (object[])photonEvent.CustomData;

        //    GameObject player = (GameObject)Instantiate(PlayerPrefab, (Vector3)data[0], (Quaternion)data[1]);
        //    PhotonView photonView = player.GetComponent<PhotonView>();
        //    photonView.ViewID = (int)data[2];
        //}
/*
        if (photonEvent.Code == InstantiateVrAvatarEventCode)
            {
                GameObject remoteAvatar = Instantiate(Resources.Load("RemoteAvatar")) as GameObject;
                PhotonView photonView = remoteAvatar.GetComponent<PhotonView>();
                photonView.ViewID = (int)photonEvent.CustomData;
            }
        */

    }
    #region Private Methods

    void LoadArena()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
        }

        Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);

        PhotonNetwork.LoadLevel("SampleScene");
    }

    #endregion




    #endregion


}

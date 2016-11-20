using UnityEngine;
using System.Collections;

namespace PUNTutorial
{
    public class GameManager : Photon.PunBehaviour
    {
        public static GameManager instance;
        public static GameObject localPlayer;

        void Start()
        {
            PhotonNetwork.ConnectUsingSettings("PuzzleMaze");
        }

        void Awake()
        {
                if (instance != null)
            {
                DestroyImmediate(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            instance = this;
            PhotonNetwork.automaticallySyncScene = true;
        }

        public void JoinGame()
        {
                RoomOptions ro = new RoomOptions();
                PhotonNetwork.JoinOrCreateRoom("Default Room", ro, null);

        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Joined Room");

            if (PhotonNetwork.isMasterClient)
            {
                PhotonNetwork.LoadLevel("Level");
            }
        }

        void OnLevelWasLoaded(int levelNumber)
        {
            if (!PhotonNetwork.inRoom) return;
            if (!PhotonNetwork.isMasterClient)
            {
                localPlayer = PhotonNetwork.Instantiate(
                    "Player",
                    new Vector3(0, 12f, 0), Quaternion.identity, 0);
            }
        }


    }
}
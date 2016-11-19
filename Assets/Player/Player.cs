using UnityEngine;
using System.Collections;

namespace PUNTutorial
{
    public class Player : Photon.PunBehaviour
    {
        Camera playerCam;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            playerCam = GetComponentInChildren<Camera>();

            if (!photonView.isMine)
            {
                playerCam.gameObject.SetActive(false);
            }
        }
    }
}
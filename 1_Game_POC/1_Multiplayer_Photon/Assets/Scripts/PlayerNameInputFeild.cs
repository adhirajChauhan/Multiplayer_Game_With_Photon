using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;



namespace indieGamer.Multiplayer
{
    [RequireComponent(typeof(InputField))]
    public class PlayerNameInputFeild : MonoBehaviour
    {
        //Store the playerpref key to avoid typos
        const string playerNamePrefKey = "PlayerName";

        private void Start()
        {
            string defaultName = string.Empty;
            InputField _inputFeild = this.GetComponent<InputField>();

            if (_inputFeild != null)
            {
                if (PlayerPrefs.HasKey(playerNamePrefKey))
                {
                    defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                    _inputFeild.text = defaultName;
                }
            }

            PhotonNetwork.NickName = defaultName;
        }


        public void SetPlayerName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                Debug.LogError("Player Name is null or empty");
                return;
            }

            PhotonNetwork.NickName = value;

            PlayerPrefs.SetString(playerNamePrefKey, value);
        }

    }
}

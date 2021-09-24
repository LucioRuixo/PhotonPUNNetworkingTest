using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField playerNameImputField = null;
    [SerializeField] Button continueButton = null;

    const string PlayerPrefsNameKey = "PlayerName";

    void Awake()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefsNameKey))
        {
            PlayerPrefs.SetString(PlayerPrefsNameKey, PlayerPrefsNameKey);
            PlayerPrefs.Save();
        }
    }

    void Start() => SetInputField();

    void SetInputField()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefsNameKey)) return;

        playerNameImputField.text = PlayerPrefs.GetString(PlayerPrefsNameKey);
    }

    public void SetPlayerName() => continueButton.interactable = !string.IsNullOrEmpty(playerNameImputField.text);

    public void SavePlayerName()
    {
        string playerName = playerNameImputField.text;

        PhotonNetwork.NickName = playerName;

        PlayerPrefs.SetString(PlayerPrefsNameKey, playerName);
        PlayerPrefs.Save();
    }
}
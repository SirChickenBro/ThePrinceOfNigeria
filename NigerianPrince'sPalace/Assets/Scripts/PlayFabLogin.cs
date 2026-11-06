using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class PlayFabLogin : MonoBehaviour
{
    [SerializeField] private GameObject signInDisplay = default;
    [SerializeField] private TMP_InputField usernameInput = default;
    [SerializeField] private TMP_InputField emailInput = default;
    [SerializeField] private TMP_InputField passwordInput = default;

    public static string SessionTicket;

    public void CreateAccount()
    {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest
        {
            Username = usernameInput.text,
            Email = emailInput.text,
            Password = passwordInput.text,
        }, result =>
        {
            SessionTicket = result.SessionTicket;
            signInDisplay.SetActive(false);
        }, error =>
        {
            Debug.LogError(error.GenerateErrorReport());
        });
    }

    public void SignIn()
    {
    PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
    {
        Username = usernameInput.text,
        Password = passwordInput.text,
    }, result =>
    {
        SessionTicket = result.SessionTicket;
        signInDisplay.SetActive(false);
    }, error =>
    {
        Debug.LogError(error.GenerateErrorReport());
    });
}
}

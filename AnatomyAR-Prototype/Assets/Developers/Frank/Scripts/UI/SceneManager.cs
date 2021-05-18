using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private InputField userNameInput = null;
    [SerializeField] private InputField emailInput = null;
    [SerializeField] private InputField passwordInput = null;
    [SerializeField] private InputField confirmPassInput = null;
    [SerializeField] private Text debug = null;

    [SerializeField] private GameObject registerUI = null;
    [SerializeField] private GameObject loginUI = null;

    private NetworkManager networkManager = null;

    private void Awake() {
        networkManager = GameObject.FindObjectOfType<NetworkManager>();
    }

    public void sumbitRegister() {

        if (userNameInput.text == "" || emailInput.text == "" || passwordInput.text == "" ||confirmPassInput.text == "") {
            debug.text = "Campos vacíos";
            return;
        }

        if (passwordInput.text == confirmPassInput.text) {

            debug.text = "processing...";

            networkManager.createUser(userNameInput.text, emailInput.text, passwordInput.text, delegate(Response response) {
                debug.text = response._message;
            });

        } else {
            debug.text = "Contraseñas diferentes!";
        }
    }

    public void showLogin() {
        registerUI.SetActive(false);
        loginUI.SetActive(true);
    }

    public void showRegister() {
        registerUI.SetActive(true);
        loginUI.SetActive(false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{

    public void createUser(string userName, string email, string pass, Action<Response> response) {
        StartCoroutine(coroutineCreateUser(userName, email, pass, response));
    }

    private IEnumerator coroutineCreateUser(string userName, string email, string pass, Action<Response> response) {
        WWWForm _form = new WWWForm();
        _form.AddField("userName", userName);
        _form.AddField("email", email);
        _form.AddField("pass", pass);

        WWW _w = new WWW("http://localhost/Anatomy_AR/createUser.php", _form);

        yield return _w;

        response(JsonUtility.FromJson<Response>(_w.text));
    }

}

[Serializable]
public class Response {
    public bool _done = false;
    public string _message = "";
}

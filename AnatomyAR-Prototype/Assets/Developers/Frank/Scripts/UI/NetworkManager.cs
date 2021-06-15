using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

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

        //WWW _w = new WWW("http://localhost/Anatomy_AR/php/createUser.php", _form);
        
        //WWW _w = new WWW("http://anatomyar.great-site.net/createUser.php", _form);

        UnityWebRequest _www = UnityWebRequest.Post("http://anatomyar.great-site.net/createUser.php", _form);

        yield return _www.SendWebRequest();
        Debug.Log(_www.downloadHandler.text);

        /*if (_www.isNetworkError || _www.isHttpError) {

            Debug.LogError(_www.error);

        } else {
            Debug.Log(_www.downloadHandler.text);
            //response(JsonUtility.FromJson<Response>(_www.downloadHandler.text));
        }*/
    }

    public void checkUser(string userName, string pass, Action<Response> response) {
        StartCoroutine(coroutineCheckUser(userName, pass, response));
    }

    private IEnumerator coroutineCheckUser(string userName, string pass, Action<Response> response) {
        WWWForm _form = new WWWForm();
        _form.AddField("userName", userName);
        _form.AddField("pass", pass);

        //WWW _w = new WWW("http://localhost/Anatomy_AR/checkUser.php", _form);
        //WWW _w = new WWW("http://anatomyar.great-site.net/checkUser.php", _form);
        UnityWebRequest _www = UnityWebRequest.Get("http://anatomyar.great-site.net/checkUser.php");

        yield return _www.SendWebRequest();
        Debug.Log(_www.downloadHandler.text);

        /*if (_www.isNetworkError || _www.isHttpError) {

            Debug.LogError(_www.error);

        } else {
            Debug.Log(_www.downloadHandler.text);
            //response(JsonUtility.FromJson<Response>(_www.downloadHandler.text));
            
        }*/
    }

}

[Serializable]
public class Response {
    public bool _done = false;
    public string _message = "";
}

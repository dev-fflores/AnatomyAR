using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public Image _timeCount;
    float _currentTime = 0f;
    private float _endTime = 30f;

    void Update() {
        _currentTime += Time.deltaTime;
        _timeCount.fillAmount = _currentTime / _endTime;
        if (_currentTime >= _endTime) 
        {
            SceneManager.LoadScene("LoginAndRegister");
        }
    }
}

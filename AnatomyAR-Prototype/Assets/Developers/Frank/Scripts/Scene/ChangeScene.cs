using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    float _startTime; 
    private float _endTime = 4.0f;

    void Update() {
        _startTime += Time.deltaTime;//Función para que la variable tiempo_start vaya contando segundos.
        if (_startTime >= _endTime) //Si pasan los segundos que hemos puesto antes...
        {
            SceneManager.LoadScene("LoginAndRegister");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class RotateAnim : MonoBehaviour
{
    public GameObject _vbRotate;
    public Animator _skeletonAnim;
    // Start is called before the first frame update
    void Start()
    {
        _vbRotate = GameObject.Find("vb_rotate");
        _vbRotate.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        _vbRotate.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
        _skeletonAnim.GetComponent<Animator>();
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        _skeletonAnim.Play("skeleton_rotation");
        Debug.Log("btn pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        _skeletonAnim.Play("none");
        Debug.Log("btn released");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

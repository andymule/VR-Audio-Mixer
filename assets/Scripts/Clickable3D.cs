using UnityEngine;
using System.Collections;

public class Clickable3D : MonoBehaviour
{
    private GameObject _lockedObject = null;
    public float _pullPower = 100.0f;
    //public float rotationSpeed = 10.0f;

    void OnMouseDown()
    {
        _lockedObject = this.gameObject;
    }
    void OnMouseDrag()
    {
        if (_lockedObject == null)
            return;
        float nearfar = Input.GetAxis("Mouse Y") * _pullPower;
        float leftright = Input.GetAxis("Mouse X") * _pullPower;
        nearfar *= Time.deltaTime;
        leftright *= Time.deltaTime;

        // TODO fix these to move relative to camera's current position
        _lockedObject.GetComponent<Rigidbody>().AddRelativeForce(leftright, 0f, nearfar, ForceMode.Impulse);
    }
    void OnMouseUp()
    {
        _lockedObject = null;
        Behaviour halo = (Behaviour)GetComponent("Halo");
        halo.enabled = false; // false
    }
    void OnMouseEnter()
    {
        // TODO also highlight when selected in VR
        // TODO TODO hook into VR hooks for real
        Behaviour halo = (Behaviour)GetComponent("Halo");
        halo.enabled = true; // false
    }
    void OnMouseExit()
    {
        if (_lockedObject != null)
            return;
        Behaviour halo = (Behaviour)GetComponent("Halo");
        halo.enabled = false; // false
    }
}
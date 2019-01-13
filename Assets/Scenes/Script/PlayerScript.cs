using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerControllerScript))]
public class PlayerScript : MonoBehaviour {

    public string hAxis = "Horizontal";
    public string vAxis = "Vertical";
    public float moveSpeed = 5;

    PlayerControllerScript controller;
    public float smooth = 1f;
    private Quaternion targetRotation;

    void Start()
    {
        controller = GetComponent<PlayerControllerScript>();
        targetRotation = transform.rotation;
    }

    void Update()
    {
        float axisX = Input.GetAxisRaw(hAxis);
        float axisY = Input.GetAxisRaw(vAxis);
        Vector3 moveInput = new Vector3(axisX, 0, axisY);
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        Vector3 axisRot = new Vector3(0, 90, 0);
        if (axisX > 0f)
        {
            transform.rotation = Quaternion.AngleAxis(90, axisRot);
        }
        else if (axisX < 0)
        {
            transform.rotation = Quaternion.AngleAxis(-90, axisRot);
        }
        else if (axisY > 0)
        {
            transform.rotation = Quaternion.AngleAxis(0, axisRot);
        }
        else if (axisY < 0)
        {
            transform.rotation = Quaternion.AngleAxis(180, axisRot);
        }
        if (axisX > 0 && axisY > 0)
        {
            transform.rotation = Quaternion.AngleAxis(45, axisRot);
        }
        else if (axisX < 0 && axisY > 0)
        {
            transform.rotation = Quaternion.AngleAxis(-45, axisRot);
        }
        else if (axisX > 0 && axisY < 0)
        {
            transform.rotation = Quaternion.AngleAxis(125, axisRot);
        }
        else if (axisX < 0 && axisY < 0)
        {
            transform.rotation = Quaternion.AngleAxis(-125, axisRot);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fast"))
        {
            this.moveSpeed = this.moveSpeed + 2;
            Destroy(other.gameObject);
        }
    }
}
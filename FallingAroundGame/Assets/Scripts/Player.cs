using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private Transform playerTransform;
    private Quaternion targetRotation;
    [SerializeField] private float smooth;
    protected override void Start()
    {
        playerTransform = GetComponent<Transform>();
        base.Start();
    }

    protected override void Update()
    {
        GetInput();

        base.Update();
    }

    private void GetInput()
    {
        direction = Vector3.zero;

        if(Input.GetKey(KeyCode.UpArrow))
        {
            targetRotation = Quaternion.Euler(0, 0, 0);
            //playerTransform.rotation = Quaternion.Euler(0, 270f, 0);
            playerTransform.rotation = Quaternion.RotateTowards
                (
                    playerTransform.rotation,
                    targetRotation,
                    Time.deltaTime * smooth
                );
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            targetRotation = Quaternion.Euler(0, 270, 0);
            //playerTransform.rotation = Quaternion.Euler(0, 270f, 0);
            playerTransform.rotation = Quaternion.RotateTowards
                (
                    playerTransform.rotation, 
                    targetRotation, 
                    Time.deltaTime * smooth
                );
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            targetRotation = Quaternion.Euler(0, 180, 0);
            //playerTransform.rotation = Quaternion.Euler(0, 270f, 0);
            playerTransform.rotation = Quaternion.RotateTowards
                (
                    playerTransform.rotation,
                    targetRotation,
                    Time.deltaTime * smooth
                );
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            targetRotation = Quaternion.Euler(0, 90, 0);
            //playerTransform.rotation = Quaternion.Euler(0, 270f, 0);
            playerTransform.rotation = Quaternion.RotateTowards
                (
                    playerTransform.rotation,
                    targetRotation,
                    Time.deltaTime * smooth
                );
            direction += Vector3.right;
        }
        if(Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            targetRotation = Quaternion.Euler(0, 45, 0);
            //playerTransform.rotation = Quaternion.Euler(0, 270f, 0);
            playerTransform.rotation = Quaternion.RotateTowards
                (
                    playerTransform.rotation,
                    targetRotation,
                    Time.deltaTime * smooth
                );
        }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            targetRotation = Quaternion.Euler(0, 315, 0);
            //playerTransform.rotation = Quaternion.Euler(0, 270f, 0);
            playerTransform.rotation = Quaternion.RotateTowards
                (
                    playerTransform.rotation,
                    targetRotation,
                    Time.deltaTime * smooth
                );
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            targetRotation = Quaternion.Euler(0, 135, 0);
            //playerTransform.rotation = Quaternion.Euler(0, 270f, 0);
            playerTransform.rotation = Quaternion.RotateTowards
                (
                    playerTransform.rotation,
                    targetRotation,
                    Time.deltaTime * smooth
                );
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            targetRotation = Quaternion.Euler(0, 225, 0);
            //playerTransform.rotation = Quaternion.Euler(0, 270f, 0);
            playerTransform.rotation = Quaternion.RotateTowards
                (
                    playerTransform.rotation,
                    targetRotation,
                    Time.deltaTime * smooth
                );
        }
    }
}

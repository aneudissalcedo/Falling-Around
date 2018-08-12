using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public abstract class Character : MonoBehaviour
{
    [SerializeField] private float speed;
    protected Vector3 direction;
    private Rigidbody myRigidbody;
    public bool isMoving
    {
        get
        {
            return direction.x != 0 || direction.z != 0;
        }
    }

    protected Animator myAnimator;

	protected virtual void Start ()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
	}

	protected virtual void Update ()
    {
        HandleLayers();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        myRigidbody.velocity = direction.normalized * speed;
    }

    public void HandleLayers()
    {
        if(isMoving)
        {
            Debug.Log("Running");
            ActivateLayer("RunLayer");

            //myAnimator.SetFloat("x", direction.x);
            //myAnimator.SetFloat("z", direction.z);
        }
        else
        {
            Debug.Log("Idling");
            ActivateLayer("IdleLayer");
        }
    }

    public void ActivateLayer(string layerName)
    {
        for(int i=0; i<myAnimator.layerCount; i++)
        {
            myAnimator.SetLayerWeight(i, 0);
        }

        myAnimator.SetLayerWeight(myAnimator.GetLayerIndex(layerName), 1);
    }
}

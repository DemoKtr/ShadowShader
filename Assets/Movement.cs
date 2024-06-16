using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewEmptyCSharpScript : MonoBehaviour
{
    private Rigidbody rgBody;
    private Transform playerTransform;
    [SerializeField] InputAction wasd;
    private Vector2 movementInput;
    [SerializeField] public float movementSpeed;


    private void OnEnable()
    {
        wasd.Enable();
    }
    
    private void OnDisable()
    {
        wasd.Disable();
    }

    private void Start()
    {
        rgBody = GetComponent<Rigidbody>();
        playerTransform= transform.GetChild(0);
    }

    private void Update()
    {
        movementInput = wasd.ReadValue<Vector2>();
        if (movementInput.x != 0)
        {
            playerTransform.localScale = new Vector2(Mathf.Sign(movementInput.x),1);
        }
    }

    private void FixedUpdate()
    {
        rgBody.linearVelocity = movementInput * movementSpeed;
    }
}

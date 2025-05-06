using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;


public class BaseCharacterController : MonoBehaviour
{
    private Vector2 movementInput;
    [SerializeField] float movementSpeed;
    [Range(0,1)][SerializeField] private float slowedFactor;
    private bool isSlowed;

    private void Start()
    {
        isSlowed = false;
    }

    /// <summary>
    /// Movement function is called by the input system when the player presses a movement key.
    /// </summary>
    /// <param name="ctx">Content provided by Unity Input</param>
    public void Movement(CallbackContext ctx)
    {
        //MovementInput is set by unity events
        movementInput = ctx.ReadValue<Vector2>(); //comment

    }
    //This is now a FIXEDupdate
    private void FixedUpdate()
    {
        //var actualMovementSpeed = isSlowed ? movementSpeed * slowedFactor : movementSpeed;
        var actualMovementSpeed = movementSpeed;
        if(isSlowed) actualMovementSpeed *= slowedFactor;

        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * Time.deltaTime * actualMovementSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with " + collision.gameObject.name);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Swamp") || col.gameObject.CompareTag("HighGras"))
        {
            isSlowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Swamp") || col.gameObject.CompareTag("HighGras"))
        {
            isSlowed = false;
        }
    }

    private void CheckForEncounter()
    { 
        FightManager.Instance.CheckForEncounter();
    }
}

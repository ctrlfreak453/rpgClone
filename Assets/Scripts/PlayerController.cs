using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entitiy
{
    Vector2 movementDirection;
    Vector2 interactPosition;
    Vector2 lastMovementDirection;
    public float movementSpeed;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) /*|| Input.GetButtonDown("Fire1")*/)
        {
            Collider2D tmpInteract = Physics2D.OverlapBox(interactPosition, new Vector2(0.2f, 0.2f), 0f);
            if (tmpInteract != null && tmpInteract.GetComponent<Entitiy>() != null)
            {
                tmpInteract.GetComponent<Entitiy>().Interact();

            }
        }
    }

    private void FixedUpdate()
    {
        movementDirection = (Vector2.up * Input.GetAxisRaw("Vertical") +
                            Vector2.right * Input.GetAxisRaw("Horizontal"))
                            .normalized;

        interactPosition = transform.position + (Vector3)(lastMovementDirection * 0.6f);

        transform.position += (Vector3)movementDirection * movementSpeed * Time.deltaTime;

        if (movementDirection.sqrMagnitude > 0)
        {
            lastMovementDirection = movementDirection;
        }
    }
    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, interactPosition);

            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(interactPosition, new Vector2(0.2f, 0.2f));
        }
    }


    public override void Interact()
    {
        
    }

    public override void Die()
    {

    }

}

  

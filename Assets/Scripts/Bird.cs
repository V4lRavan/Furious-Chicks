using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float launchForce = 1100;
    [SerializeField] float maxDragDistance = 5;

    Vector2 startPosition;
    new Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;
    bool resetting;

    public bool IsDragging { get; private set; }

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        startPosition = rigidbody2D.position;
        rigidbody2D.isKinematic = true;
    }

    void OnMouseDown()
    {
        spriteRenderer.color = Color.red;
        IsDragging = true;
    }

    void OnMouseUp()
    {
        Vector2 currentPosition = rigidbody2D.position;
        Vector2 direction = startPosition - currentPosition;
        direction.Normalize();

        rigidbody2D.isKinematic = false;
        rigidbody2D.AddForce(direction * launchForce);
        GetComponent<AudioSource>().Play();

        spriteRenderer.color = Color.white;
        IsDragging = false;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 destinationPosition = mousePosition;

        float distance = Vector2.Distance(destinationPosition, startPosition);
        if (distance > maxDragDistance)
        {
            Vector2 direction = destinationPosition - startPosition;
            direction.Normalize();
            destinationPosition = startPosition + (direction * maxDragDistance);
        }

        if (destinationPosition.x > startPosition.x)
            destinationPosition.x = startPosition.x;
            
        rigidbody2D.position = destinationPosition;
    }   

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (resetting == false)
        {
            resetting = true;
            StartCoroutine(ResetAfterDelay());
        }
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);
        rigidbody2D.position = startPosition;
        rigidbody2D.isKinematic = true;
        rigidbody2D.velocity = Vector2.zero;
        resetting = false;
    }
}


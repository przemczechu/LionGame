using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTest : MonoBehaviour
{
    public float speed = 5f; // Pr�dko�� poruszania si� gracza

    void Update()
    {
        // Pobierz wej�cie gracza
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Oblicz wektor ruchu
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;

        // Przesu� gracza
        //this.transform.Translate(movement);

        // Oblicz wektor ruchu
        //Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;

        // Przesu� gracza
        transform.position += movement;

        /*
        // Opcjonalnie: Je�eli chcesz obraca� posta� w kierunku ruchu
        if (movement != Vector3.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }*/
    }
    /*
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Kolizja: " + collision.gameObject);
    }*/
    void OnTriggerEnter()
    {
        Debug.Log("Trigger enter: ");
    }
}

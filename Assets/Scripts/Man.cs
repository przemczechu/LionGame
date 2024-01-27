using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rigidbody2D;
    Transform lion;


    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        transform.GetChild(0).GetComponent<ManTrigger>().man = this;
        transform.GetChild(1).GetComponent<Trigger>().man = this;
    }

    bool ran;

    float timer = 0;
    private void FixedUpdate()
    {
        if(ran && timer <= 0)
        {
            Vector2 vector2 =transform.position - lion.transform.position;
            vector2 = vector2.normalized;
            rigidbody2D.GetComponent<Rigidbody2D>().velocity = vector2 * speed * Time.fixedDeltaTime;

            float katObrotu = Mathf.Atan2(-vector2.y,-vector2.x) * Mathf.Rad2Deg;
            Quaternion rotacja = Quaternion.Euler(0f, 0f, katObrotu);
            transform.rotation = rotacja;
            //  rigidbody2D.GetComponent<Rigidbody2D>().velocity = rigidbody2D.transform.right * -speed * 10f * Time.deltaTime;
        }
        else if(timer > 0)
        {
            timer = timer - Time.fixedDeltaTime;
            rigidbody2D.GetComponent<Rigidbody2D>().velocity = rigidbody2D.transform.right * -speed * Time.deltaTime;
        }
    }


    public void Ran(Transform lion)
    {
        this.lion = lion;
        ran = true;
    }

    public void Safe()
    {
        ran = false;
        rigidbody2D.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void Wall()
    {
        timer = 0.7f;
        float z = transform.rotation.z;
        transform.Rotate(new Vector3(0, 0,Random.Range(85f,265f)));
        Debug.Log(transform.rotation.z);
    }


 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{

    public GameObject fruitSlicedPrefab;
    Rigidbody2D rb;
    public float startforce = 15f;
     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up*startforce,ForceMode2D.Impulse);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Blade")
        {
            Vector3 direction = (collision.transform.position - transform.position).normalized;

            Quaternion rotaion = Quaternion.LookRotation(direction);
            Instantiate(fruitSlicedPrefab,transform.position,transform.rotation); 
            Debug.Log("Hit Watermelon");
                Destroy(gameObject);
            
        }
    }
}

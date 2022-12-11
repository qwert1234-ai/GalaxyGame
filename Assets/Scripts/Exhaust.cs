using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhaust : MonoBehaviour
{
    public SpriteRenderer bulletRenderer;
    public int damage = 10;


    float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3 (
            transform.position.x,
            transform.position.y + speed,
            0
        );
        if (transform.position.y > Screen.height) {
            Destroy(gameObject);
        }

    }
}

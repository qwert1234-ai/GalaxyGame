using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 5;


    float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = new Vector3 (
            transform.position.x,
            transform.position.y - speed,
            0
        );
        if (ScreenHelpers.IsPositionOnScreen(transform.position) == false) {
            Destroy(gameObject);
        }
    }
}

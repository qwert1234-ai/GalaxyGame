using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public GameObject bullet;
    public int health = 70;
    private SpriteRenderer spriteRenderer;
    private float halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        halfWidth = spriteRenderer.bounds.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        GameObject collidetObject = collider.gameObject;
        Exhaust exhaustScript = collidetObject.GetComponent<Exhaust>();
        if (exhaustScript != null) {
            health = health - exhaustScript.damage;
            Destroy(collidetObject);
            if(health <= 0) {
                Destroy(gameObject);
            }
        }
    }

    public void Shoot(){
        GameObject bulletClone = Instantiate(bullet);
        bulletClone.transform.position = transform.position;
        
    }
}

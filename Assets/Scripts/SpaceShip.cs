using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public GameObject bullet;

    public SpriteRenderer spriteRenderer;

    private float speed = 0.3f;
    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float halfWidth = spriteRenderer.bounds.size.x/2;
        float halfHeight = spriteRenderer.bounds.size.y/2;
        bool isKeyDown = Input.GetKey(KeyCode.LeftArrow);
        if (isKeyDown == true) {
            Vector3 newPosition = new Vector3(transform.position.x - speed, transform.position.y, 0);
            Vector3 checkPosition = new Vector3(newPosition.x - halfWidth, newPosition.y, 0);
            
            if (ScreenHelpers.IsPositionOnScreen(checkPosition) == true) {
                transform.position = newPosition;
            }
        }

        bool isKey = Input.GetKey(KeyCode.RightArrow);
        if (isKey == true) {
            Vector3 newPosition = new Vector3(transform.position.x + speed, transform.position.y, 0);
            Vector3 checkPosition = new Vector3(newPosition.x + halfWidth, newPosition.y, 0);
            if (ScreenHelpers.IsPositionOnScreen(checkPosition) == true) {
                transform.position = newPosition;
            }
            
        }


        bool isShot = Input.GetKeyUp(KeyCode.Space);
        if (isShot == true) {
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider) {
        GameObject otherObject = otherCollider.gameObject;
        EnemyBullet bulletScript = otherObject.GetComponent<EnemyBullet>();
        if(bulletScript != null){
            health = health - bulletScript.damage;
            Destroy(otherObject);
            if(health <= 0){
                Destroy(gameObject);
            }
        }
    }
}

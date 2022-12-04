using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public GameObject bullet;

    public SpriteRenderer spriteRenderer;

    float speed = 0.3f;

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

    
}

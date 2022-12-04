using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplEnemyGroup : BaseEnemyGroup
{

    public EnemyShip ship1;
    public EnemyShip ship2;
    public EnemyShip ship3;

    private int deirection = -1;
    private float speed = 0.1f;
    private List<EnemyShip> ships = new List<EnemyShip>();
    private System.Random generator = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        ships.Add(ship1);
        ships.Add(ship2);
        ships.Add(ship3);

        InvokeRepeating("GroupShoot", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        ships.RemoveAll(item => item == null);

        if (ship1 == null && ship2 == null && ship3 == null) {
            isAlive = false;
            CancelInvoke("GroupShoot");
        }

        if(deirection == -1){
            float min = GetLeftEdge();
            min += speed * deirection;
            if(min <= -9) {
                deirection *= -1;
                
            }else {
                transform.position = new Vector3 (
                    transform.position.x - speed,
                    transform.position.y,
                    0
                );
            }
        }else {
            float max = getRightEdge();
            max += speed * deirection;
            if(max >= 9) {
                deirection *= -1;
                
            }else {
                transform.position = new Vector3 (
                    transform.position.x + speed,
                    transform.position.y,
                    0
                );
            }
        }

    }

    float GetLeftEdge() {
        float minX = float.MaxValue;
        for(int i = 0; i < ships.Count; i ++) {
            if (ships[i].transform.position.x < minX) {
                minX = ships[i].transform.position.x;
            }
        }
        return minX;
    }
    float getRightEdge() {
        float maxX = float.MinValue;
        for(int i = 0; i < ships.Count; i ++) {
            if (ships[i].transform.position.x > maxX) {
                maxX = ships[i].transform.position.x;
            }
        }
        return maxX;
    }

    void GroupShoot() {
        int randomIndex = generator.Next(0, ships.Count - 1);
        ships[randomIndex].Shoot();
    }
}

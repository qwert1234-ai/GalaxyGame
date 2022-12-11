using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject firstGroupOriginal;
    private SimplEnemyGroup currentEnemyGroup;
    private int groupsCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        CreateNewGroup();
        groupsCount ++;
    }
    void Update()
    {
        if(currentEnemyGroup != null && currentEnemyGroup.isAlive == false)
        {
            Destroy(currentEnemyGroup.gameObject);
            if(groupsCount == 3) {
                SceneManager.LoadSceneAsync(SceneIDS.winSceneID);
            }else {
                CreateNewGroup();
                groupsCount ++;
            }
        }
    }

    void CreateNewGroup() 
    {
        GameObject newGroup = Instantiate(firstGroupOriginal);
        newGroup.transform.position = transform.position;
        currentEnemyGroup = newGroup.GetComponent<SimplEnemyGroup>();
    }
}

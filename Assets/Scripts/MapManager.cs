using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public void StartLevel1() {
        SceneManager.LoadSceneAsync(SceneIDS.levelSceneID);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    [SerializeField] int numberOfBlocks;

    //cached reference
    SceneLoader sceneLoader;

    public void CountNumberOfBlocks() 
    {
        numberOfBlocks++;
    }

    public void BlockWasBroken() 
    {
        numberOfBlocks--;
        if (numberOfBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
    
    private void Start() 
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
}

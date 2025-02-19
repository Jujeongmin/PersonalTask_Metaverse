using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "FlyingScene";

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag ("Player"))
        {            
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

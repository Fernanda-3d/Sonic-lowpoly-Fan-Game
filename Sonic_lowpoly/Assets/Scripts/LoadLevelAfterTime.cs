using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelAfterTime : MonoBehaviour
{

    [SerializeField] private float delayBeforeLoading = 2f;
    [SerializeField] private string sceneNameToLoad;
    

    private float timeElapsed;

    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }

    }
}

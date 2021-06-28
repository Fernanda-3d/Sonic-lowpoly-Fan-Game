using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnPlayer : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        SceneManager.LoadScene("SonicScene_Backup");
    }
}
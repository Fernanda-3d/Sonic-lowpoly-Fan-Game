using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds_inst : MonoBehaviour
{

    public GameObject clouds;
    public int xPos;
    public int yPos;
    public int zPos;

    public int cloudCount;

    Vector3 temp;


    void Start()
    {

        StartCoroutine(CloudDrop());
    }
    IEnumerator CloudDrop()
    {
      /*  temp = transform.localScale;
        temp.x += 0.05f;
        temp.y += 0.05f;
        temp.z += 0.05f;
        transform.localScale = temp; */

        while (cloudCount < 100)
        {
            xPos = Random.Range(-36, 108);
            yPos = Random.Range(1, 5);
            zPos = Random.Range(1, 5);
            Instantiate(clouds, new Vector3(xPos, yPos, zPos), Quaternion.identity);

            yield return new WaitForSeconds(0.01f);
            cloudCount += 1;
        }


      
    }

   
    
}

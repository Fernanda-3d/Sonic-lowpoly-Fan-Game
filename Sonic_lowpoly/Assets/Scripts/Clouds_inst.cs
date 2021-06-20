using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds_inst : MonoBehaviour
{

    public GameObject cloud1;
    public GameObject cloud2;
    public int xPos;
    public int yPos;
    public int zPos;

    public int xPos2;
    public int yPos2;
    public int zPos2;

   // float minScale = 0.25f;
   // float maxScale = 1.5f;

    public int cloudCount;

    Vector3 temp;


    void Start()
    {

        StartCoroutine(CloudDrop());
    }
    IEnumerator CloudDrop()
    {
      
        while (cloudCount < 150)
        {
            xPos = Random.Range(15, -230);
            yPos = Random.Range(10, 50);
            zPos = Random.Range(-125, -175);
            

            xPos2 = Random.Range(10, -200);
            yPos2 = Random.Range(20, 55);
            zPos2 = Random.Range(-130, -150);

           GameObject cloud_1 = Instantiate(cloud1, new Vector3(xPos, yPos, zPos), Quaternion.identity);
           GameObject cloud_2 = Instantiate(cloud2, new Vector3(xPos2, yPos2, zPos2), Quaternion.identity);

            
            cloud1.transform.localScale = new Vector3 (Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f));
            cloud2.transform.localScale = new Vector3(Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f));

            // transform.localScale *= Random.Range(minScale, maxScale);

            /* temp = transform.localScale;
             temp.x *= Random.Range(1, 5);
             temp.y *= Random.Range(1, 5);
             temp.z *= Random.Range(1, 55);
             transform.localScale = temp;*/

            yield return new WaitForSeconds(0.01f);
            cloudCount += 1;

        }


      
    }

   
    
}

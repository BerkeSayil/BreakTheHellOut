using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    [SerializeField] GameObject pressToCollect;
    [SerializeField] GameObject finishingDoor;

    float collectedItemCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collectible"))
        {
            pressToCollect.SetActive(true);

        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("collectible"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                other.gameObject.SetActive(false);
                pressToCollect.SetActive(false);
                collectedItemCount += 1;
            }


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("collectible"))
        {
            pressToCollect.SetActive(false);
        }
    }

    private void Update()
    {
        if(collectedItemCount >= 25)
        {
            finishingDoor.SetActive(false);
        }
    }


}

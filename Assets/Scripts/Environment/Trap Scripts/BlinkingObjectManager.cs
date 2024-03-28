using SOS.AndrewsAdventure.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingObjectManager : MonoBehaviour
{
    [SerializeField] float activeTime = 1f;
    [SerializeField] float offsetTime = 0f;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= activeTime + offsetTime)
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.activeSelf == true)
                {
                    child.gameObject.SetActive(false);
                }
                else if (child.gameObject.activeSelf == false)
                {
                    child.gameObject.SetActive(true);
                }
            }
            timer = 0f;
            offsetTime = 0f;
        }
    }
}

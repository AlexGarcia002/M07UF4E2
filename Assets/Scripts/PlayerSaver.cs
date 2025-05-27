using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Save(other.transform);
        }
    }

    private void Save(Transform playerTransform)
    {
        PlayerPrefs.SetFloat("playerPosX", playerTransform.position.x);
        PlayerPrefs.SetFloat("playerPosY", playerTransform.position.y);
        PlayerPrefs.SetFloat("playerPosZ", playerTransform.position.z);

        PlayerPrefs.SetFloat("playerRotX", playerTransform.eulerAngles.x);
        PlayerPrefs.SetFloat("playerRotY", playerTransform.eulerAngles.y);
        PlayerPrefs.SetFloat("playerRotZ", playerTransform.eulerAngles.z);

        PlayerPrefs.Save();
    }
}
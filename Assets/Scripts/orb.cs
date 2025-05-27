using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orb : MonoBehaviour, ICollectable
{
    public void OnCollected(){
        GameManager.gameManager.OrbCollected();
        Destroy(gameObject);
    }
}

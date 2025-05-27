using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbAnimation : MonoBehaviour
{
    public float scaleTime = 2f;
    private float scale = 1f;
    public float rotateAmount = 0.6f;
    public float scaleAmount = 0.0006f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScaleObject());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateAmount, 0);
        transform.localScale += new Vector3(1, 1f, 1f) * scale * scaleAmount;
    }
    private IEnumerator ScaleObject(){
        yield return new WaitForSeconds(scaleTime);
        scale = -scale;
        yield return ScaleObject();
    }
}

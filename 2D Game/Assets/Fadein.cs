using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadein : MonoBehaviour
{
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Fade", timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fade(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}

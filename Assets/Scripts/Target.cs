using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void OnMouseDown()
    {
        GameControl.score += 10;
        GameControl.targethit += 1;
        Destroy(gameObject);
    }
}

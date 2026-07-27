using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BLoque : MonoBehaviour
{
    public int resistencia = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (resistencia <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public virtual void RebotarBola() 
    {
    }
}
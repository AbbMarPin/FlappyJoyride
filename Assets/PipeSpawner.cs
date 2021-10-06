using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    private float waitTime = 1.5f;
    private float tempTime;

    void Start()
    {
        tempTime = waitTime - Time.deltaTime;
    }

    void LateUpdate()
    {
        if (GameManager.Instance.GameState())
        {
            tempTime += Time.deltaTime;
            if (tempTime > waitTime)
            {
                // Wait for some time, create an obstacle, then set wait time to 0 and start again
                tempTime = 0;

                if ((int)Random.Range(0, 100) < 50)
                {
                    // normal pipe
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(300f, (int)Random.Range(-110, 110), 0);
                    cube.transform.localScale = new Vector3(25, 25, 25);
                    cube.AddComponent<PipeMove>();
                } else
                {
                    // Red death-pipe
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    var cubeRenderer = cube.GetComponent<Renderer>();
                    cubeRenderer.material.SetColor("_Color", Color.red);
                    cube.transform.position = new Vector3(300f, (int)Random.Range(-110, 110), 0);
                    cube.transform.localScale = new Vector3(25, 25, 25);
                    cube.AddComponent<PipeMoveKiller>();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.transform.parent != null)
        {
            Destroy(col.gameObject.transform.parent.gameObject);
        }
        else
        {
            Destroy(col.gameObject);
        }
    }

}

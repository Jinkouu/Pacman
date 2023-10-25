using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bonus;
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private Tweener tweener;

    float left;
    float right;
    float up;
    float down;

    void Start()
    {
        left = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane)).x;
        right = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane)).x;
        up = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane)).y;
        down = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane)).y;

        try
        {
            //tweener = GetComponent<Tweener>();
            StartCoroutine(loopSpawn());
        }
        catch{ }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator loopSpawn()
    {
        while (true)
        {
            StartCoroutine(spawnCherry());
            yield return new WaitForSeconds(10f);
        }
    }

    IEnumerator spawnCherry()
    {
        Vector3 spawnPos = new Vector3 (left, up, 0f);
        Vector3 endPos = new Vector3 (right, down, 0f);


        GameObject cherry = Instantiate(bonus, spawnPos, Quaternion.identity);
        cherry.transform.SetParent(transform);


        tweener.AddTween(cherry.transform, spawnPos, endPos, 10f);
        

        yield return new WaitForSeconds(10f);
        
        if (cherry.gameObject != null)
        {
            Destroy(cherry.gameObject);
        }
    }
}

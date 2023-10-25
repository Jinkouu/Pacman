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
        left = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane)).x - 1;
        right = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane)).x + 1;
        up = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane)).y + 1;
        down = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane)).y - 1;

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
            yield return new WaitForSeconds(3f);
        }
    }

    IEnumerator spawnCherry()
    {
        Vector3 spawnP = new Vector3 (left, up, 0f);
        Vector3 endP = new Vector3 (right, down, 0f);

        Vector3 spawnPos = Vector3.zero;

        int randomSpawn = Random.Range(0, 4);  // Determines where to spawn

        switch (randomSpawn)
        {
            case 0:  // Top of the screen
                spawnPos = new Vector3(Random.Range(left, right), up, 0f);
                break;
            case 1:  // Right of the screen
                spawnPos = new Vector3(right, Random.Range(up, down), 0f);
                break;
            case 2:  // Bottom of the screen
                spawnPos = new Vector3(Random.Range(left, right), down, 0f);
                break;
            case 3:  // Left of the screen
                spawnPos = new Vector3(left, Random.Range(up, down), 0f);
                break;
        }

        Vector3 endPos = getEndPos(spawnPos);


        GameObject cherry = Instantiate(bonus, spawnPos, Quaternion.identity);
        cherry.transform.SetParent(transform);

        tweener.AddTween(cherry.transform, spawnPos, endPos, 10f);
        

        yield return new WaitForSeconds(10f);
        
        if (cherry.gameObject != null)
        {
            Destroy(cherry.gameObject);
        }
    }

    private Vector3 getEndPos(Vector3 spawnPos)
    {
        float cameraCentreX = camera.transform.position.x;
        float cameraCentreY = camera.transform.position.y;

        Vector3 endPos = Vector3.zero;
        float distanceX = Vector2.Distance(new Vector2 (spawnPos.x, spawnPos.y), new Vector2(cameraCentreX, spawnPos.y));
        float distanceY = Vector2.Distance(new Vector2(spawnPos.x, spawnPos.y), new Vector2(spawnPos.x, cameraCentreY));

        float endX = 0;
        float endY = 0;

        if(spawnPos.x < cameraCentreX)
        {
            endX = cameraCentreX + distanceX;
        }
        else if(spawnPos.x > cameraCentreX)
        {
            endX = cameraCentreX - distanceX;
        }

        if(spawnPos.y < cameraCentreY)
        {
            endY = cameraCentreY + distanceY;
        }
        else if(spawnPos.y > cameraCentreY)
        {
            endY = cameraCentreY - distanceY;
        }

        endPos = new Vector3(endX, endY, 0f);
        return endPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bonus;
    [SerializeField]
    public Camera mainCamera;
    [SerializeField]
    private Tweener tweener;

    float left;
    float right;
    float up;
    float down;

    void Start()
    {
        left = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane)).x - 1;
        right = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane)).x + 1;
        up = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane)).y + 1;
        down = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane)).y - 1;

        StartCoroutine(loopSpawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator loopSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            StartCoroutine(spawnCherry());
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
        tweener.AddTween(cherry.transform, spawnPos, endPos, 10f);
        

        yield return new WaitForSeconds(10f);
        
        if (cherry.gameObject != null)
        {
            Destroy(cherry.gameObject);
        }
    }

    private Vector3 getEndPos(Vector3 spawnPos)
    {
        float mainCameraCentreX = mainCamera.transform.position.x;
        float mainCameraCentreY = mainCamera.transform.position.y;

        Vector3 endPos = Vector3.zero;
        float distanceX = Vector2.Distance(new Vector2 (spawnPos.x, spawnPos.y), new Vector2(mainCameraCentreX, spawnPos.y));
        float distanceY = Vector2.Distance(new Vector2(spawnPos.x, spawnPos.y), new Vector2(spawnPos.x, mainCameraCentreY));

        float endX = 0;
        float endY = 0;

        if(spawnPos.x < mainCameraCentreX)
        {
            endX = mainCameraCentreX + distanceX;
        }
        else if(spawnPos.x > mainCameraCentreX)
        {
            endX = mainCameraCentreX - distanceX;
        }

        if(spawnPos.y < mainCameraCentreY)
        {
            endY = mainCameraCentreY + distanceY;
        }
        else if(spawnPos.y > mainCameraCentreY)
        {
            endY = mainCameraCentreY - distanceY;
        }

        endPos = new Vector3(endX, endY, 0f);
        return endPos;
    }
}

using UnityEngine;

public class WrapAround : MonoBehaviour
{
    float minX = -10.0f;
    float maxX = 10.0f;
    float minY = -6.0f;
    float maxY = 6.0f;
    void Start()
    {
        
    }

    void Update()
    {
        //Horizontal check.
        if(transform.position.x < minX)
        {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > maxX)
        {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }

        //Vertical check.
        if (transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        }
        else if (transform.position.y > maxY)
        {
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        }
    }

    public void SetSceneDimensions(float minx, float maxx, float miny, float maxy)
    {
        minX = minx;
        maxX = maxx;
        minY = miny;
        maxY = maxy;
    }
}

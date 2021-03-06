using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeScript : MonoBehaviour
{
    public GameObject BladeTrailPrefab;
    public float minCuttingVelocity= .001f;
    GameObject currentBladeTrail;
    bool isCutting = false;
    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;
    Vector2 previousPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }
        if (isCutting)
        {
            UpdateCut();
        }
    }
    void UpdateCut()
    {   
        Vector2 newPosition= cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;
        float velocity = (newPosition - previousPosition).magnitude*Time.deltaTime;
        if (velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }
        previousPosition = newPosition;
        
    }
    void StartCutting()
    {
        isCutting = true;
      currentBladeTrail=Instantiate(BladeTrailPrefab,transform);
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = false;
    }
    void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
        circleCollider.enabled = false;
    }
}

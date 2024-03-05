using UnityEngine;

public class Line : MonoBehaviour
{
    LineRenderer lineRenderer;
    private Bird bird;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
   
    void Update()
    {
        if (bird == null)
        {
            bird = FindObjectOfType<Bird>();
            if (bird != null)
            {
                lineRenderer.SetPosition(0, bird.transform.position);
            }
        }

        if (bird == null || bird.IsDragging == false)
        {
            lineRenderer.enabled = false;
            return;
        }

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(1, bird.transform.position);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoIA : MovimentoInimigo
{
   /* public enum CheckType
    {
        TenPerSecond, TwPerSecond, AllTime
    };
    public CheckType checkType = CheckType.AllTime;
    [Range(1, 50)]
    public float visionDistance = 5;
    //
    [Header("RayCast")]
    public string obstaclesTag = "Obstacles";
    [Range(2, 360)]
    public float extraRay = 20;
    [Range(5, 360)]
    public float visionAngle = 120;
    [Range(1, 10)]
    public int layerNumber = 3;
    [Range(0.02f, 0.15f)]
    public float layerDistance = 0.1f;
    //
    [Space(10)]
    public List<Transform> visibleObstacle = new List<Transform>();
    public List<Transform> temporaryCollision = new List<Transform>();
    LayerMask obstaclesLayer;
    [HideInInspector] public float checkTime = 0;
    [HideInInspector] public bool visto;
    void Start()
    {
        checkTime = 0;
        if (!rayFont)
            rayFont = transform;
        //

    }
    public void InimigoIAa()
    {
        if (checkType == CheckType.TenPerSecond)
        {
            checkTime += Time.deltaTime;
            if (checkTime >= 0.1f)
            {
                checkTime = 0;
                CheckObstacles();
            }
        }
        if (checkType == CheckType.TwPerSecond)
        {
            checkTime += Time.deltaTime;
            if (checkTime >= 0.05f)
            {
                checkTime = 0;
                CheckObstacles();
            }
        }
        if (checkType == CheckType.AllTime)
        {
            CheckObstacles();
        }
    }
    private void CheckObstacles()
    {
        float layerLimit = layerNumber * 0.5f;
        for (int x = 0; x <= extraRay; x++)
        {
            for (float y = -layerLimit + 0.5f; y <= layerLimit; y++)
            {
                float angleRay = x * (visionAngle / layerNumber) + ((180f - visionAngle) * 0.5f);
                Vector3 multipleDirection = (rayVector) + (rayFont.up * y * layerDistance);
                Vector3 rayDirection = rayFont.rotation*Quaternion.AngleAxis(angleRay, rayFont.right) * multipleDirection;
                RaycastHit hit;
                if (Physics.Raycast(rayFont.position, rayDirection, out hit, visionDistance))
                {
                    if (!hit.transform.IsChildOf(transform.root) && !hit.collider.isTrigger)
                    {
                        if (hit.collider.gameObject.CompareTag(obstaclesTag))
                        {
                            visto = true;
                            if (!temporaryCollision.Contains(hit.transform))
                            {
                                
                                temporaryCollision.Add(hit.transform);
                            }

                        }
                        else
                        {
                            visto = false;
                        }
                    }
                    else
                    {
                        visto = false;
                    }
                }
                else
                {
                    visto = false;
                    Debug.DrawRay(rayFont.position, rayDirection * visionDistance, Color.green);
                }
            }
        }
    }*/
}
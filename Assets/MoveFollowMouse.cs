using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFollowMouse : MonoBehaviour
{
    public List<Vector3> Point = new List<Vector3>();
    public Vector3 PosInit;
    public Vector3 DirectMove;
    public float cachedReal=0.1f;
    private void Awake()
    {
        cachedReal = 0.5f;
    }
    public Vector3 Process_Point(Vector3 point)
    {
        Point.Add(point);
        int length = Point.Count;
        if (length > 1)
        {
            if (Point[length - 1] != Point[length - 2])
            {
                Vector3 direct = Point[length - 1] - PosInit;

                Debug.Log("TOWARD_MOUSE");

                if (Vector3.Angle(direct.normalized, DirectMove.normalized) > 4)
                {
                    PosInit = Point[length - 1];
                    Point.RemoveRange(0, length - 1);
                    direct = Vector3.zero;
                    return Vector3.zero;

                }
                return direct.normalized * cachedReal;

            }
            else
            {
                Debug.Log("INIT_2");
                PosInit = Point[length - 1];
                Point.RemoveRange(0, length - 1);
                return Vector3.zero;
            }
        }
        else
        {
            Debug.Log("INIT");
            PosInit = Point[length - 1];
            return Vector3.zero;
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strategy {

	public Strategy()
    {

    }
    public List<Vector3> Defend(Vector3 point)
    {
        Vector3 center = point;
        center.z -= 2;
        List<Vector3> alignment = new List<Vector3>();
        alignment.Add(point);
        for (int i = 1; i < 5; i++)
        {
            if (IsOdd(i))
            {
                alignment.Add(new Vector3(point.x + 2 * i, point.y, point.z));
            }
            else
            {
                alignment.Add(new Vector3(point.x - 2 * i, point.y, point.z));
            }
        }
        return alignment;
    }

    public List<Vector3> Attack(Vector3 point)
    {
        Vector3 center = point;
        center.z -= 2;
        List<Vector3> alignment = new List<Vector3>();
        alignment.Add(point);
        for (int i = 1; i < 5; i++)
        {
            if (IsOdd(i))
            {
                alignment.Add(new Vector3(point.x, point.y, point.z + 4 * i));
            }
            else
            {
                alignment.Add(new Vector3(point.x, point.y, point.z - 4 * i));
            }
        }
        return alignment;
    }

    private static bool IsOdd(int value)
    {
        return value % 2 != 0;
    }
}

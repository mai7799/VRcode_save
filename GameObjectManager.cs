using UnityEngine;

public static class GameObjectManager
{
    private static GameObject createdObject;
    private static string lastObjectName = "No object created yet";

    public static void SetCreatedObject(GameObject obj)
    {
        createdObject = obj;
        if (obj != null)
        {
            lastObjectName = obj.name;
        }
    }

    public static string GetCreatedObjectName()
    {
        if (createdObject != null)
        {
            return createdObject.name;
        }
        else
        {
            return lastObjectName;
        }
    }
}

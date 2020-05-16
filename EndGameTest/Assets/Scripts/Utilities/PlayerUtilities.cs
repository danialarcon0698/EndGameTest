using UnityEngine;

public static class PlayerUtilities
{
    public static int PlayerLayer
    {
        get
        {
            return LayerMask.GetMask("Player");
        }
    }
}

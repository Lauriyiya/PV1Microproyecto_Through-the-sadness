using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    public string oneWayPlatformLayerName = "OneWayPlatform";
    public string playerLayerName = "Player";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") < 0)
            Physics2D.IgnoreLayerCollision(
                LayerMask.NameToLayer(playerLayerName),
                LayerMask.NameToLayer(oneWayPlatformLayerName),
                true);
        else
            Physics2D.IgnoreLayerCollision(
                LayerMask.NameToLayer(playerLayerName),
                LayerMask.NameToLayer(oneWayPlatformLayerName),
                false);
    }
}

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class ParallaxLayer : MonoBehaviour
{
    public float parallaxFactor;
    private float starPos, length;
    [SerializeField] private SpriteRenderer background;

    private void Start()
    {
        starPos = transform.localPosition.x;
        
        if (background != null )
            length = background.bounds.size.x;
    }

    public void Move(float delta)
    {
        Vector3 newPos = transform.localPosition;
        newPos.x -= delta * parallaxFactor;

        transform.localPosition = newPos;

        float movement = delta * (1 - parallaxFactor);

        if (background != null)
        {
            if (movement > starPos + length)
            {
                starPos += length;
                transform.localPosition = new Vector3(transform.localPosition.x + length, transform.localPosition.y, transform.localPosition.z);
            }
            else if (movement < starPos - length)
            {
                starPos -= length;
                transform.localPosition = new Vector3(transform.localPosition.x - length, transform.localPosition.y, transform.localPosition.z);
            }
        }
            
    }

}   
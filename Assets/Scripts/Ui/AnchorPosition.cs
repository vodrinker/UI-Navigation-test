using UnityEngine;

[System.Serializable]
public class AnchorPosition
{
    public RectTransform Anchor;
    public GameObject AnchoredObject;
    public bool IsActiveAtStart = false;

    public void SetObjectPosition()
    {
        AnchoredObject.SetActive(IsActiveAtStart);

        AnchoredObject.transform.position = Anchor.position;
    }
}
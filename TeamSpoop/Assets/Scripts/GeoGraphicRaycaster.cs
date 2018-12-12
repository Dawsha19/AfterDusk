using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GeoGraphicRaycaster : GraphicRaycaster {

    public Transform NonRectTransform;
    public float DesiredCameraDepth;

    protected override void Start()
    {
        eventCamera.depth = DesiredCameraDepth;
        base.Start();
    }

    public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
    {
        Vector2 uvPos = Vector2.zero;
        if (UVHit(ref uvPos)) {
            eventCamera.depth = DesiredCameraDepth + 1f;
            eventData.position = new Vector2(uvPos.x *
                eventCamera.pixelWidth, uvPos.y * eventCamera.pixelHeight);
            base.Raycast(eventData, resultAppendList);
            return;
        }

        eventCamera.depth = DesiredCameraDepth;
    }

    private bool UVHit(ref Vector2 uvPos)
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit) && hit.transform == NonRectTransform) {
            uvPos = hit.textureCoord;
            return true;
        }

        return false;
    }
}

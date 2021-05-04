using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDrag : MonoBehaviour
{
    Camera myCam;

    [SerializeField]
    RectTransform boxVisual;

    Rect SelectBox;

    Vector2 startPos;
    Vector2 endPos;


    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
        startPos = Vector2.zero;
        endPos = Vector2.zero;
        DrawVisual();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            SelectBox = new Rect();
        }

        if (Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;
            DrawVisual();
            DrawSelection();
        }

        if (Input.GetMouseButtonUp(0))
        {
            SelectUnits();
            startPos = Vector2.zero;
            endPos = Vector2.zero;
            DrawVisual();
        }
    }

    void DrawVisual()
    {
        Vector2 boxStart = startPos;
        Vector2 boxEnd = endPos;

        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        boxVisual.position = boxCenter;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));

        boxVisual.sizeDelta = boxSize;
    }

    void DrawSelection()
    {
        if(Input.mousePosition.x < startPos.x)
        {
            //draging mouse left
            SelectBox.xMin = Input.mousePosition.x;
            SelectBox.xMax = startPos.x;

        }
        else
        {
            SelectBox.xMin = startPos.x;
            SelectBox.xMax = Input.mousePosition.x;
        }

        if(Input.mousePosition.y < startPos.y)
        {
            SelectBox.yMin = Input.mousePosition.y;
            SelectBox.yMax = startPos.y;
        }
        else
        {
            SelectBox.yMin = startPos.y;
            SelectBox.yMax = Input.mousePosition.y;
        }
    }

    void SelectUnits()
    {
        foreach(var unit in UnitController.Instance.unitList)
        {
            if (SelectBox.Contains(myCam.WorldToScreenPoint(unit.transform.position))){

                UnitController.Instance.DragSelect(unit);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> SelectedList = new List<GameObject>();

    private static UnitController _instance;

    public static UnitController Instance { get { return _instance; } }


    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();
        SelectedList.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        unitToAdd.GetComponent<UnitMovement>().enabled = true;
    }
    
    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if (!SelectedList.Contains(unitToAdd))
        {
            SelectedList.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }
        else
        {
            unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
            unitToAdd.GetComponent<UnitMovement>().enabled = false;
            SelectedList.Remove(unitToAdd);
        }
    }
    
    public void DragSelect(GameObject unitToAdd)
    {
        if (!SelectedList.Contains(unitToAdd))
        {
            SelectedList.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }

    }

    public void DeselectAll()
    {
        
        foreach (var unit in SelectedList)
        {
            unit.transform.GetChild(0).gameObject.SetActive(false);
            unit.GetComponent<UnitMovement>().enabled = false;
        }
        SelectedList.Clear();
    }

    public void Deselect(GameObject unitToUnselect)
    {

        unitToUnselect = null;


    }



    // Update is called once per frame
    void Update()
    {
        
    }
}

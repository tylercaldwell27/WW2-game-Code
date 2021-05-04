using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnitController.Instance.unitList.Add(this.gameObject);
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        UnitController.Instance.unitList.Remove(this.gameObject);
        UnitController.Instance.SelectedList.Remove(this.gameObject);
    }
}

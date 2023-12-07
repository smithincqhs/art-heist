using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemID : MonoBehaviour
{
    public GameObject P1,P2,P3,P4,P5,P6,P7,P8,P9,P10,P11,P12,P13,P14,P15,P16,P17,P18,P19,P20,P21,P22,P23,P24,P25,P26,P27,P28,P29,P30,P31,P32,P33,P34,P35,P36,P37,P38,P39,P40,P41,P42,P43,P44,P45,P46,P47,P48,P49,P50,P51,P52,P53; // Paintings

    public List<GameObject> paintings;
    private void Start()
    {
        paintings = new List<GameObject>() { P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53 };
    }

    public GameObject PrefabFromID(int prefabID)
    {
        return paintings[prefabID];
    }

    public int IDFromPrefab(GameObject inputPrefab)
    {
        if (paintings.Contains(inputPrefab))
            return paintings.IndexOf(inputPrefab);
        return -1;
    }
}

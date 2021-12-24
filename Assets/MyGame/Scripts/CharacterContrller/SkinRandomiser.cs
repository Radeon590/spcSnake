using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinRandomiser : MonoBehaviour
{
    [SerializeField] private List<Sprite> plauerSpritesList;

    public void SetRandomSkin()
    {
        GetComponent<SpriteRenderer>().sprite = plauerSpritesList[Random.Range(0, plauerSpritesList.Count)];
    }
}

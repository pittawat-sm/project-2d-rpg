using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Backpack", menuName = "Items/Backpack", order = 2)]
public class Backpack : Item
{
    [Header("Backpack Properties")]
    public string UIResourcePath;
    public AudioClip openSound;
    public AudioClip closeSound;
}

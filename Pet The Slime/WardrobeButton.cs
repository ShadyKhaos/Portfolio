using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Wardrobe", menuName = "Create New Wardrobe")]
public class WardrobeButton : BaseScriptable
{
    [SerializeField] Sprite[] sprite;
    [SerializeField] int spriteType;

    public Sprite[] GetSprite()
    {
        return sprite;
    }
    public int GetSpriteType()
    {
        return spriteType;
    }

    public void Override(WardrobeButton button)
    {
        this.Reset();
        this.SetCost(button.GetCost());
        sprite = button.GetSprite();
        spriteType = button.GetSpriteType();
    }
}

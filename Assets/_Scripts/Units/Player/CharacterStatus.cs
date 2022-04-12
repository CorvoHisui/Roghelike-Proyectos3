using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[CreateAssetMenu(fileName = "HealthStatusData", menuName = "StatusObjects/Health", order = 1)]
public class CharacterStatus : ScriptableObject
{
    public string charName = "name";
    public int level      = 1;
    public int baseMaxHp  = 0;
    public int baseMaxMp  = 0;
    public int baseHp     = 0;
    public int baseMp     = 0;
    public int baseStr    = 0;
    public int baseDef    = 0;
    public int baseMgc    = 0;
    public int baseMgcDef = 0;
    public int maxHp      = 0;
    public int maxMp      = 0;
    public int hp         = 0;
    public int mp         = 0;
    public int str        = 0;
    public int def        = 0;
    public int mgc        = 0;
    public int mgcDef     = 0;
}
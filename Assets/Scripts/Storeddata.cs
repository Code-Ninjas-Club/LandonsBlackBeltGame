using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Storeddata
{
    public static void levelthing(string Name)
    {
        Levelthing = Name;
    }
    public static string character ;
    public static string Levelthing;
     static int level=1;
     static float xp=0;
     static int gold=0;
   public static void Character(string Name)
    {
        character = Name;
    }
   public static int getgold()
    {
        return gold;
    }
    public static void setgold(int amount)
    {
        gold = amount;
    }
    public static float getxp()
    {
        return xp;
    }
    public static void gainxp(float amount)
    {
        float xpToNextLevel = 50 + 10 * level;
        xp += amount;
        if(xp >= xpToNextLevel)
        {
            xp -= xpToNextLevel;
            level += 1;
        }
    }
public static int getlevel()
    {
        return level;
    }
}

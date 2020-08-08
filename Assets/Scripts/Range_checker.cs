using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Range_checker  {
    public static bool IsWithin(this float value, int minimum, int maximum)
        {
            return value >= minimum && value <= maximum;
        }
}
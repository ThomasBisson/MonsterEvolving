using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceHelper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public static int STARTING_EXP_CHARACTER = 200;
    public static float FACTOR_EXP_CHARACTER = 2.8f;
	

	public static int GiveMeTheNextExperienceNeededToReachTheNextLevel(int nextLevel)
    {
        int res = STARTING_EXP_CHARACTER + (int) System.Math.Pow(nextLevel, FACTOR_EXP_CHARACTER);
        print("[" + nextLevel + "] " + res);
        bool dontStop = true;
        int var = 10;
        double tempRes = 0;
        while (dontStop)
        {
            if(res / var < 1)
            {
                var /= 10;
                tempRes = (double)res / (double)var;
                System.Math.Floor(tempRes);
                res *= var;
                dontStop = false;
            }
            var *= 10;
        }
        return res;
    }
}

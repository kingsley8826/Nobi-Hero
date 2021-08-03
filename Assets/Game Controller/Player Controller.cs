using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public static float maxBlood = 10;
    public static int money = 0;
    public static int star_lv1 = 0;
    public static int star_lv2 = 0;
    public static int star_lv3 = 0;
	public static bool openDoor2 = false;
	public static bool openDoor3 = false;
    public static int currentStar = 0;
	public static void setOpenDoor2(){
		if (openDoor2 == false) {
			openDoor2 = true;
		}
	}
	public static void setOpenDoor3(){
		if (openDoor3 == false) {
			openDoor3 = true;
		}
	}

	public static void setStar_lv1(int star){
		if(star > star_lv1)
			star_lv1 = star;
	}
	public static void setStar_lv2(int star){
		if(star > star_lv2)
				star_lv2 = star;
	}
	public static void setStar_lv3(int star){
		if(star > star_lv1)
			star_lv3 = star;
	}

    public static void setCurrentStar(int star)
    {
        currentStar = star;
    }
}

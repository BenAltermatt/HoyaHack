using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour
{
    public int killCount;
    public Time timeStarted;

    public class Pistol {
        public string name = "Pistol";
        public int damage = 5;
        public bool longRange = true;
        public float useSpeed = 3;
        public float useCoolDown = 3;
    }

    public class MachineGun {
        public string name = "Machine Gun";
        public int damage = 5;
        public bool longRange = true;
        public float useSpeed = 3;
        public float useCoolDown = 3;
    }

    public class HeavyMachineGun {
        public string name = "Heavy Machine Gun";
        public int damage = 5;
        public bool longRange = true;
        public float useSpeed = 3;
        public float useCoolDown = 3;
    }

    public class Katana {
        public string name = "Katana";
        public int damage = 5;
        public bool longRange = false;
        public float useSpeed = 3;
        public float useCoolDown = 3;
    }
} 
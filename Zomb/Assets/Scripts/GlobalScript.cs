using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : ScriptableObject
{
    public int killCount;
    public Time timeStarted;

    public struct Pistol () {
        public String name = "Pistol";
        public int damage = 5;
        public boolean longRange = true;
        public float useSpeed = 3;
        public float useCoolDown = 3;
    }

    public struct MachineGun() {
        public String name = "Machine Gun";
        public int damage = 5;
        public boolean longRange = true;
        public float useSpeed = 3;
        public float useCoolDown = 3;
    }

    public struct HeavyMachineGun() {
        public String name = "Heavy Machine Gun";
        public int damage = 5;
        public boolean longRange = true;
        public float useSpeed = 3;
        public float useCoolDown = 3;
    }

    public struct Katana() {
        public String name = "Katana";
        public int damage = 5;
        public boolean longRange = false;
        public float useSpeed = 3;
        public float useCoolDown = 3;
    }
} 
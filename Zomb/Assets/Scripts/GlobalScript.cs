using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour
{

    void Update() 
    {

    }

    void Start() 
    {

    }

    public int killCount;
    public float timeStarted;

    public class Weapon {
        public string name;
        public int damage;
        public bool longRange;
        public float useSpeed;
        public float useCoolDown;
        public int id;

        public Weapon(string n, int d, bool l, float s, float c, int i) {
            name = n;
            damage = d;
            longRange = l;
            useSpeed = s;
            useCoolDown = c;
            id = i;
        }
    }

    public class Pistol : Weapon {
        public Pistol() : base("Pistol", 5, true, .05f, .1f, 1){}

    }

    public class MachineGun : Weapon {
        public MachineGun() : base("Machine Gun", 5, true, .05f, .05f, 2) {}
    }

    public class HeavyMachineGun : Weapon {
        public HeavyMachineGun() : base("Heavy Machine Gun", 5, true, .05f, .025f, 2) {}
    }

    public class Bat : Weapon {
        public Bat() : base("Bat", 20, false, 5f, 4f, 1) {}
    }

    public class  Crowbar : Weapon {
        public Crowbar() : base("Crowbar", 25, false, 5f, 3f, 2) {}
    }

    public class Katana : Weapon {
        public Katana() : base("Katana", 20, false, 3f, 3f, 3) {}
    }
} 
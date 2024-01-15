using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public abstract class TrapMode
{
    protected Trap owner;
    public TrapMode(Trap trap)
    {
        owner = trap;
    }
    public abstract void Function();
}

public class UpTrap : TrapMode
{
    int Power;
    int UpPower = UnityEngine.Random.Range(15, 20);

    bool isUpTypeCheck(Up_Trap_Type Uptype)
    {
        return (Uptype & owner.up_type) != 0;
    }
    public UpTrap(Trap trap) : base(trap)
    {
        List<int> exclusionList = new List<int>();
        for (int i = -10; i < 10; i++)
        {
            exclusionList.Add(i);
        }
        int RandomNumber(int min, int max)
        {
            int randomValue = UnityEngine.Random.Range(min, max);
            while (exclusionList.Contains(randomValue))
            {
                randomValue = UnityEngine.Random.Range(min, max);
            }
            return randomValue;
        }
        if (isUpTypeCheck(Up_Trap_Type.Left))
            Power = UnityEngine.Random.Range(-15, -20);
        if (isUpTypeCheck(Up_Trap_Type.Right))
            Power = UnityEngine.Random.Range(15, 20);
        if (isUpTypeCheck(Up_Trap_Type.Random))
            Power = RandomNumber(-20, 20);
    }

    public override void Function()
    {
        if (owner.target != null)
        {
            owner.target.GetComponent<PlayerMove>().TriggerMove();
            Rigidbody rb = owner.target.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(Power, UpPower, 0, ForceMode.Impulse);
        }
        if (owner.Ctarget != null)
        {
            owner.Ctarget.GetComponent<CreatePlayerMove>().TriggerMove();
            Rigidbody rb = owner.Ctarget.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(Power, UpPower, 0, ForceMode.Impulse);
        }
    }
}

public class IllusionTrap : TrapMode
{
    public IllusionTrap(Trap trap) : base(trap)
    { }
    public override void Function()
    {
        if (owner.target != null)
        {
            Rigidbody rb = owner.target.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}

public class MakingTrap : TrapMode
{
    public MakingTrap(Trap trap) : base(trap)
    { }
    public override void Function()
    {
        Shoot shoot = owner.GetComponent<Shoot>();
        if (owner.target != null)
        {
            shoot.MakingTime -= 0.1f;
            shoot.ShootBluuet();
        }
        if(owner.Ctarget!=null)
        {
            shoot.MakingTime -= 0.1f;
            shoot.ShootBluuet();
        }
    }
}

public class ExitTrap : TrapMode
{

    public ExitTrap(Trap trap) : base(trap) { }

    public override void Function()
    {
        CoolTime cool = owner.GetComponent<CoolTime>();
        cool.CoolStop();
        cool.CoolStart();
    }
}

public class TelePortTrap : TrapMode
{
    public TelePortTrap(Trap trap) : base(trap) { }
    public override void Function()
    {
        TelePortPlace Tplace = owner.GetComponent<TelePortPlace>();
        if (owner.target != null)
            Tplace.TargetMove(owner.target);
        else if (owner.Ctarget != null)
            Tplace.TargetMove(owner.Ctarget);
    }
}

public class ReduceTrap : TrapMode
{
    public ReduceTrap(Trap trap) : base(trap) { }
    public override void Function()
    {
        CoolTime cool = owner.GetComponent<CoolTime>();
        cool.CoolStop();
        cool.CoolStart();
    }
}
public class MineTrap : TrapMode
{
    public MineTrap(Trap trap) : base(trap) { }
    public override void Function()
    {
        CoolTime cool = owner.GetComponent<CoolTime>();
        cool.CoolStop();
        cool.CoolStart();
        if (owner.target != null)
            owner.target.state = playerState.stay;
        else if (owner.Ctarget != null)
            owner.Ctarget.state = CreaeteplayerState.stay;
    }
}

[Flags]
public enum Trap_Type
{
    Up = 1 << 0,
    Illusion = 1 << 1,
    Making = 1 << 2,
    Exit = 1 << 3,
    TelePort = 1 << 4,
    Reduce = 1 << 5,
    Mine = 1 << 6
}

public enum Up_Trap_Type
{
    Left = 1 << 0,
    Right = 1 << 1,
    Random = 1 << 2
}

public class Trap : MonoBehaviour
{
    public Player target;
    public CreatePlayer Ctarget;
    public Trap_Type type;
    public Up_Trap_Type up_type;
    public List<TrapMode> ModeList = null;
    public AudioClip sound;

    bool IsCheckType(Trap_Type targetType)
    {
        return (type & targetType) != 0;
    }

    void Start()
    {

        ModeList = new List<TrapMode>();
        if (IsCheckType(Trap_Type.Up))
            ModeList.Add(new UpTrap(this));
        if (IsCheckType(Trap_Type.Illusion))
            ModeList.Add(new IllusionTrap(this));
        if (IsCheckType(Trap_Type.Making))
            ModeList.Add(new MakingTrap(this));
        if (IsCheckType(Trap_Type.Exit))
            ModeList.Add(new ExitTrap(this));
        if (IsCheckType(Trap_Type.TelePort))
            ModeList.Add(new TelePortTrap(this));
        if (IsCheckType(Trap_Type.Reduce))
            ModeList.Add(new ReduceTrap(this));
        if (IsCheckType(Trap_Type.Mine))
            ModeList.Add(new MineTrap(this));
    }

    public void Active()
    {
        if (Ctarget != null)
            Ctarget.state = CreaeteplayerState.trap;
        if (target != null)
            target.state = playerState.trap;
        foreach (TrapMode mode in ModeList)
        {
            mode.Function();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CreatePlayer>() != null)
        {
            Ctarget = other.GetComponent<CreatePlayer>();
            Active();
        }

        if (other.GetComponent<Player>() != null)
        {
            if (sound != null)
            {
                other.GetComponent<Player>().InputSound(sound);
            }
            target = other.GetComponent<Player>();
            Active();
        }
    }
}

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Settings")]
    public int startingAmmo = 10;

    private int ammo;
    private int killCount;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ammo = startingAmmo;
        killCount = 0;

        GameEvents.OnAmmoChanged?.Invoke(ammo);
        GameEvents.OnKillCountChanged?.Invoke(killCount);
    }

    public bool HasAmmo()
    {
        return ammo > 0;
    }

    public void UseAmmo()
    {
        ammo--;
        GameEvents.OnAmmoChanged?.Invoke(ammo);
    }

    public void AddKill()
    {
        killCount++;
        GameEvents.OnKillCountChanged?.Invoke(killCount);
    }
}

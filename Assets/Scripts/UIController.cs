using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI killText;

    void OnEnable()
    {
        GameEvents.OnAmmoChanged += UpdateAmmo;
        GameEvents.OnKillCountChanged += UpdateKill;
    }

    void OnDisable()
    {
        GameEvents.OnAmmoChanged -= UpdateAmmo;
        GameEvents.OnKillCountChanged -= UpdateKill;
    }

    void UpdateAmmo(int ammo)
    {
        if (ammoText != null)
            ammoText.text = ammo.ToString();
    }

    void UpdateKill(int kills)
    {
        if (killText != null)
            killText.text = kills.ToString();
    }
}

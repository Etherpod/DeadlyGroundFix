using HarmonyLib;
using modweaver.core;

namespace DeadlyGroundFix;

[ModMainClass]
public class ModMain : Mod
{
    public override void Init()
    {
        Harmony harmony = new Harmony(Metadata.id);
        harmony.PatchAll();
    }

    public override void Ready() { }

    public override void OnGUI(ModsMenuPopup ui) { }
}

[HarmonyPatch]
public class PatchClass
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(DeathZone), nameof(DeathZone.Start))]
    public static void DeadlyGroundFix(DeathZone __instance)
    {
        if (!__instance._collider2D.isTrigger)
        {
            __instance.gameObject.AddComponent<DeadlyGroundCollision>();
        }
    }
}
using MelonLoader;
using UnityEngine;
using HarmonyLib;
using Il2CppScheduleOne.Trash;
using Il2CppScheduleOne.ObjectScripts;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppScheduleOne.Interaction;


public class RecyclerGoBrrrr : MelonMod {

    [HarmonyPatch(typeof(Recycler), nameof(Recycler.GetTrash))]
    static class RecyclerGetTrashPatch {
        static bool Prefix(ref Il2CppReferenceArray<TrashItem> __result) {
            TrashItem[] trashList = GameObject.FindObjectsOfType<TrashItem>();
            __result = new Il2CppReferenceArray<TrashItem>(trashList.Length);
            for (int i = 0; i < trashList.Length; i++) {
                __result[i] = trashList[i];
            }

            return false;
        }
    }

    public override void OnInitializeMelon() {
        MelonLogger.Msg("Converting Recycler to Money Printer");
    }
}

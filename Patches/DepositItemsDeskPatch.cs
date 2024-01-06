using HarmonyLib;
using System;
using System.Collections.Generic;

namespace LCObligedCompany.Patches {
    [HarmonyPatch(typeof(DepositItemsDesk))]
    internal class DepositItemsDeskPatch {

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void BeNiceBeQuick(DepositItemsDesk __instance, ref List<GrabbableObject> ___itemsOnCounter, ref float ___grabObjectsTimer) {
            if (__instance.IsHost) {
                __instance.currentMood.desiresSilence = false;
                __instance.currentMood.judgementSpeed = 0f;
                __instance.currentMood.timeToWaitBeforeGrabbingItem = 0f;
                __instance.currentMood.maxPlayersToKillBeforeSatisfied = 0;
                __instance.currentMood.mustBeWokenUp = false;

                ___grabObjectsTimer = Math.Min(3f, ___grabObjectsTimer);

                __instance.patienceLevel = float.MaxValue;

                if (___itemsOnCounter.Count > 0 && !__instance.doorOpen) { 
                    __instance.OpenShutDoor(true);
                }
            }
        }

    }
}

using UnityEngine;
using shovelFix;
using MonoMod.Cil;
using GameNetcodeStuff;


namespace ShovelFixPatch {
    internal class ShovelFix {
        

        public static void Init() {
            IL.Shovel.HitShovel += HitShovel;
        }

        private static void HitShovel(ILContext il) {
            ILCursor c = new ILCursor(il);

            //objectsHitByShovel = Physics.SphereCastAll(previousPlayerHeldBy.gameplayCamera.transform.position + previousPlayerHeldBy.gameplayCamera.transform.right * -0.35f, 0.75f, previousPlayerHeldBy.gameplayCamera.transform.forward, 1.85f, shovelMask, QueryTriggerInteraction.Collide);
		    //IL_00c5: ldarg.0
		    //IL_00c6: ldarg.0
		    //IL_00c7: ldfld class GameNetcodeStuff.PlayerControllerB Shovel::previousPlayerHeldBy
		    //IL_00cc: ldfld class [UnityEngine.CoreModule]UnityEngine.Camera GameNetcodeStuff.PlayerControllerB::gameplayCamera
		    //IL_00d1: callvirt instance class [UnityEngine.CoreModule]UnityEngine.Transform [UnityEngine.CoreModule]UnityEngine.Component::get_transform()
		    //IL_00d6: callvirt instance valuetype [UnityEngine.CoreModule]UnityEngine.Vector3 [UnityEngine.CoreModule]UnityEngine.Transform::get_position()
		    //IL_00db: ldarg.0
		    //IL_00dc: ldfld class GameNetcodeStuff.PlayerControllerB Shovel::previousPlayerHeldBy
		    //IL_00e1: ldfld class [UnityEngine.CoreModule]UnityEngine.Camera GameNetcodeStuff.PlayerControllerB::gameplayCamera
		    //IL_00e6: callvirt instance class [UnityEngine.CoreModule]UnityEngine.Transform [UnityEngine.CoreModule]UnityEngine.Component::get_transform()
		    //IL_00eb: callvirt instance valuetype [UnityEngine.CoreModule]UnityEngine.Vector3 [UnityEngine.CoreModule]UnityEngine.Transform::get_right()
		    //IL_00f0: ldc.r4 -0.35
		    //IL_00f5: call valuetype [UnityEngine.CoreModule]UnityEngine.Vector3 [UnityEngine.CoreModule]UnityEngine.Vector3::op_Multiply(valuetype [UnityEngine.CoreModule]UnityEngine.Vector3, float32)
		    //IL_00fa: call valuetype [UnityEngine.CoreModule]UnityEngine.Vector3 [UnityEngine.CoreModule]UnityEngine.Vector3::op_Addition(valuetype [UnityEngine.CoreModule]UnityEngine.Vector3, valuetype [UnityEngine.CoreModule]UnityEngine.Vector3)
		    //IL_00ff: ldc.r4 0.75
		    //IL_0104: ldarg.0
		    //IL_0105: ldfld class GameNetcodeStuff.PlayerControllerB Shovel::previousPlayerHeldBy
		    //IL_010a: ldfld class [UnityEngine.CoreModule]UnityEngine.Camera GameNetcodeStuff.PlayerControllerB::gameplayCamera
		    //IL_010f: callvirt instance class [UnityEngine.CoreModule]UnityEngine.Transform [UnityEngine.CoreModule]UnityEngine.Component::get_transform()
		    //IL_0114: callvirt instance valuetype [UnityEngine.CoreModule]UnityEngine.Vector3 [UnityEngine.CoreModule]UnityEngine.Transform::get_forward()
            //IL_0119: ldc.r4 1.85
            //IL_011e: ldarg.0
            //IL_011f: ldfld int32 Shovel::shovelMask
            //IL_0124: ldc.i4.2
            //IL_0125: call valuetype [UnityEngine.PhysicsModule]UnityEngine.RaycastHit[] [UnityEngine.PhysicsModule]UnityEngine.Physics::SphereCastAll(valuetype [UnityEngine.CoreModule]UnityEngine.Vector3, float32, valuetype [UnityEngine.CoreModule]UnityEngine.Vector3, float32, int32, valuetype [UnityEngine.PhysicsModule]UnityEngine.QueryTriggerInteraction)
            //IL_012a: stfld valuetype [UnityEngine.PhysicsModule]UnityEngine.RaycastHit[] Shovel::objectsHitByShovel

            Plugin.logSrc.LogMessage("HitShovel IL Patch Start!");

            if (c.TryGotoNext(
                x => x.MatchLdarg(0),
                x => x.MatchLdarg(0),
                x => x.MatchLdfld<Shovel>("previousPlayerHeldBy"),
                x => x.MatchLdfld<PlayerControllerB>("gameplayCamera"),
                x => x.MatchCallvirt<Component>("get_transform"),
                x => x.MatchCallvirt<Transform>("get_position")
            )) {
                Plugin.logSrc.LogMessage("Try Goto Next Success!");
                c.Index++;
                _ = c.RemoveRange(25);
                _ = c.EmitDelegate((Shovel instance) => {
                    Plugin.logSrc.LogWarning("HitShovel IL Patch Start!");
                    instance.objectsHitByShovel = Physics.BoxCastAll(instance.previousPlayerHeldBy.gameplayCamera.transform.position + instance.previousPlayerHeldBy.gameplayCamera.transform.forward * 0.20f, new Vector3(0.05f * 0.5f, 0.05f * 0.5f, 1.85f * 0.5f), instance.previousPlayerHeldBy.gameplayCamera.transform.forward, instance.previousPlayerHeldBy.gameplayCamera.transform.rotation, 1.85f, instance.shovelMask, QueryTriggerInteraction.Collide);
                    Plugin.logSrc.LogWarning("HitShovel IL Patch End!");
                });
            } else {
                Plugin.logSrc.LogError("Try Goto Next Failed! Bad IL Code!");
            }
        }
    }
}
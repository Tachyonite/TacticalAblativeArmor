﻿// MeatShieldMod.cs created by Iron Wolf for TAAMeatShields on 08/21/2020 7:26 AM
// last updated 08/21/2020  7:26 AM

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using JetBrains.Annotations;
using Verse;
using RimWorld;

namespace TAAMeatShields
{
    /// <summary>
    /// static class for initializing the mod 
    /// </summary>
    [StaticConstructorOnStartup]
    public static class MeatShieldModInit
    {
        private static MeatShieldModSettings Settings => LoadedModManager.GetMod<MeatShieldMod>().GetSettings<MeatShieldModSettings>();
        
        static MeatShieldModInit() // The one true constructor.
        {
            if (Settings.bodyTypeCoverEffectiveness == null || Settings.bodyTypeCoverEffectiveness.Count == 0) {
                Settings.bodyTypeCoverEffectiveness = new Dictionary<BodyTypeDef,float>();
                foreach (BodyTypeDef bd in DefDatabase<BodyTypeDef>.AllDefsListForReading)
                {
                    Settings.bodyTypeCoverEffectiveness.Add(bd,bd.GetModExtension<BodyTypeDefExtension>().fillPercent);
                }
            }
        }
    }

}
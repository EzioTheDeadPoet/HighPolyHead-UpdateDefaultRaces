using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Noggog;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.FormKeys.SkyrimSE;
using Mutagen.Bethesda.Plugins;


namespace HighPolyHeadUpdateRaces
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetTypicalOpen(GameRelease.SkyrimSE, "HighPolyHead - Update Vanilla Races.esp")
                .Run(args);
        }

        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {

            HashSet<LinkedHeadPart> linkedHeadParts = new HashSet<LinkedHeadPart>();

            foreach (var hphHeadPart in state.LoadOrder.PriorityOrder.HeadPart().WinningOverrides())
            {
                if (hphHeadPart.EditorID == null || !hphHeadPart.EditorID.StartsWith("00KLH_")) continue;
                foreach (var vanillaHeadPart in state.LoadOrder.PriorityOrder.HeadPart().WinningOverrides())
                {
                    if (hphHeadPart.EditorID != null
                        && vanillaHeadPart.EditorID != null
                        && hphHeadPart.EditorID.EndsWith(vanillaHeadPart.EditorID))
                    {
                        linkedHeadParts.Add(new LinkedHeadPart(hphHeadPart, vanillaHeadPart));
                    }
                }
            }
            
            

            
        }
    }
}

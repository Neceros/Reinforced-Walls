using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace ReinforcedWalls
{
  [StaticConstructorOnStartup]
  public static class Startup
  {
    static Startup()
    {
      // Loads right before main menu
      RWModSettings.ReinforcedWall = ThingDef.Named("NEC_ReinforcedWall");
      RWModSettings.ReinforcedEmbrasure = ThingDef.Named("NEC_ReinforcedEmbrasure");

      // RWModSettings.OriginalDesignationCat = RWModSettings.ReinforcedEmbrasure.designationCategory;

      RWMod.UpdateChanges();
    }
  }
}

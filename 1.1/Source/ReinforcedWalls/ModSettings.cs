using RimWorld;
using System;
using System.Linq;
using UnityEngine;
using Verse;

namespace ReinforcedWalls
{
  public class RWModSettings : ModSettings
  {
    // public static bool ApplyAllowEmbrasures = true;
    public static int EmbrasureCover = 65;
    public static int WallHitPoints = 900;

    public static ThingDef ReinforcedWall;
    public static ThingDef ReinforcedEmbrasure;
    // public static DesignationCategoryDef OriginalDesignationCat;

    public override void ExposeData()
    {
      base.ExposeData();
      // Scribe_Values.Look(ref ApplyAllowEmbrasures, "ApplyAllowEmbrasures");
      Scribe_Values.Look(ref EmbrasureCover, "EmbrasureCover");
      Scribe_Values.Look(ref WallHitPoints, "WallHitPoints");
    }
  }

  public class RWMod : Mod
  {
    RWModSettings settings;
    public RWMod(ModContentPack con) : base(con)
    {
      this.settings = GetSettings<RWModSettings>();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
      Listing_Standard listing = new Listing_Standard();
      listing.Begin(inRect);
      listing.Gap(24f);
      // listing.CheckboxLabeled("EnableEmbrasure".Translate(), ref RWModSettings.ApplyAllowEmbrasures, "EnableEmbrasureTooltip".Translate());
      listing.Settings_SliderLabeled("EmbrasureCoverValueLabel".Translate(), "%", ref RWModSettings.EmbrasureCover, 1, 75);
      listing.Settings_IntegerBox("WallHitPointLabel".Translate(), ref RWModSettings.WallHitPoints, 500f, 24f, min: 300, max: 99999);
      listing.End();

      base.DoSettingsWindowContents(inRect);
    }

    public override void WriteSettings()
    {
      UpdateChanges();

      base.WriteSettings();
    }

    public override string SettingsCategory()
    {
      return "MenuTitle".Translate();
    }

    public static void UpdateChanges()
    {
      // Reference:
      // DefDatabase<HediffDef>.GetNamed("SmokeleafHigh").stages[0].capMods[0].offset = LLLModSettings.amountPenaltyConsciousness;
      // HediffDef.Named("SmokeleafHigh").stages.Where((HediffStage stage) => stage.capMods.Any((PawnCapacityModifier mod) => mod.capacity == PawnCapacityDefOf.Consciousness)).First().capMods.Where((PawnCapacityModifier mod) => mod.capacity == PawnCapacityDefOf.Consciousness).First().offset = RSModSettings.amountCramped;
      // ThingDef.Named("NEC_ReinforcedWall").statBases.Where((StatModifier statBase) => statBase.stat == StatDefOf.MaxHitPoints).First().value = RWModSettings.WallHitPoints;

      /* Can't figure out designationCats
       * 
      if (RWModSettings.ApplyAllowEmbrasures)
      {
        RWModSettings.ReinforcedEmbrasure.designationCategory = null;
      } else
      {
        RWModSettings.ReinforcedEmbrasure.designationCategory = RWModSettings.OriginalDesignationCat;
      }
      */

      RWModSettings.ReinforcedEmbrasure.fillPercent = RWModSettings.EmbrasureCover / 100f;
      RWModSettings.ReinforcedWall.statBases.Where((StatModifier statBase) => statBase.stat == StatDefOf.MaxHitPoints).First().value = RWModSettings.WallHitPoints;
    }
  }
}

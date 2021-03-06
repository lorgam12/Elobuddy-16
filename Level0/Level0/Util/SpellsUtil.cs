﻿using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace LevelZero.Util
{
    class SpellsUtil
    {
        public enum Summoners
        {
            Heal, Barrier, Cleanse, Ghost, Exhaust, Smite, Ignite, Flash
        }

        public static bool HitChanceCast(Spell.Skillshot spell, Obj_AI_Base target, float chance = 85)
        {
            var pred = spell.GetPrediction(target);

            if (pred.HitChancePercent >= chance)
                if (spell.Cast(pred.CastPosition))
                    return true;

            return false;
        }

        public static Spell.Active GetActiveSpell(string name, uint range = 0)
        {
            var slot = Player.Instance.GetSpellSlotFromName(name);

            if (slot != SpellSlot.Unknown)
            {
                return new Spell.Active(slot, range);
            }

            return null;
        }

        public static Spell.Targeted GetTargettedSpell(string name, uint range)
        {
            var slot = Player.Instance.GetSpellSlotFromName(name);

            if (slot != SpellSlot.Unknown)
            {
                return new Spell.Targeted(slot, range);
            }

            return null;
        }

        public static Spell.Skillshot GetSkillshotSpell(string name, uint range, SkillShotType type)
        {
            var slot = Player.Instance.GetSpellSlotFromName(name);

            if (slot != SpellSlot.Unknown)
            {
                return new Spell.Skillshot(slot, range, type);
            }

            return null;
        }

        public static Spell.Active GetActiveSpell(Summoners summoner)
        {
            SpellSlot slot;

            switch (summoner)
            {
                case Summoners.Heal:
                    slot = Player.Instance.GetSpellSlotFromName("summonerheal");

                    if (slot != SpellSlot.Unknown) return new Spell.Active(slot);

                    return null;

                case Summoners.Barrier:
                    slot = Player.Instance.GetSpellSlotFromName("summonerbarrier");

                    if (slot != SpellSlot.Unknown) return new Spell.Active(slot);

                    return null;

                case Summoners.Cleanse:
                    slot = Player.Instance.GetSpellSlotFromName("summonercleanse");

                    if (slot != SpellSlot.Unknown) return new Spell.Active(slot);

                    return null;

                case Summoners.Ghost:
                    slot = Player.Instance.GetSpellSlotFromName("summonerghost");

                    if (slot != SpellSlot.Unknown) return new Spell.Active(slot);

                    return null;

                default:
                    return null;
            }
        }

        public static Spell.Targeted GetTargettedSpell(Summoners summoner)
        {
            SpellSlot slot;

            switch (summoner)
            {
                case Summoners.Exhaust:
                    slot = Player.Instance.GetSpellSlotFromName("summonerexhaust");

                    if (slot != SpellSlot.Unknown) return new Spell.Targeted(slot, 650);

                    return null;

                case Summoners.Smite:
                    var spell = Player.Instance.Spellbook.Spells.FirstOrDefault(it => it.Name.Contains("summoner") && it.Name.Contains("smite"));

                    if (spell != null) return new Spell.Targeted(spell.Slot, 500);

                    return null;

                case Summoners.Ignite:
                    slot = Player.Instance.GetSpellSlotFromName("summonerdot");

                    if (slot != SpellSlot.Unknown) return new Spell.Targeted(slot, 600);

                    return null;

                default:
                    return null;
            }
        }

        public static Spell.Skillshot GetSkillshotSpell(Summoners summoner)
        {

            if (summoner != Summoners.Flash) return null;

            var slot = Player.Instance.GetSpellSlotFromName("summonerflash");

            if (slot != SpellSlot.Unknown) return new Spell.Skillshot(slot, 425, SkillShotType.Linear);

            return null;
            }
    }
}

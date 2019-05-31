using System.Collections.Generic;

namespace Transdim.DomainModel
{
    public static class Factions
    {
        public static Faction Ambas
        {
            get => new Faction
            {
                FactionIdentifier = FactionIdentifier.Ambas,
                FriendlyName = FactionIdentifier.Ambas.ToString(),
                Color = Color.Brown
            };
        }

        public static Faction BalTaks
        {
            get => new Faction
            {
                FactionIdentifier = FactionIdentifier.BalTaks,
                FriendlyName = "Bal T'aks",
                Color = Color.Orange
            };
        }

        public static Faction Becasods
        {
            get => new Faction
            {
                FactionIdentifier = FactionIdentifier.Becasods,
                FriendlyName = FactionIdentifier.Becasods.ToString(),
                Color = Color.Black
            };
        }


        public static Faction Firaks
        {
            get => new Faction
            {
                FactionIdentifier = FactionIdentifier.Firaks,
                FriendlyName = FactionIdentifier.Firaks.ToString(),
                Color = Color.Black
            };
        }


        public static Faction Geodens
        {
            get => new Faction
            {
                FactionIdentifier = FactionIdentifier.Geodens,
                FriendlyName = FactionIdentifier.Geodens.ToString(),
                Color = Color.Orange
            };
        }


        public static Faction Gleens
        {
            get => new Faction
            {
                FactionIdentifier = FactionIdentifier.Gleens,
                FriendlyName = FactionIdentifier.Gleens.ToString(),
                Color = Color.Yellow
            };
        }

        public static Faction HadschHallas
        {
            get => new Faction
            {
                FactionIdentifier = FactionIdentifier.HadschHallas,
                FriendlyName = "Hadsch Hallas",
                Color = Color.Red
            };
        }


        public static Faction Itars
        {
            get => new Faction
            {
                FactionIdentifier = FactionIdentifier.Itars,
                FriendlyName = FactionIdentifier.Itars.ToString(),
                Color = Color.White
            };
        }


        public static Faction Ivits
        {
            get => new Faction
            {
                FactionIdentifier = FactionIdentifier.Ivits,
                FriendlyName = FactionIdentifier.Ivits.ToString(),
                Color = Color.Red
            };
        }


        public static Faction Lantids
        {
            get => new Faction
            {
                FactionIdentifier = FactionIdentifier.Lantids,
                FriendlyName = FactionIdentifier.Lantids.ToString(),
                Color = Color.Blue

            };
        }


        public static Faction Nevlas
        {
            get => new Faction
            {
                FactionIdentifier = FactionIdentifier.Nevlas,
                FriendlyName = FactionIdentifier.Nevlas.ToString(),
                Color = Color.White

            };
        }


        public static Faction Taklons
        {
            get => new Faction
            {
                FactionIdentifier = FactionIdentifier.Taklons,
                FriendlyName = FactionIdentifier.Taklons.ToString(),
                Color = Color.Brown
            };
        }


        public static Faction Terrans
        {
            get => new Faction
            {
                FactionIdentifier = FactionIdentifier.Terrans,
                FriendlyName = FactionIdentifier.Terrans.ToString(),
                Color = Color.Blue
            };
        }


        public static Faction Xenos
        {
            get => new Faction
            {
                FactionIdentifier = FactionIdentifier.Xenos,
                FriendlyName = FactionIdentifier.Xenos.ToString(),
                Color = Color.Yellow
            };
        }


    public static List<Faction> AllFactions = new List<Faction>
        {
            Ambas,
            BalTaks,
            Becasods,
            Firaks,
            Geodens,
            Gleens,
            HadschHallas,
            Itars,
            Ivits,
            Lantids,
            Nevlas,
            Taklons,
            Terrans,
            Xenos
        };
    }
}

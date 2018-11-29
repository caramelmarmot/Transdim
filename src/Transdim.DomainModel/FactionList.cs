using System.Collections.Generic;

namespace Transdim.DomainModel
{
    public static class FactionList
    {
        public static List<Faction> AvailableFactions = new List<Faction>
        {
            new Faction {
                FactionIdentifier = FactionIdentifier.Ambas,
                FriendlyName = FactionIdentifier.Ambas.ToString(),
                Color =  Color.Brown
            },
            new Faction {
                FactionIdentifier = FactionIdentifier.BalTaks,
                FriendlyName = "Bal T'aks",
                Color = Color.Orange
            },
            new Faction {
                FactionIdentifier = FactionIdentifier.Becasods,
                FriendlyName = FactionIdentifier.Becasods.ToString(),
                Color = Color.Black
            },
            new Faction {
                FactionIdentifier = FactionIdentifier.Firaks,
                FriendlyName = FactionIdentifier.Firaks.ToString(),
                Color = Color.Black
            },
            new Faction {
                FactionIdentifier = FactionIdentifier.Geodens,
                FriendlyName = FactionIdentifier.Geodens.ToString(),
                Color = Color.Orange
            },
            new Faction {
                FactionIdentifier = FactionIdentifier.Gleens,
                FriendlyName = FactionIdentifier.Gleens.ToString(),
                Color = Color.Yellow
            },
            new Faction {
                FactionIdentifier = FactionIdentifier.HadschHallas,
                FriendlyName = "Hadsch Hallas",
                Color = Color.Red
            },
            new Faction {
                FactionIdentifier = FactionIdentifier.Itars,
                FriendlyName = FactionIdentifier.Itars.ToString(),
                Color = Color.White
            },
            new Faction {
                FactionIdentifier = FactionIdentifier.Ivits,
                FriendlyName = FactionIdentifier.Ivits.ToString(),
                Color = Color.Red
            },
            new Faction {
                FactionIdentifier = FactionIdentifier.Lantids,
                FriendlyName = FactionIdentifier.Lantids.ToString(),
                Color = Color.Blue
            },
            new Faction {
                FactionIdentifier = FactionIdentifier.Nevlas,
                FriendlyName = FactionIdentifier.Nevlas.ToString(),
                Color = Color.White
            },
            new Faction {
                FactionIdentifier = FactionIdentifier.Taklons,
                FriendlyName = FactionIdentifier.Taklons.ToString(),
                Color = Color.Brown
            },
            new Faction {
                FactionIdentifier = FactionIdentifier.Terrans,
                FriendlyName = FactionIdentifier.Terrans.ToString(),
                Color = Color.Blue
            },
            new Faction {
                FactionIdentifier = FactionIdentifier.Xenos,
                FriendlyName = FactionIdentifier.Xenos.ToString(),
                Color = Color.Yellow
            }
        };
    }
}

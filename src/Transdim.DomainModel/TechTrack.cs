namespace Transdim.DomainModel
{
    public class TechTrack
    {
        public TechTrackIdentifier Identifier { get; set; }

        public ITech StandardTech { get; set; }

        public ITech AdvancedTech { get; set; }
    }
}

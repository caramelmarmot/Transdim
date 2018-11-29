namespace Transdim.DomainModel
{
    public interface ITech
    {
        TechIdentifier Identifier { get; }

        string TechImagePath { get; }

        bool IsAdvancedTech { get; }
    }
}

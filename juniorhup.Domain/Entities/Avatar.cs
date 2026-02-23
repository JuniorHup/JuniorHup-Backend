namespace juniorhup.Domain.Entities
{
    public class Avatar
    {
        public int AvatarId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string ThemeColor { get; set; } = string.Empty;
        public string AssetPath { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<ChildProfile> ChildProfiles { get; set; } = new List<ChildProfile>();
    }
}


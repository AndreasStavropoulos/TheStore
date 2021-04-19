namespace TheStore.Models
{
    public interface ITShirt
    {
        TShirt.Size TShirtSize { get; set; }
        TShirt.Style TShirtStyle { get; set; }
    }
}
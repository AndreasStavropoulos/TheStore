namespace TheStore.Models
{
    public interface IJacket
    {
        Jacket.Material JacketMaterial { get; set; }
        Jacket.Size JacketSize { get; set; }
        Jacket.Style JacketStyle { get; set; }
    }
}
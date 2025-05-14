namespace TechXpress_PL.ViewModels
{
    public class WishlistOperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public WishlistVm? Item { get; set; }
    }
}

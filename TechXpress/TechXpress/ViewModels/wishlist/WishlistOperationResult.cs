﻿namespace TechXpress_PL.ViewModels.wishlist
{
    public class WishlistOperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public WhishlistVm? Item { get; set; }
    }
}

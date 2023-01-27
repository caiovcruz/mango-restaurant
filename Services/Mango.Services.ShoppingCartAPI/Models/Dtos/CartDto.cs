using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ShoppingCartAPI.Models.Dtos
{
    public class CartDto
    {
        public CartHeader CartHeader { get; set; }

        public IEnumerable<CartDetails> CartDetails { get; set; }
    }
}
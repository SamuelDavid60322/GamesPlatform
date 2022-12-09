using GamesPlatform.Data;

namespace GamesPlatform.Models
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private ShoppingCart(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public string ShoppingCartID { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;

            var context = services.GetService<ApplicationDbContext>();
            string cartID = session.GetString("CartID") ?? Guid.NewGuid().ToString();

            session.SetString("CartID", cartID);

            return new ShoppingCart(context) { ShoppingCartID = cartID };
        }

    }
}

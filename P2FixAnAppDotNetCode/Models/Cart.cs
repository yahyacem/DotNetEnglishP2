using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        /// <summary>
        /// Stored cart variable that will contain products
        /// </summary>
        private List<CartLine> cartLine = new List<CartLine>();

        /// <summary>
        /// Read-only property for dispaly only
        /// </summary>
        public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {
            return cartLine;
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            // Find if product is already present in cart line
            CartLine match = GetCartLineList().Find(x => x.Product.Id == product.Id);

            if (match != null)
            {
                // If already present, just modify quantity
                match.Quantity += quantity;
            } else
            {
                // If not present, add product to cart
                GetCartLineList().Add(new CartLine()
                {
                    OrderLineId = Lines.Count(),
                    Product = product,
                    Quantity = quantity
                });
            }
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // TODO implement the method
            return 0.0;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // Declare the quantity and price variables
            int quantity = 0;
            double price = 0.0;

            // Loop into the list of products
            foreach (CartLine line in Lines)
            {
                // Get the quantity of products
                quantity += line.Quantity;

                // Get the price of product multiplied by the quantity
                price += line.Product.Price * line.Quantity;
            }

            // Return the average price per product in the cart
            return price / quantity;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // Find product matching with given Id
            return GetCartLineList().Find(x => x.Product.Id == productId).Product;
        }

        /// <summary>
        /// Get a specifid cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

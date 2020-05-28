using System.Collections.Generic;
using TugasWorkshop.Database.Model;

namespace TugasWorkshop.Database {
    public class ProductDatabase {
        private static ProductDatabase instance;
        private List<Product> products = new List<Product>();
        private ProductDatabase() {

        }

        public static ProductDatabase getInstance() {
            if (instance == null) {
                instance = new ProductDatabase();
            }
            return instance;
        }

        public List<Product> getProducts() {
            return products;
        }

        public void addProduct(Product _product) {
            products.Add(_product);
        }
    }
}

using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class productsShop
    {
        public static void startApp()
        {
            PaymentEvent user = new PaymentEvent("User: ");
            user.UserNotified += PayPalNotified;
            user.UserNotified += CreditCardNotified;



            #region

            Console.WriteLine("Log in to start using this app.");
            Console.WriteLine("Enter Username");


            var username = new Entities.User(Console.ReadLine());
            var userOrders = new Entities.User().Orders;
            var vendorItems = new Entities.VendorItems().VendorItemsList;
            var productsItems = new Dictionary<string, List<ProductItem>>();
            productsItems.Add("VW", new List<ProductItem>()

                {
                        new ProductItem("VW Golf VII R 2.0 Petrol",30000,001),
                        new ProductItem("VW Arteon 2.0 Petrol",35000,002),
                        new ProductItem("VW Passat 2.0 Diesel",25000,003)


                });

            productsItems.Add("Audi", new List<ProductItem>()
                {
                        new ProductItem("Audi RS7 3.0 Diesel",50000,004),
                        new ProductItem("Audi RS4 Avant 2.9 Petrol",70000,005),
                        new ProductItem("Audi S8 3.0 Diesel",100000,006)

                });

            productsItems.Add("BMW", new List<ProductItem>()
                {
                        new ProductItem("BMW M760LI 6.6 Petrol",180000,007),
                        new ProductItem("BMW X5 3.0 Diesel",55000,008),
                        new ProductItem("BMW M4 CS 3.0 Petrol",75000,009)

                });

            bool productsShop = true;
            while (productsShop)
            {
                Console.WriteLine("1. See the whole list of Vendors");
                Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
                Console.WriteLine("2. Search by Vendor name for their products");
                Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
                Console.WriteLine("3. Search by part of name of Products");
                Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
                Console.WriteLine("4. Sort products by product name, enter VW,Audi or BMW");
                Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
                Console.WriteLine("5. Sort products by product price");
                Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
                Console.WriteLine("6. Make a order");
                Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
                Console.WriteLine("7. Show orders");
                Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
                Console.WriteLine("8. Remove order");
                Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
                Console.WriteLine("9. View orders and");
                Console.WriteLine("Submit order and continue to choose paying method and shipping");
                Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");

                Console.WriteLine("To close this app please enter escape key.");
                Console.WriteLine("_______________________________________________");

                #endregion

                var getUserInput = 0;
                bool isValidInput = Int32.TryParse(Console.ReadLine(), out getUserInput);
                if (isValidInput == false || getUserInput < 1 || getUserInput > 8)
                {
                    Console.WriteLine("Your input is invalid. Please try again.");
                }
                #region
                switch (getUserInput)
                {
                    case 1:
                        Console.WriteLine("Vendors:");
                        Console.WriteLine("_ _ _ _ _ _ _");
                        foreach (var vendor in vendorItems)
                        {
                            Console.WriteLine(vendor);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Select from VW , Audi , BMW");
                        Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _");
                        var vendorsBrands = Console.ReadLine();

                        foreach (var product in productsItems[vendorsBrands])
                        {
                            Console.WriteLine($"Name : {product.Name}\n price:{product.Price}\n Product code:{product.ProductCode}");
                            Console.WriteLine("______________________");
                        }
                        break;
                    case 3:

                        Console.WriteLine("Enter name of product to get that product");
                        var inputProductName = Console.ReadLine();
                        var searchProductName = productsItems.Select(c => c.Value.Where(y => y.Name == inputProductName));
                        foreach (var product in searchProductName)
                        {
                            foreach (var product2 in product)
                            {
                                Console.WriteLine(product2.Name);
                            }
                        }
                        break;
                    #endregion
                    #region
                    case 4:
                        var userProducts = Console.ReadLine();
                        Console.WriteLine("Write asc for sorted list by product name by ascending, or desc for oposite");
                        if (userProducts == "asc")
                        {
                            Console.WriteLine("Sorted list by product name Asc:");

                            var sortByProductNameAsc = productsItems[userProducts].OrderBy(x => x.Name);

                            foreach (var product in sortByProductNameAsc)
                            {
                                Console.WriteLine($"Name : {product.Name}\n price:{product.Price}\n Product code:{product.ProductCode}");
                                Console.WriteLine("______________________");
                            }
                        }
                        if (userProducts == "desc")
                        {
                            Console.WriteLine("Sorted list by product name Desc:");

                            var sortByProductNameDesc = productsItems[userProducts].OrderByDescending(x => x.Name);

                            foreach (var product in sortByProductNameDesc)
                            {
                                Console.WriteLine($"Name : {product.Name}\n price:{product.Price}\n Product code:{product.ProductCode}");
                                Console.WriteLine("______________________");
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("Write asc for sorted list by product price by ascending, or desc for oposite");
                        var userProductsPrice = Console.ReadLine();
                        if (userProductsPrice == "asc")
                        {
                            Console.WriteLine("Sorted list by product name Asc:");

                            var sortByProductNameAsc = productsItems[userProductsPrice].OrderBy(x => x.Price);

                            foreach (var product in sortByProductNameAsc)
                            {
                                Console.WriteLine($"Name : {product.Name}\n price:{product.Price}\n Product code:{product.ProductCode}");
                                Console.WriteLine("______________________");
                            }
                        }
                        if (userProductsPrice == "desc")
                        {
                            Console.WriteLine("Sorted list by product name Desc:");

                            var sortByProductNameDesc = productsItems[userProductsPrice].OrderByDescending(x => x.Price);

                            foreach (var product in sortByProductNameDesc)
                            {
                                Console.WriteLine($"Name : {product.Name}\n price:{product.Price}\n Product code:{product.ProductCode}");
                                Console.WriteLine("______________________");
                            }
                        }

                        break;
                    #endregion
                    #region
                    case 6:
                        bool addOrderToCart = true;
                        while (addOrderToCart)
                        {
                            Console.WriteLine("Enter product cod");
                            long productCode = long.Parse(Console.ReadLine());
                            Console.WriteLine("Number of products");
                            int quantity = Int32.Parse(Console.ReadLine());

                            foreach (var item in productsItems)
                            {
                                var product = item.Value.Find(c => c.ProductCode == productCode);
                                if (product != null)
                                {
                                    double totalPrice = quantity * product.Price;
                                    var order = new OrderItem(new ProductItem(
                                        product.Name,
                                        product.Price,
                                        product.ProductCode),
                                        quantity,
                                        totalPrice);
                                    userOrders.Add(order);
                                }

                            }
                            Console.WriteLine("You can continue to add orders or submit current orders");
                            Console.WriteLine("To continue adding orders enter add,to submit orders enter submit");
                            addOrderToCart = Console.ReadLine() == "add" ? true : false;
                        }
                        break;
                    case 7:
                        foreach (var orderProducts in userOrders)
                        {
                            Console.WriteLine($"Name: {orderProducts.Product.Name}\n price:{orderProducts.Product.Price}\n quantity: {orderProducts.Quantity}");
                            Console.WriteLine("_____________________________________");
                        }
                        break;
                    case 8:
                        for (int i = 0; i < userOrders.Count; i++)
                        {
                            Console.WriteLine($"{i}:Name:{userOrders[i].Product.Name}\n price:{userOrders[i].Product.Price}\n quantity:{userOrders[i].Quantity}");
                        }
                        Console.WriteLine("Select the row number of the product you want to remove");
                        int removedProduct = int.Parse(Console.ReadLine());
                        userOrders.RemoveAt(removedProduct);
                        foreach (var item in userOrders)
                        {
                            Console.WriteLine($"Name:{item.Product.Name}\n price:{item.Product.Price}\n quanity:{item.Quantity}");
                            Console.WriteLine("________________________");
                        }

                        break;
                    #endregion
                    #region
                    case 9:
                        Console.WriteLine(username.Name);
                        for (int i = 0; i < userOrders.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}:Name:{userOrders[i].Product.Name} price:{userOrders[i].Product.Price} quanity:{userOrders[i].Quantity}");

                        }
                        double totalSum = userOrders.Sum(el => el.TotalPrice);
                        Console.WriteLine("Total:" + totalSum);

                        Console.WriteLine("You can continue to add orders or pay and ship current orders");
                        Console.WriteLine("To continue adding orders enter add , to continue to paying and shipping orders enter submit");
                        var userInput = Console.ReadLine();

                        if (userInput == "submit")
                        {
                            Console.WriteLine("Pay with credit card or paypal by entering credit or pay");

                            var creditCard = Console.ReadLine();
                            if (creditCard == "credit")
                            {
                                user.UserNotified += (msg)
                                    => Console.WriteLine("credit");
                            }
                            if (creditCard == "pay")
                            {
                                user.UserNotified += (msg)
                                   => Console.WriteLine("payPal");
                            }
                            Console.WriteLine("If you are living in Skopje, Bitola, Ohrid, Stip you can get your products by entering your city name");

                            var city = Console.ReadLine();
                            if (city == "Skopje" || city == "Bitola" || city == "Ohrid" || city == "Stip")
                            {
                                Console.WriteLine("Please enter posta or delco to ship your orders");

                                var ship = Console.ReadLine();

                                if (ship == "posta")
                                {
                                    Console.WriteLine("Your orders are shipped by posta....");
                                }
                                if (ship == "delco")
                                {
                                    Console.WriteLine("Your orders are shipped by delco....");

                                }

                                #endregion
                                Console.WriteLine("See your list of expensive orders above 50.000 or see your cheap orders under 50.000 by entering exp or cheap");
                                Console.WriteLine("Enter exp or cheap");
                                var cost = Console.ReadLine();
                                if (cost == "exp")
                                {
                                    double fiveK = 50.000;
                                    double totalSumExp = userOrders.Sum(el => el.TotalPrice);
                                    Console.WriteLine($"Total:{totalSumExp > fiveK}");
                                    

                                }
                                if (cost == "cheap")
                                {
                                    double fiveK = 50.000;
                                    double totalSumCheap = userOrders.Sum(el => el.TotalPrice);
                                    Console.WriteLine($"Total:{totalSumCheap > fiveK}");


                                }
                            }
                        }


                        else
                        {
                            Console.WriteLine("We dont have service for shipping in your city yet or you dont choose right paying method");

                        }


                        break;
                    case 10:
                        productsShop = false;
                        break;
                    default:
                        Console.WriteLine("Please choose from the list");
                        break;
                }
            }
        }

        static void PayPalNotified(string msg)
        {
            Console.WriteLine("Your orders are paid with PayPal", msg);
        }

        static void CreditCardNotified(string msg)
        {
            Console.WriteLine("Your orders are paid with CreditCard", msg);
        }

    }


}

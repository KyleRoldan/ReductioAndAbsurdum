

List<Product> products = new List<Product>()
{

new()
{
Name= "Hidranga",
Price = 1.5M,
Sold = false,
ProductTypeId = 1,
DateStocked = new DateTime(2022, 10, 20)
},

new ()
{
Name= "Hidranga",
Price = 1.5M,
Sold = false,
ProductTypeId = 2,
DateStocked = new DateTime(2022, 10, 20)
},

new ()
{
Name= "Hidranga",
Price = 1.5M,
Sold = false,
ProductTypeId = 3,
DateStocked = new DateTime(2022, 10, 20)
},

new()
{
Name= "Hidranga",
Price = 1.5M,
Sold = false,
ProductTypeId = 4,
DateStocked = new DateTime(2022, 10, 20)
},

new()
{

Name= "Hidranga",
Price = 1.5M,
Sold = false,
ProductTypeId = 5,
DateStocked = new DateTime(2022, 10, 20)
}

};

List<ProductType> productTypes = new List<ProductType>()
{

 new()
{
    Id = 1,
    Name = "Apparel"
},

 new()
{
    Id = 2,
    Name = "Potions"
},

 new()
{
    Id = 3,
    Name = "Enchanted Objects"
},

 new()
{
    Id = 4,
    Name = "Wands"
},

};

/////////////Greeting////////////////
string greeting = @" Welcome to Reductio & Absurdum!";
/////////////////////////////////////

Console.WriteLine(greeting);
//////////////////////////////////////


while (true)
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. Display All Products
                        2. Post a Product to inventory
                        3. Delete a Product
                        4. Update a Product
                        5. Search by Category
                        6. Display All Available Products
                        ");

    string? choice = Console.ReadLine()?.Trim();

    Console.Clear();

    if (string.IsNullOrEmpty(choice))
    {
        Console.WriteLine("You didn't choose anything!");
    }
    else
    {
        try
        {
            switch (choice)
            {
                case "0":
                    GoodByeGreeting();
                    break;
                 case "1":
                    DisplayAllProducts();
                    break;
                case "2":
                    PostAProductToInventory();
                    break;
                case "3":
                    DeleteAProduct();
                    break;
                case "4":
                    UpdateAProduct();
                    break;
                case "5":
                    SearchByCategory();
                    break;
                case "6":
                    DisplayAllAvailableProduct();
                    break;
                    

                default:
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }
    }
}
//////////////////////Beginning of Code////////////////////////////////////////////////////

void GoodByeGreeting()
{
    Console.WriteLine(@"Are you sure you want to exit?
                    0. Yes
                    1. No");

    string? goodByeChoice = Console.ReadLine();

    Console.Clear();

    if (goodByeChoice == "0")
    {
        Console.WriteLine("Goodbye!");
        Environment.Exit(0);
    }
    else if (goodByeChoice == "1")
    {

        Console.WriteLine(greeting);
        goodByeChoice = null;
    }
};
/////////////////DISPLAY ALL PRODUCTS/////////////////////////////

void DisplayAllProducts()
{
    
Console.WriteLine("Products:");
for (int i = 0; i < products.Count; i++)
{
    Console.WriteLine($"{i + 1}. {ProductDetails(products[i])}");
}
}
//////////////////POST A NEW PRODUCT//////////////////////////////

void PostAProductToInventory()
{
    Console.WriteLine("Enter New Product details:");

    Console.Write("Name: ");
    string? name = Console.ReadLine();

    Console.WriteLine("Choose the product category:");

    // Display the list of product types
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Name}");
    }

    Console.Write("Enter the number of the product category: ");
    int productTypeId;
    while (!int.TryParse(Console.ReadLine(), out productTypeId) || productTypeId < 1 || productTypeId > productTypes.Count)
    {
        Console.WriteLine("Invalid product category choice. Please enter a valid number.");
        Console.Write("Product Category ID: ");
    }

    Console.Write("Price: ");
    decimal price;
    while (!decimal.TryParse(Console.ReadLine(), out price))
    {
        Console.WriteLine("Invalid input. Please enter a valid number for Asking Price.");
        Console.Write("Asking Price: ");
    }

    
    // Create a new Product object 
    Product newProduct = new()
    {
        Name = name,
        ProductTypeId = productTypeId,
        Price = price,
        Sold = false,
        
    };

    // Add the newPlant object to the plants List
    products.Add(newProduct);

    Console.WriteLine("New Product created! Press enter to continue.");
    Console.ReadLine();
}
//////////////DELETE A PRODUCT/////////////////////////////////
///
void DeleteAProduct()
{
   
    Console.WriteLine("Choose a product to delete:");

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }

    
    Console.Write("Enter the number of the product you want to delete (0 to cancel): ");
    if (int.TryParse(Console.ReadLine(), out int deleteChoice))
    {
        if (deleteChoice >= 1 && deleteChoice <= products.Count)
        {
            // Remove the chosen plant from the list
            products.RemoveAt(deleteChoice - 1);

            Console.WriteLine("Product deleted. Press enter to continue.");
            Console.ReadLine();
        }
        else if (deleteChoice == 0)
        {
            Console.WriteLine("Deletion canceled. Press enter to continue.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Invalid choice. Press enter to continue.");
            Console.ReadLine();
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Press enter to continue.");
        Console.ReadLine();
    }
}
/////////////////UPDATE A PRODUCT///////////////////////////////

void UpdateAProduct()
{
    Console.WriteLine("Choose a product to update:");

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }

    Console.Write("Enter the number of the product you want to update (0 to cancel): ");
    if (int.TryParse(Console.ReadLine(), out int updateChoice))
    {
        if (updateChoice >= 1 && updateChoice <= products.Count)
        {
            // Get the chosen product
            Product productToUpdate = products[updateChoice - 1];

            Console.WriteLine("Enter updated product details:");

            Console.Write("Name: ");
            string? updatedName = Console.ReadLine();
            if (!string.IsNullOrEmpty(updatedName))
            {
                productToUpdate.Name = updatedName;
            }

            // Console.Write("Product Category ID (on a scale of 1-4): ");
            // int updatedProductTypeId;
            // if (int.TryParse(Console.ReadLine(), out updatedProductTypeId) && updatedProductTypeId >= 1 && updatedProductTypeId <= 4)
            // {
            //     productToUpdate.ProductTypeId = updatedProductTypeId;
            // }

            Console.WriteLine("Choose the product category:");

            // Display the list of product types
            for (int i = 0; i < productTypes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {productTypes[i].Name}");
            }

            Console.Write("Enter the number of the product category: ");
            if (int.TryParse(Console.ReadLine(), out int updatedProductTypeId))
            {
                if (updatedProductTypeId >= 1 && updatedProductTypeId <= productTypes.Count)
                {
                    // Update the ProductTypeId based on the chosen product category
                    productToUpdate.ProductTypeId = productTypes[updatedProductTypeId - 1].Id;
                }
                else
                {
                    Console.WriteLine("Invalid product category choice. Product category not updated.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for product category. Product category not updated.");
            }


            Console.Write("Price: ");
            decimal updatedPrice;
            if (decimal.TryParse(Console.ReadLine(), out updatedPrice))
            {
                productToUpdate.Price = updatedPrice;
            }

            Console.WriteLine("Product updated. Press enter to continue.");
            Console.ReadLine();
        }
        else if (updateChoice == 0)
        {
            Console.WriteLine("Update canceled. Press enter to continue.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Invalid choice. Press enter to continue.");
            Console.ReadLine();
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Press enter to continue.");
        Console.ReadLine();
    }
}

void SearchByCategory()
{
    Console.WriteLine("Search By Category");
    Console.WriteLine("Available Categories:");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Name}");
    }

    Console.Write("Please Enter a Category ID: ");
    if (int.TryParse(Console.ReadLine(), out int categoryId))
    {
        if (categoryId < 1 || categoryId > 5)
        {
            Console.WriteLine("Invalid input. Category ID should be between 1 and 5.");
            Console.ReadLine();
            return;
        }

        List<Product> searchResults = new List<Product>();

        // Loop through the products and add those that match the selected category to the searchResults list
        foreach (Product product in products)
        {
            if (product.ProductTypeId == categoryId)
            {
                searchResults.Add(product);
            }
        }

        // Display search results
        Console.WriteLine($"Products with Category ID {categoryId}:");
        for (int i = 0; i < searchResults.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {ProductDetails(searchResults[i])}");
        }

        Console.WriteLine("Press enter to continue.");
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number for Category ID.");
        Console.ReadLine();
    }
}



   void DisplayAllAvailableProduct()
{
    var unsoldProducts = products.Where(p => !p.Sold);

    Console.WriteLine("Available Products:");
    unsoldProducts.Select((product, index) => $"{index + 1}. {ProductDetails(product)}")
                  .ToList()
                  .ForEach(Console.WriteLine);
}















string ProductDetails (Product products)
{
    string productStatus = products.Sold ? "is no longer available" : "is available";
    string productPrice = $"{products.Price:C}";
    string productId = $"{products.ProductTypeId}";
    string productName = $"{products.Name}";
    int daysOnShelf = products.DaysOnShelf;

    string plantString = @$"{productName} has a category ID of {productId}. 
    It costs {productPrice} and it {productStatus}.
    It has been on the shelf for {daysOnShelf} days";

    return plantString;
}

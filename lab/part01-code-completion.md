# Part 01: Code Completion with Ghost Text

In this section, you'll use GitHub Copilot's code completion to implement API endpoints.

> IMPORTANT: For this exercise, **DO NOT** copy and paste the code snippet provided, but rather type it manually. This will allow you to experience code completion as you would if you were coding back at your desk. You'll likely see you only have to type a few characters before GitHub Copilot begins suggesting the rest.

1. [] Stop debugging the appliaction if it is currently running.

1. [] In the Solution Explorer, in the **Products** project, open **Endpoints/ProductEndpoints.cs** - it will have a single endpoint implemented.

   > Note: GitHub Copilot will not give code suggestions when debugging.
   
1. [] Let's implement a new **MapGet** to get product details for a specific **id**. Move our cursor and click on line 20 under the existing **/** endpoint. Text suggestion may apprear or type:
   ```csharp
   g
   ```
1. [] Wait for the ghost text suggestions to appear (gray text).
;
   ![Code suggestions](./images/1-ghost-text.png)

1. [] Press Tab to accept the suggestion or continue typing to get more specific suggestions.

1. [] From there Next Edit Suggetions (NES) or addtional Ghost Text suggestions will appear. 

   ![NES showing up](./images/1-nes.png)

1. [] We now can implement the following endpoints using GitHub Copilot:
   - POST to create a new product
   - PUT to update a product
   - DELETE to remove a product

   - We can continue to use suggestions OR we could open GitHub Copilot Chat and work with Agent mode:
     - Open GitHub Copilot Chat in the top-right corner of Visual Studio and select **Open Chat Window** or press `Ctrl+\+C` if Copilot chat isn't open.
     - Switch to **Agent** mode.
     - ![Switch to agent mode](./images/1-agent.png)]
     - Ask the agent: `Can you implement the rest of the endpoints for the Product API and also implement the ProductService to call these new endpoints in the Store project?`

   The end code in **ProductEndpoints.cs** sould look similar to:

   ```csharp
   group.MapGet("/", async (ProductDataContext db) =>
   {
      return await db.Product.ToListAsync();
   })
   .WithName("GetAllProducts")
   .Produces<List<Product>>(StatusCodes.Status200OK);

   group.MapGet("/{id}", async  (int id, ProductDataContext db) =>
   {
      return await db.Product.AsNoTracking()
            .FirstOrDefaultAsync(model => model.Id == id)
            is Product model
               ? Results.Ok(model)
               : Results.NotFound();
   })
   .WithName("GetProductById")
   .Produces<Product>(StatusCodes.Status200OK)
   .Produces(StatusCodes.Status404NotFound);

   group.MapPut("/{id}", async  (int id, Product product, ProductDataContext db) =>
   {
      var affected = await db.Product
            .Where(model => model.Id == id)
            .ExecuteUpdateAsync(setters => setters
            .SetProperty(m => m.Id, product.Id)
            .SetProperty(m => m.Name, product.Name)
            .SetProperty(m => m.Description, product.Description)
            .SetProperty(m => m.Price, product.Price)
            .SetProperty(m => m.ImageUrl, product.ImageUrl)
            );

      return affected == 1 ? Results.Ok() : Results.NotFound();
   })
   .WithName("UpdateProduct")
   .Produces(StatusCodes.Status404NotFound)
   .Produces(StatusCodes.Status204NoContent);

   group.MapPost("/", async (Product product, ProductDataContext db) =>
   {
      db.Product.Add(product);
      await db.SaveChangesAsync();
      return Results.Created($"/api/Product/{product.Id}",product);
   })
   .WithName("CreateProduct")
   .Produces<Product>(StatusCodes.Status201Created);

   group.MapDelete("/{id}", async  (int id, ProductDataContext db) =>
   {
      var affected = await db.Product
            .Where(model => model.Id == id)
            .ExecuteDeleteAsync();

      return affected == 1 ? Results.Ok() : Results.NotFound();
   })
   .WithName("DeleteProduct")
   .Produces<Product>(StatusCodes.Status200OK)
   .Produces(StatusCodes.Status404NotFound);
   ```

   In the **Store** project in the solution explorer open **Services/ProductService.cs**, the code sould look similar to:

   ```cs
   using DataEntities;
   using System.Text.Json;
   
   namespace Store.Services;
   
   public class ProductService
   {
      HttpClient httpClient;
      public ProductService(HttpClient httpClient)
      {
         this.httpClient = httpClient;
      }
      public async Task<List<Product>> GetProducts()
      {
         List<Product>? products = null;
         var response = await httpClient.GetAsync("/api/Product");
         if (response.IsSuccessStatusCode)
         {
               var options = new JsonSerializerOptions
               {
                  PropertyNameCaseInsensitive = true
               };
   
               products = await response.Content.ReadFromJsonAsync(ProductSerializerContext.Default.ListProduct);
         }
   
         return products ?? new List<Product>();
      }
   
      public async Task<Product?> GetProductById(int id)
      {
         var response = await httpClient.GetAsync($"/api/Product/{id}");
         if (response.IsSuccessStatusCode)
         {
               return await response.Content.ReadFromJsonAsync<Product>(ProductSerializerContext.Default.Product);
         }
         return null;
      }
   
      public async Task<bool> CreateProduct(Product product)
      {
         var response = await httpClient.PostAsJsonAsync("/api/Product", product, ProductSerializerContext.Default.Product);
         return response.IsSuccessStatusCode;
      }
   
      public async Task<bool> UpdateProduct(int id, Product product)
      {
         var response = await httpClient.PutAsJsonAsync($"/api/Product/{id}", product, ProductSerializerContext.Default.Product);
         return response.IsSuccessStatusCode;
      }
   
      public async Task<bool> DeleteProduct(int id)
      {
         var response = await httpClient.DeleteAsync($"/api/Product/{id}");
         return response.IsSuccessStatusCode;
      }
   }
   ```

   > NOTE: Because LLMs are probabilistic, not deterministic, the exact code generated can vary. The above is a representative example. If your code is different, that's just fine as long as it works!

1. [] Go back to **ProductEndpoints.cs**, and try changing the variable name of **id** to `productId` in the new **MapGet** method and see Next Edit Suggestions help out.

   ![NES suggestions more](./images/1-nes-2.png)

1. [] Try using documentation generation:
   - Type `///` above a method to generate XML documentation on the **MapProductEndpoints** this can also be brought up with `Alt+/` for inline and then entering **/** which will bring up a list of commands.

   ![documentation generation by Copilot](./images/1-docs.png)

1. [] Test your implementation:
   - Run the AppHost project.
   - Test your new endpoints by going to **https://localhost:7130/api/Product/1**

1. [] Stop debugging and close the application

---

[Back: Part 00 - Exploring the Codebase with GitHub Copilot Chat](./part00-exploring-codebase.md) ? | [Next: Part 02 - Enhancing UI with Inline Chat](./part02-enhancing-ui.md) ?

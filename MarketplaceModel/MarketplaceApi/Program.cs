using MarketplaceApi.Services.Items;

var builder = WebApplication.CreateBuilder(args);
{
builder.Services.AddControllers();
//Every time a controller object is created we tell it that implement the interface by creating an ItemService object
//Also AddSingleton is used so that every time a method is called and an object is created, our application will 
//once it has been created once, the same object for the ItemService 
builder.Services.AddSingleton<IitemService,ItemService>();

}

var app = builder.Build();
{
//The ExceptionHandler method just re-routes the request to the /error endpoint which will be handled by the ErrorController
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();


}
//Gia na trekseis to project prepei na eisai sto dir \MarketplaceModel\MarketplaceApi\
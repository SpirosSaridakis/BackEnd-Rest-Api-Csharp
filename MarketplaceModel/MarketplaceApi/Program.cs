var builder = WebApplication.CreateBuilder(args);
{
builder.Services.AddControllers();

}

var app = builder.Build();
{

app.UseHttpsRedirection();
app.MapControllers();
app.Run();


}
//Gia na trekseis to project prepei na eisai sto dir \MarketplaceModel\MarketplaceApi\
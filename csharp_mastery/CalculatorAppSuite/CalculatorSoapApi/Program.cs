using CalculatorSoapApi.Services;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Map SOAP service
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<ICalculatorService>("/Calculator.svc", new SoapCore.SoapEncoderOptions(), SoapCore.SoapSerializer.DataContractSerializer);
});

app.Run();

using Dumpify;
using GeneratedCode;

var api = Refit.RestService.For<IMiniWebApi01>("http://localhost:5018");
var result = await api.GetWeatherForecast();
result.Dump();
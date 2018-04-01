namespace WeatherSolution
open FSharp.Data
module weatherParser =

type Json = JsonProvider<"sample.json">
let API_KEY = "YourAPIKey" // PUT YOUR API KEY HERE
let get_info (city: string) = Http.RequestString("http://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=" + API_KEY + "&units=metric" )
let Json_Info info  = Json.Parse(info.ToString())



namespace WeatherSolution 
open FSharp.Data
open weatherParser
open System
module WeatherInformationPanel =

let greetings_scr = "\n###########################################################################"+
                    "\n#######                 WEATHER BROADCASTER TERMINAL              #######"+
                    "\n###########################################################################"

let greetings_mid = "\nWelcome to Weather Broadcaster Terminal V.1! We are here to serve you!\n"+
                    "Dont worry, we are also aware of the problem that this terminal looks really,"+
                    "\nreally, really ugly. We will solve that in the future. F# is not the best language"+
                    " for writing good GUI to be honest.\n"
                                        

let options = "\n\nWhat do you want to do? (Please enter only number i.e > 1) \n1) Get spesific city weather information.\n2) Exit\nYour selection is |> "

type ConsoleColor(color) =
    let colVal = color
    let a = if colVal = "red" then System.Console.ForegroundColor <- ConsoleColor.Red
            elif colVal = "green" then System.Console.ForegroundColor <- ConsoleColor.Green
            elif colVal = "blue" then System.Console.ForegroundColor <- ConsoleColor.Blue
            elif colVal = "yellow" then System.Console.ForegroundColor <- ConsoleColor.Yellow
            elif colVal = "dred" then System.Console.ForegroundColor <- ConsoleColor.DarkRed
            elif colVal = "dgreen" then System.Console.ForegroundColor <- ConsoleColor.DarkGreen
            else System.Console.ForegroundColor <- ConsoleColor.White

[<EntryPoint>]
let main argv =
    ConsoleColor("green")
    Console.Write greetings_scr
    ConsoleColor("dgreen")
    Console.Write greetings_mid

    ConsoleColor("")
    Console.Write options
    let mutable selectionInput = Console.ReadLine()
    let mutable continueLooping = if selectionInput = "2" then false else true

    while continueLooping do
        ConsoleColor("yellow")
        Console.Write("\nWhich city do you want to get info |> ")
        let input = Console.ReadLine()
        ConsoleColor("green")   
        let info = weatherParser.get_info input
        let All_Info = weatherParser.Json_Info info
        let City_Name = All_Info.Name 
        let Weather_Desc = All_Info.Weather.[0].Description
        let Weather_Main = All_Info.Weather.[0].Main 
        let Weather_Temp = All_Info.Main.Temp
        let Weather_Press = All_Info.Main.Pressure
        let Weather_Wind = All_Info.Wind.Speed

        printfn "\n\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++"
        printfn "City name is %s. \nCurrently its %.2fC degree with pressure %i hPa\nWeather condition can be described as %A. Wind speed is %.2f" City_Name Weather_Temp Weather_Press Weather_Desc Weather_Wind
        printfn "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++"

        ConsoleColor("")
        Console.Write options
        selectionInput <- Console.ReadLine()
        if selectionInput <> "2" then continueLooping <- true else continueLooping <- false

    0 
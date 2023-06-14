// Para compilar y ejecutar el programa
// - Ir al directorio donde se encuentra el proyecto
// - Ejecutar el comando dotnet build
// - Ejecutar el comando dotnet run

// For more information see https://aka.ms/fsharp-console-apps
// printfn "Hello from F#"


open System

let mutable run = true

// let leer_teclado =

while run do
    if Console.KeyAvailable then
        let key = Console.ReadKey(true).Key
        match key with
        | ConsoleKey.Q -> run <- false // Presionar Q para detener el loop
        | ConsoleKey.LeftArrow -> printfn "Has presionado <-"
        | ConsoleKey.RightArrow -> printfn "Has presionado ->"
        | _ -> printfn "Sin efecto %A" key
    else
        () // printfn "No presionaste ninguna letra"

    System.Threading.Thread.Sleep(10) // espera un segundo


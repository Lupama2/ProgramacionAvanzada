// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F# v2"


//Importo la biblioteca MyLibrary
open MyLibrary


[<EntryPoint>]
let main args =
    //Imprimir cada elemento del array de strings args
    for arg in args do
        MyLibrary.Say.hello arg
    // printfn "Arguments passed to function : %A" args
    // Return 0. This indicates success.
    0

//Para ejecutar el código en la consola, escribir en la terminal:
//dotnet run
//Para compilar el código, escribir en la terminal:
//dotnet build
//Para crear un ejecutable, escribir en la terminal:
//dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true




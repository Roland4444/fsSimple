open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.FileProviders
open Microsoft.AspNetCore.Http
open System
open System.IO
[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    let app = builder.Build()

    // Включаем статические файлы из wwwroot
    app.UseStaticFiles() |> ignore

    // Для корня перенаправляем на index.html
    // app.MapGet("/", Func<string>(fun () -> Results.Content(File.ReadAllText(@"wwwroot\index.html"), "text/html"))) |> ignore


    app.MapGet("/", Func<_>(fun () -> 
        Results.Content(File.ReadAllText(@"wwwroot\index.html"), "text/html")
    )) |> ignore

    // Или лучше так - позволим UseStaticFiles обработать корень через default files
    // Для этого добавим UseDefaultFiles
    app.UseDefaultFiles() |> ignore  // Это должно быть ДО UseStaticFiles

    app.MapGet("/test", Func<string>(fun () -> "Hello World")) |> ignore

    app.Run()
    0
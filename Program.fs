namespace STTApi

open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Mvc
open System.Threading.Tasks
open Transcriber

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    builder.Services.AddControllers()
    let app = builder.Build()

    app.MapPost("/transcribe", async (context: HttpContext) ->
        let form = context.Request.Form
        if form.Files.Count = 0 then
            context.Response.StatusCode <- 400
            return! context.Response.WriteAsync("No file uploaded")
        else
            let file = form.Files.[0]
            use stream = file.OpenReadStream()
            let ms = new System.IO.MemoryStream()
            do! stream.CopyToAsync(ms)
            let bytes = ms.ToArray()
            let! transcription = Transcriber.transcribe bytes
            context.Response.ContentType <- "application/json"
            return! context.Response.WriteAsJsonAsync({| transcription = transcription |})
    )

    app.Run()
    0
open NetVips

Log.SetLogHandler(
    "VIPS",
    Enums.LogLevelFlags.Warning,
    fun domain level message ->
        printfn $"Domain: '{domain}' Level: {level}"
        printfn $"Message: {message}"
)
|> ignore

[<EntryPoint>]
let main _ =
    try
        use image =
            Image.NewFromFile("./img.png", access = Enums.Access.SequentialUnbuffered)

        image.Heifsave(
            "./img-avif.avif",
            effort = 3,
            q = 80,
            // bitdepth = 8,
            compression = Enums.ForeignHeifCompression.Av1
        )

        printfn "finished creating avif"
        0
    with err ->
        printfn "Error in convertToAvif: %A" err
        1


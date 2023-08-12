﻿open NetVips
open System.IO

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
    with err ->
        printfn "Error in convertToAvif: %A" err

    0

namespace FSharp.WebApi.ExternalTaskHandler

open System.Threading.Tasks
open AtlasEngine
open AtlasEngine.ExternalTasks

type AddPayload() =
    let mutable number1: decimal = decimal(0.0)
    let mutable number2: decimal = decimal(0.0)
    member x.Number1 with get() = number1 and set(v) = number1 <- v
    member x.Number2 with get() = number2 and set(v) = number2 <- v


type AddResult =
    { Sum: decimal; Handler: string }

[<ExternalTaskHandler("Calculation.Add")>]
type AddHandler () =
    interface IExternalTaskHandler<AddPayload, AddResult> with
        member this.HandleAsync(input, _) =
            let sum = input.Number1 + input.Number2
            Task.FromResult({ Sum = sum; Handler = "fsharp" })


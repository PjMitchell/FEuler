namespace FEuler.Core
open FEuler.Domain;

module Sequences =
    let Fibonacci = seq {
        let n2 = ref 0
        yield n2
        let n1 = ref 1
        yield n1
        while true do
            let r =  ref(!n2 + !n1)
            yield r
            n2 := !n1
            n1 := !r
    }

type Euler0() = 
    interface IEuler with
        member this.GetId() = 0
        member this.Run() = printfn "This doesn't do much"
        member this.Summary() = printfn "This is just a test to see things work"
type Euler1() = 
    interface IEuler with
        member this.GetId() = 1
        member this.Run() = printfn "Find the sum of all the multiples of 3 or 5 below 1000."
        member this.Summary() =
            [3..999]
                |> List.filter (fun x -> x % 3 = 0 || x % 5 = 0)
                |> List.sum
                |> printfn "%A"

type Euler2() =  
    interface IEuler with
        member this.GetId() = 2
        member this.Run() = printfn "By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms."
        member this.Summary() =               
            let mutable n2 = 0
            let mutable n1 = 1
            let mutable total = 0
            while n1 <= 4000000 do
                let r = n1 + n2
                printfn "%A" r
                n2 <- n1
                n1 <- r
                if r%2 = 0 then total <- r + total
            printfn "%A" total
   
   
   


 
          
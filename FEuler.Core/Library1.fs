namespace FEuler.Core
open FEuler.Domain;
open System;
module Sequences =
    let Fibonacci =Seq.unfold (fun (n1, n2) -> Some(n1 + n2, (n2, (n1 + n2)) ))(0,1) 
module Euler =
    let getPrimeFactors x  =
        let rec primeDiv x i =                     
            if i < x then
                if x % i = 0UL then i :: primeDiv (x / i) i
                else 
                    primeDiv x (i + 1UL)
            else
                x::[]
        primeDiv x 2UL  

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
            Sequences.Fibonacci 
                |> Seq.takeWhile ( fun x-> x< 4000000)
                |> Seq.filter (fun x ->  x%2 = 0)
                |> Seq.sum
                |> printfn "%d"
                       
type Euler3() =  
    interface IEuler with
        member this.GetId() = 3
        member this.Run() = printfn "What is the largest prime factor of the number 600851475143 ?"
        member this.Summary() =  
           
            Euler.getPrimeFactors 600851475143UL
                |> List.max
                |> printfn "%A" 
                

   
   
   


 
          
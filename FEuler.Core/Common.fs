namespace FEuler.Core
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
    let reverse x =
        let rec reverseInner (input, output) =
            if input = 0 then
                (input ,output)
            else
                reverseInner ( input / 10, output * 10 + input % 10)
        reverseInner (x, 0)
        |> snd
    let isPalindrome x =
        let v = reverse x
        x = v 
module Sequences =
    let Fibonacci =Seq.unfold (fun (n1, n2) -> Some(n1 + n2, (n2, (n1 + n2)) ))(0,1) 
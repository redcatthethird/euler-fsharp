module Factors
open System.Diagnostics

open Func
open Integral

let inline divisibleBy div x = x % div = 0G

let inline factors n =
    [2G .. n / 2]
    |> List.filter (applySecond divisibleBy n)

let inline allFactors n = 1G :: n :: factors n

let primes = Seq.initInfinite id |> Seq.skip 2 |> Seq.filter isPrime

[<DebuggerDisplay("{Factor}^{Quantity}")>]
type PrimeFactorQuantity =
    { Factor : int; Quantity : int }
    static member (+) (a, b) =
        if a.Factor = b.Factor then { a with Quantity = a.Quantity + b.Quantity }
        else failwith "Cannot add prime factor quantities for different factors"


let zipFactorLists zipper a b =
    let zipFactorQuantities f =
        let findIn = List.tryFind (fun f' -> f'.Factor = f)
        match (findIn a, findIn b) with
        | None, None -> failwith "There must always be at least one factor found"
        | Some factor, None -> factor
        | None, Some factor -> factor
        | Some factorA, Some factorB -> zipper factorA factorB
    a @ b |> List.map (fun f -> f.Factor) |> List.distinct |> List.map zipFactorQuantities |> List.sort
    
let inline primeFactors n = n |> factors |> List.filter isPrime

let newFactor n = { Factor = n; Quantity = 1 }

let primeFactorQuantities =
    let addFactor f fs =
        let existingFactor, restFactors = fs |> List.partition (fun f' -> f'.Factor = f)
        match existingFactor |> List.tryHead with
        | Some factor -> factor + newFactor f :: restFactors
        | None -> newFactor f :: restFactors
    let rec impl fs n' =
        if n' <= 1 then fs
        elif isPrime n' then addFactor n' fs
        else
            let firstFactor = n' |> primeFactors |> List.head
            impl (addFactor firstFactor fs) (n' / firstFactor)
    impl [] >> List.sort
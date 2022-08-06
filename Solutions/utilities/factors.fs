module Factors
open System.Diagnostics

open Integral
open Primes

let inline divisibleBy n div = n % div = 0G

let inline isPrime n = not ({2G..isqrt n} |> Seq.exists (divisibleBy n))

let inline factors n =
    [1G .. isqrt n]
    |> List.filter (divisibleBy n)
    |> List.collect (fun div -> [div; n / div])

[<DebuggerDisplay("{Factor}^{Quantity}")>]
type PrimeFactorQuantity =
    { Factor : Prime; Quantity : uint }
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

let inline (^) n q = { Factor = uint64 n; Quantity = uint q }

let inline (!) n = n^1

let inline (<+>) f fs =
    let existingFactor, restFactors = fs |> List.partition (fun f' -> f'.Factor = f)
    match existingFactor |> List.tryHead with
    | Some factor -> factor + !f :: restFactors
    | None -> !f :: restFactors

let primeFactorQuantities =
    let rec impl d n' =
        if n' <= 1G then []
        elif n' < (d * d) then [!n']
        elif divisibleBy n' d then d <+> impl d (n'/d)
        else impl (d+1G) n'
    impl 2G >> List.sort
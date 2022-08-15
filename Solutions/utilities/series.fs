module Series
open Integral
open Factors

let inline numbersUntil n = [1G..n]

let inline factorial n = n |> numbersUntil |> List.fold (*) 1G

let inline triangle n = n |> numbersUntil |> List.fold (+) 0G
    
let rec fib = function
    | n when n <= 0 -> 0
    | 1 -> 1
    | n -> fib(n-1) + fib(n-2)

let collatzStep n =
    match n with
    | 1UL -> 1UL
    | Even -> n / 2UL
    | Odd -> 3UL*n + 1UL
    | _ -> failwith "n is impossible"

let rec collatzChain = function
    | 1UL -> [1UL]
    | n -> n :: (n |> collatzStep |> collatzChain)

let rec collatzLength = function
    | 1UL -> 1UL
    | n -> 1UL + (n |> collatzStep |> collatzLength)
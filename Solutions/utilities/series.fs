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

let inline collatzStep n =
    match n with
    | _ when n = 1G -> 1G
    | Even -> n / 2G
    | Odd -> 3G*n + 1G
    | _ -> failwith "n is impossible"

let rec inline collatzChain n =
    match n with
    | _ when n = 1G -> [1G]
    | _ -> n :: (n |> collatzStep |> collatzChain)

let rec inline collatzLength n =
    match n with
    | _ when n = 1G -> 0UL
    | _ -> 1UL + (n |> collatzStep |> collatzLength)
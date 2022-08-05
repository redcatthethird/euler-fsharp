﻿module Series
open Integral

let inline numbersUntil n = [1G..n]

let inline factorial n = n |> numbersUntil |> List.fold (*) 1G

let inline triangle n = n |> numbersUntil |> List.fold (+) 0G
    
let rec fib = function
    | n when n <= 0 -> 0
    | 1 -> 1
    | n -> fib(n-1) + fib(n-2)
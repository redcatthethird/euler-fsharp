module S0003
open Factors

let inline solution n = n |> primeFactors |> List.max
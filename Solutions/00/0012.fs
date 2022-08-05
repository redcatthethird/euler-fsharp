module S0012
open Factors
open Series

let hasAtMostFactors nDiv = allFactors >> List.length >> ((>=) nDiv)

let solution nDiv =
    Seq.initInfinite triangle
    |> Seq.skipWhile (hasAtMostFactors nDiv)
    |> Seq.head
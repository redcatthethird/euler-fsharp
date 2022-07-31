module S0007
open Factors

let solution n = primes |> Seq.skip (n - 1) |> Seq.head
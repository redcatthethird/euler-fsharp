module S0007
open Primes

let solution n = primes () |> Seq.item (n - 1)
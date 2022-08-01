module S0010
open Primes

let solution = primesUntil >> List.map int64 >> List.sum
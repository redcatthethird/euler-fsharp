module S0005
open Factors
open Series

let solution =
    numbersUntil
    >> List.map primeFactorQuantities
    >> List.reduce (zipFactorLists max)
    >> List.map (fun f -> pown f.Factor f.Quantity)
    >> List.reduce (*)